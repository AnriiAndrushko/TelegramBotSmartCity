using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using bot;
using System.Text;
using Telegram.Bot.Types.ReplyMarkups;



Console.WriteLine("Enter bot token");
string token;
token = Console.ReadLine();
var botClient = new TelegramBotClient(token);
botClient.Timeout = TimeSpan.FromSeconds(15);
using var cts = new CancellationTokenSource();
Directory.CreateDirectory("databases");
UsersDatabase users = new UsersDatabase(@"databases\Users.txt");
TestsDatabase tests = new TestsDatabase();
HighScoreDatabase highscore = new HighScoreDatabase(@"databases\Highscore.txt");
TheoryDtabase theorys = new TheoryDtabase();


// StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
var receiverOptions = new ReceiverOptions
{
    AllowedUpdates = { } // receive all update types
};

botClient.StartReceiving(
    HandleUpdateAsync,
    HandleErrorAsync,
    receiverOptions,
    cancellationToken: cts.Token);

var me = await botClient.GetMeAsync();
LogInConsole($"Start listening for @{me.Username}");
Console.ReadLine();

highscore.saveToDatabase();
users.SaveToDatabase();
// Send cancellation request to stop bot
cts.Cancel();



async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    // Only process Message updates: https://core.telegram.org/bots/api#message
    if (update.Type != UpdateType.Message)
        return;
    // Only process text messages
    if (update.Message!.Type != MessageType.Text)
        return;

    var chatId = update.Message.Chat.Id;
    var messageText = update.Message.Text;
    var username = update.Message.From.FirstName + update.Message.From.LastName;

    var curUser = users.GetUser(chatId, username);
    LogInConsole($"Received a '{messageText}' message in chat {chatId}. By {username}");
    StringBuilder message = new StringBuilder();


    //for (int i = 0; i < Initer.photos.Count; i++)
    //{
    //    await TestPhoto(curUser, cancellationToken, message, i);
    //    message.Clear();
    //}
    //return;

    switch (curUser.MyState)
    {
        case User.State.NotRegistered:
            curUser.Register();
            message.AppendLine("О, в нас новенький!");
            await ShowMenu(curUser, cancellationToken, message);
            break;
        case User.State.InMenu:
            switch (messageText)
            {
                case "Пройти тест":
                    curUser.BeginTest(tests.GetRandomTests());
                    await ShowCurrentTest(curUser, cancellationToken, message);

                    break;
                case "Почитати теорію":
                    curUser.ReadTheory();
                    await ShowTheory(curUser, cancellationToken, message);
                    break;
                case "Топ найкращих":
                    await ShowLeaderboard(curUser, cancellationToken, message);
                    break;
                default:
                    await ShowMenu(curUser, cancellationToken, message);
                    break;
            }
            break;
        case User.State.WaitingForAnswerToTest:
            if (curUser.MakeAnswer(messageText))
            {
                message.AppendLine("Так, правильно, молодець!");
            }
            else
            {
                message.AppendLine("Нажаль не вгадав(");
            }
            if (curUser.MyState != User.State.WaitingForAnswerToTest)
            {
                message.AppendLine("Твоя оцінка: ").Append(curUser.CurrentScore).
                        Append("/").Append(curUser.TestNumber - 1).AppendLine();
                highscore.AddNewHighscore(username, curUser.CurrentScore); //curUser.HighestScore
                await ShowMenu(curUser, cancellationToken, message);
            }
            else
            {
                message.AppendLine("Наступне питання: ");
                await ShowCurrentTest(curUser, cancellationToken, message);
            }
            break;
        case User.State.ReadingTheory:
            switch (messageText)
            {
                case "⬅":
                    curUser.PreviousPage();
                    await ShowTheory(curUser, cancellationToken, message);
                    break;
                case "➡":
                    curUser.NextPage();
                    await ShowTheory(curUser, cancellationToken, message);
                    break;
                default:
                    curUser.SetStateMenu();
                    await ShowMenu(curUser, cancellationToken, message);
                    break;
            }
            break;
        default:
            break;
    }
}


Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
{
    if (exception is RequestException) { return Task.CompletedTask; }
    var ErrorMessage = exception switch
    {
    ApiRequestException apiRequestException
            => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
    _ => exception.ToString()
    };
    LogInConsole(ErrorMessage);
    return Task.CompletedTask;
}
void LogInConsole(string log)
{
    Console.WriteLine(DateTime.Now.ToString("h:mm:ss tt") + log);
}



