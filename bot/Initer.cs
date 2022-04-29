namespace bot
{
    public static class Initer
    {
        public static List<string> photos = new List<string>(){
            "https://raw.githubusercontent.com/AnriiAndrushko/TelegramBotSmartCity/master/photos/photo1.jpg",
            "https://raw.githubusercontent.com/AnriiAndrushko/TelegramBotSmartCity/master/photos/photo2.jpg",
            "https://raw.githubusercontent.com/AnriiAndrushko/TelegramBotSmartCity/master/photos/photo3.jpg",
            "https://raw.githubusercontent.com/AnriiAndrushko/TelegramBotSmartCity/master/photos/photo4.jpg",
            "https://raw.githubusercontent.com/AnriiAndrushko/TelegramBotSmartCity/master/photos/photo5.png",
            "https://raw.githubusercontent.com/AnriiAndrushko/TelegramBotSmartCity/master/photos/photo6.png",
        };
        public static List<Test> GetTests()
        {
            return new List<Test>() { 
                {new Test("2+2?", new List<(int, string)>() { 
                    (0, "4"), (1, "10") 
                }, 0, photos[0]) },
                //---------------------------------------------
                {new Test("Цвет неба?", new List<(int, string)>() {
                    (0, "Синий"), (1, "Красный"),(2, "Зеленый") 
                }, 0, photos[1]) },
            };
        }
        public static List<(string text, string pathToImg)> GetTheory()
        {
            return new List<(string text, string pathToImg)>() {
(@"some
interesting
facts: you are gay",
photos[2]),
//---------------------------------------------
(@"bla bla
blaaaaa", 
photos[3]),
//---------------------------------------------
(@"Зап не убивает мух с 1 тычки", 
photos[4]),
            };
        }
    }
}