///////////
async Task<Message> TestPhoto(User user, CancellationToken CST, StringBuilder msg, int photoId)
{
    msg.AppendLine("Фото номер:"+ photoId);
    return await botClient.SendPhotoAsync(
        chatId: user.chatId,
        photo: Initer.photos[photoId],
        caption: msg.ToString(),
        cancellationToken: CST);
}
///////





async Task<Message> ShowTheory(User user, CancellationToken CST, StringBuilder msg)
{
    int theoryPage = user.CurrentPage;
    ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
    {
            new KeyboardButton[] { "Меню", "⬅", "➡"},
        })
    {
        ResizeKeyboard = true,
        OneTimeKeyboard = true
    };
    msg.AppendLine("Сторінка номер: " + (theoryPage + 1));
    msg.AppendLine(theorys.GetPage(theoryPage).text);
    return await botClient.SendPhotoAsync(
        chatId: user.chatId,
        photo: theorys.GetPage(theoryPage).pathToImg,
        caption: msg.ToString(),
        replyMarkup: replyKeyboardMarkup,
        cancellationToken: CST);
}

async Task<Message> ShowLeaderboard(User user, CancellationToken CST, StringBuilder msg)
{
    ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
    {
            new KeyboardButton[] { "Меню"},
        })
    {
        ResizeKeyboard = true,
        OneTimeKeyboard = true
    };
    msg.AppendLine("Топ найкращих:");
    foreach (var score in highscore.GetHighscoreTable())
    {
        msg.AppendLine(score.Item1 + "    " + score.Item2 + "/" + highscore.maxScore);
    }
    return await botClient.SendPhotoAsync(
        chatId: user.chatId,
        photo: Initer.photos[27],
        caption: msg.ToString(),
        replyMarkup: replyKeyboardMarkup,
        cancellationToken: CST);
}

async Task<Message> ShowMenu(User user, CancellationToken CST, StringBuilder msg)
{
    ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
    {
            new KeyboardButton[] { "Пройти тест", "Почитати теорію" , "Топ найкращих"},
        })
    {
        ResizeKeyboard = true,
        OneTimeKeyboard = true
    };


    return await botClient.SendPhotoAsync(
        chatId: user.chatId,
        photo: Initer.photos[26],
        caption: msg.AppendLine("Меню:").ToString(),
        replyMarkup: replyKeyboardMarkup,
        cancellationToken: CST);
}

async Task<Message> ShowCurrentTest(User user, CancellationToken CST, StringBuilder msg)
{
    Test test = user.GetCurrentTest();

    List<List<KeyboardButton>> buttons = new List<List<KeyboardButton>>();

    foreach (KeyboardButton button in test.GetAnswers().Select(x => (KeyboardButton)x.Item2).Shuffle().ToArray())
    {
        buttons.Add(new List<KeyboardButton>() { button });
    }

    ReplyKeyboardMarkup replyKeyboardMarkup = new(buttons)
    {
        ResizeKeyboard = true,
        OneTimeKeyboard = true
    };

    return await botClient.SendPhotoAsync(
        chatId: user.chatId,
        photo: test.Photo,
        caption: msg.Append("Тест номер: ").AppendLine(user.TestNumber.ToString()).AppendLine(test.Question).ToString(),
        replyMarkup: replyKeyboardMarkup,
        cancellationToken: CST);
}

[Serializable]public class Test
{
    public readonly string Question;
    public readonly int CorrectAnswerId;
    public string Photo { get; private set; }
    private List<(int,string)> Answers;

    public Test(string question, List<(int, string)> answers, int correctId, string photo)
    {
        CorrectAnswerId = correctId;
        Answers = answers; 
        Question = question;
        Photo = photo;
        Answers.Shuffle();
    }
    public List<(int,string)> GetAnswers()
    {
        return Answers;
    }
    public bool CheckAnswer(int answerId)
    {
        return answerId==CorrectAnswerId;
    }
    public bool CheckAnswer(string answer)
    {
        return Answers.Any(x => ((x.Item1==CorrectAnswerId) && (x.Item2.Equals(answer))));
    }
}
[Serializable] class User
{
    public long chatId { get; private set; }
    public int CurrentScore { get; private set; } = 0;
    public int TestNumber { get; private set; }
    public string Username { get; private set; }
    public int CurrentPage { get; set; }
    public State MyState { get; private set; }
    public int HighestScore { get; private set; } = 0;
    private Queue<Test> tests;
    private Test currentTest;
    public enum State
    {
        NotRegistered,
        InMenu,
        WaitingForAnswerToTest,
        ReadingTheory
    }
    public bool Register()
    {
        if (MyState != State.NotRegistered) { 
            throw new Exception("Already registered!");
            return false;
        }
        MyState = State.InMenu;
        return true;
    }
    public User(long chatId,string ?username, State state = State.NotRegistered, int highestScore = 0, int curentPage = 0, Test ?currentTest = null, List<Test> ?tests = null)
    {
        if (username == null)
        {
            Username = "null";
        }
        else
        {
            Username = username;
        }

        HighestScore = highestScore;
        this.chatId = chatId;
        MyState = state;
        CurrentPage = curentPage;
        if (state == State.WaitingForAnswerToTest)
        {
            if (currentTest==null||tests==null) { throw new Exception("No data!"); }
            this.currentTest = currentTest;
            this.tests = new Queue<Test>(tests);
        }
    }
    public void BeginTest(List<Test> tests)
    {
        if (MyState != State.InMenu) { throw new Exception("Wrong State!"); }
        MyState = State.WaitingForAnswerToTest;
        CurrentScore = 0;
        TestNumber = 1;
        this.tests = new Queue<Test>(tests);
        currentTest = this.tests.Dequeue();
    }
    public Test GetCurrentTest()
    {
        if (MyState != State.WaitingForAnswerToTest) { throw new Exception("Wrong State!"); }
        return currentTest;
    }
    public bool MakeAnswer(string answer)
    {
        if (MyState != State.WaitingForAnswerToTest) { throw new Exception("Wrong State!"); }
        bool returnable = currentTest.CheckAnswer(answer);
        TestNumber++;
        if (returnable) { CurrentScore++; }
        if(tests.Count == 0)
        {
            if (HighestScore < CurrentScore) { HighestScore = CurrentScore; }
            SetStateMenu();
        }
        else
        {
            currentTest = tests.Dequeue();
        }
        return returnable;
    }
    public void ReadTheory()
    {
        if (MyState != State.InMenu) { throw new Exception("Wrong State!"); }
        CurrentPage = 0;
        MyState = State.ReadingTheory;
    }
    public void NextPage()
    {
        if (MyState != State.ReadingTheory) { throw new Exception("Wrong State!"); }
        CurrentPage++;
        if (CurrentPage > Initer.GetTheory().Count - 1)
        {
            CurrentPage = 0;
        }
    }
    public void PreviousPage()
    {
        if (MyState != State.ReadingTheory) { throw new Exception("Wrong State!"); }
        CurrentPage--;
        if (CurrentPage<0)
        {
            CurrentPage = Initer.GetTheory().Count-1;
        }
    }
    public void SetStateMenu()
    {
        if (MyState == State.NotRegistered) { throw new Exception("Wrong State!"); }
        MyState = State.InMenu;
    }
}

class UsersDatabase : Database
{
    private Dictionary<long, User> users;
    readonly string path;
    public UsersDatabase(string pathToUsersFile) {
        path = pathToUsersFile;
        users = getUsersFromDatabase();
    }

    private Dictionary<long, User> getUsersFromDatabase()
    {
        var toReturn = ReadFromBinaryFile<Dictionary<long, User>>(path);
        return toReturn==null ? new Dictionary<long, User>() :toReturn;
    }
    //public bool TryAddOrRegisterUser(string username, int userId)
    //{
    //    if (!users.ContainsKey(userId))
    //    {
    //        users.Add(userId, new User(userId, username));
    //    }
    //    if (!users[userId].Register()) { return false; };
    //    return true;
    //}
    public void SaveToDatabase()
    {
        WriteToBinaryFile(path, users);
    }

    public User? GetUser(long userId, string? username)
    {
        if (users.ContainsKey(userId))
        {
            return users.GetValueOrDefault(userId);
        }
        users.Add(userId, new User(userId, username));
        return users.GetValueOrDefault(userId);
    }
}

class TestsDatabase
{
    private List<Test> tests;
    public TestsDatabase() {
        tests = getTestsFromDatabase();
    }
    private List<Test> getTestsFromDatabase()
    {
        return Initer.GetTests();
    }
    public List<Test> GetTests()
    {
        return tests;
    }
    public List<Test> GetRandomTests()
    {
        return tests.Shuffle().ToList();
    }
}


class HighScoreDatabase : Database
{
    readonly string path;
    private Dictionary<string, int> scores;
    public readonly int maxScore = 0;
    public HighScoreDatabase(string pathToHighScoreFile)
    {
        path = pathToHighScoreFile;
        scores = getScoresFromDatabase();
        maxScore = Initer.GetTests().Count;
    }
    private Dictionary<string, int> getScoresFromDatabase()
    {
        var toReturn = ReadFromBinaryFile<Dictionary<string, int>>(path);
        return toReturn == null ? new Dictionary<string, int>() : toReturn;
    }

    public List<(string, int)> GetHighscoreTable()
    {
        return scores.ToList().OrderBy(x => -1*x.Value).Select(x=>(x.Key, x.Value )).ToList();
    }
    public void AddNewHighscore(string username, int score)
    {
        if (scores.ContainsKey(username))
        {
            scores[username] = score;

        }
        else
        {
            scores.Add(username, score);
        }
    }
    public void saveToDatabase()
    {
        WriteToBinaryFile<Dictionary<string, int>>(path,scores);
    }
}


class TheoryDtabase
{
    private List<(string text, string pathToImg)> theory;
    public TheoryDtabase()
    {
        theory = getTheoryFromDatabase();
    }
    private List<(string text, string pathToImg)> getTheoryFromDatabase()
    {
        return Initer.GetTheory();
    }

    public (string text, string pathToImg) GetPage(int page)
    {
        if (page >= theory.Count || page < 0){throw new Exception("Wrong theory page!");}
        return theory[page];
    }
}


public static class IEnumerableExtensions
{
    public static IEnumerable<t> Shuffle<t>(this IEnumerable<t> target)
    {
        Random r = new Random();

        return target.OrderBy(x => (r.Next()));
    }
}


abstract class Database
{
    /// <summary>
    /// Writes the given object instance to a binary file.
    /// <para>Object type (and all child types) must be decorated with the [Serializable] attribute.</para>
    /// <para>To prevent a variable from being serialized, decorate it with the [NonSerialized] attribute; cannot be applied to properties.</para>
    /// </summary>
    /// <typeparam name="T">The type of object being written to the XML file.</typeparam>
    /// <param name="filePath">The file path to write the object instance to.</param>
    /// <param name="objectToWrite">The object instance to write to the XML file.</param>
    /// <param name="append">If false the file will be overwritten if it already exists. If true the contents will be appended to the file.</param>
    public static void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
    {
        using (Stream stream = System.IO.File.Open(filePath, append ? FileMode.Append : FileMode.Create))
        {
            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            binaryFormatter.Serialize(stream, objectToWrite);
        }
    }

    /// <summary>
    /// Reads an object instance from a binary file.
    /// </summary>
    /// <typeparam name="T">The type of object to read from the XML.</typeparam>
    /// <param name="filePath">The file path to read the object instance from.</param>
    /// <returns>Returns a new instance of the object read from the binary file.</returns>
    public static T ReadFromBinaryFile<T>(string filePath)
    {
        using (Stream stream = System.IO.File.Open(filePath, FileMode.OpenOrCreate))
        {
            if (stream.Length==0)
            {
                return default(T);
            }
            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            return (T)binaryFormatter.Deserialize(stream);
        }
    }
}