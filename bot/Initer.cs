﻿namespace bot
{
    public static class Initer
    {
        public static List<string> photos = new List<string>(){
            "https://raw.githubusercontent.com/AnriiAndrushko/TelegramBotSmartCity/master/photos/photo0.png",
            "https://raw.githubusercontent.com/AnriiAndrushko/TelegramBotSmartCity/master/photos/photo1.png",
            "https://raw.githubusercontent.com/AnriiAndrushko/TelegramBotSmartCity/master/photos/photo2.png",
            "https://raw.githubusercontent.com/AnriiAndrushko/TelegramBotSmartCity/master/photos/photo3.png",
            "https://raw.githubusercontent.com/AnriiAndrushko/TelegramBotSmartCity/master/photos/photo4.png",
            "https://raw.githubusercontent.com/AnriiAndrushko/TelegramBotSmartCity/master/photos/photo5.png",
            "https://raw.githubusercontent.com/AnriiAndrushko/TelegramBotSmartCity/master/photos/photo6.jpg",
            "https://raw.githubusercontent.com/AnriiAndrushko/TelegramBotSmartCity/master/photos/photo7.jpg",
            "https://raw.githubusercontent.com/AnriiAndrushko/TelegramBotSmartCity/master/photos/photo8.jpg",
            "https://raw.githubusercontent.com/AnriiAndrushko/TelegramBotSmartCity/master/photos/photo9.png",
            "https://raw.githubusercontent.com/AnriiAndrushko/TelegramBotSmartCity/master/photos/photo10.jpg",
            "https://raw.githubusercontent.com/AnriiAndrushko/TelegramBotSmartCity/master/photos/photo11.png",
            "https://raw.githubusercontent.com/AnriiAndrushko/TelegramBotSmartCity/master/photos/photo12.jpg",
            "https://raw.githubusercontent.com/AnriiAndrushko/TelegramBotSmartCity/master/photos/photo13.jpg",
            "https://raw.githubusercontent.com/AnriiAndrushko/TelegramBotSmartCity/master/photos/photo14.jpg",
            "https://raw.githubusercontent.com/AnriiAndrushko/TelegramBotSmartCity/master/photos/photo15.jpg",
            "https://raw.githubusercontent.com/AnriiAndrushko/TelegramBotSmartCity/master/photos/photo16.jpg",
            "https://raw.githubusercontent.com/AnriiAndrushko/TelegramBotSmartCity/master/photos/photo17.jpg",
            "https://raw.githubusercontent.com/AnriiAndrushko/TelegramBotSmartCity/master/photos/photo18.jpg",
            "https://raw.githubusercontent.com/AnriiAndrushko/TelegramBotSmartCity/master/photos/photo19.jpg",
            "https://raw.githubusercontent.com/AnriiAndrushko/TelegramBotSmartCity/master/photos/photo20.jpg",
            "https://raw.githubusercontent.com/AnriiAndrushko/TelegramBotSmartCity/master/photos/photo21.jpg",
            "https://raw.githubusercontent.com/AnriiAndrushko/TelegramBotSmartCity/master/photos/photo22.jpg",
            "https://raw.githubusercontent.com/AnriiAndrushko/TelegramBotSmartCity/master/photos/photo23.jpg",
            "https://raw.githubusercontent.com/AnriiAndrushko/TelegramBotSmartCity/master/photos/photo24.jpg",
            "https://raw.githubusercontent.com/AnriiAndrushko/TelegramBotSmartCity/master/photos/photo25.jpg",
            "https://raw.githubusercontent.com/AnriiAndrushko/TelegramBotSmartCity/master/photos/photo26.jpg",
            "https://raw.githubusercontent.com/AnriiAndrushko/TelegramBotSmartCity/master/photos/photo27.jpg",
        };
        public static List<Test> GetTests()
        {
            return new List<Test>() { 
                {new Test("Ви ненавмисно видалили папку. Як можна її відновити в тому ж самому місці, з якого вона була видалена?", new List<(int, string)>() { 
                    (0, "На панелі задач здійснити пошук команди (Відновлення початкового стану команд)"),
                    (1, "На Робочому столі відкрити (Кошик) - знайти потрібну папку - в конкретному меню обрати (Відновити)"),
                    (2, "На Робочому столі відкрити (Кошик) - знайти потрібну папку - натиснути на неї двічі лівою кнопкою миші (ЛКМ)"),
                    (3, "На Робочому столі відкрити (Кошик) - знайти потрібну папку - натиснути клавішу Delete")
                }, 1, photos[6]) },
                {new Test("Принцип програмного керування роботою комп'ютера передбачає:", new List<(int, string)>() {
                    (0, "Можливість виконання без зовнішнього втручання цілої серії команд"), 
                    (1, "Використання формул обчислення висловлювань для реалізації команд у комп'ютері"),
                    (2, "Двійкове кодування даних у комп'ютері"),
                    (3, "Моделювання інформаційної діяльності людини під час керування комп'ютером") 
                }, 0, photos[7]) },
                {new Test("Ви ненароком закрили вкладку з сайтом, який ще не встигли зберегти. Яка опція на панелі Налаштування допоможе відновити закриті вкладки?", new List<(int, string)>() {
                    (0, "Завантаження"), 
                    (1, "Історія"),
                    (2, "Закладки"),
                    (3, "Знайти") 
                }, 1, photos[8]) },
                {new Test("З якої команди потрібно починати створення нового файла у відкритій програмі операційної системи Windows?", new List<(int, string)>() {
                    (0, "Файл - Відкрити"), 
                    (1, "Файл - Створити"),
                    (2, "Правка - Вставити"),
                    (3, "Правка - Знайти") 
                }, 1, photos[9]) },
                {new Test("Ви хочете зробити фото свого мальовничого міста та надіслати другові з іншого міста. Яку іконку потрібно обрати, щоб відкрити камеру на телефоні?", new List<(int, string)>() {
                    (0, "1"), 
                    (1, "2"),
                    (2, "3"),
                    (3, "4") 
                }, 2, photos[0]) },
                {new Test("Ви приховали від інших користувачів Facebook свої електронну адресу та номер телефону, але нещодавно у Вашому життєписі з’явилася публікація, на якій Вас позначили (тегнули), хоча Вам це не до вподоби. У якому розділі можна це налаштувати?", new List<(int, string)>() {
                    (0, "1"), 
                    (1, "2"),
                    (2, "3"),
                    (3, "4") 
                }, 2, photos[1]) },
                {new Test("Ви почали записувати аудіоповідомлення з мобільного, але випадково надіслали його, не завершивши. Як видалити помилково надіслане аудіоповідомлення?", new List<(int, string)>() {
                    (0, "Неможливо видалити повідомлення, яке вже надіслано"), 
                    (1, "Попросити подругу видалити в себе повідомлення"),
                    (2, "Натиснути на повідомлення та вибрати відповідну опцію в меню"),
                    (3, "Зателефонувати оператору та попросити видалити повідомлення") 
                }, 2, photos[10]) },
                {new Test("Чим https відрізняється від http?", new List<(int, string)>() {
                    (0, "Різниці немає"), 
                    (1, "https з’єднання швидше"),
                    (2, "https — це розширення протоколу HTTP, яке підтримує захист даних під час транспортування за допомогою шифрування"),
                    (3, "https та http це різні технології, кожна з яких виконує свої задачі") 
                }, 2, photos[11]) },
                {new Test("Ви почули цікаву пісню на радіо, але не запам’ятали назву, лише приспів. Як вам відшукати цю пісню в інтернеті?", new List<(int, string)>() {
                    (0, "Використати OR між словами приспіву"), 
                    (1, "Використати @ перед приспівом"),
                    (2, "Використати зірку замість деяких слів"),
                    (3, "Взяти приспів у лапки та гуглити") 
                }, 3, photos[12]) },
                {new Test("Уявіть, що Ви хочете приготувати на свято оселедця під шубою, але трохи призабули рецепт. Оберіть найшвидший варіант пошуку в інтернеті. Як найкраще ввести запит у Google?", new List<(int, string)>() {
                    (0, "Підкажіть, будь ласка, рецепт оселедця під шубою"), 
                    (1, "Оселедець під шубою"),
                    (2, "Шуба"),
                    (3, "Салат із оселедця, овочів, яєць і майонезу") 
                }, 1, photos[13]) },
                {new Test("Які дії можна виконувати з документом, підписаним цифровим підписом?", new List<(int, string)>() {
                    (0, "Тільки редагування"), 
                    (1, "Тільки читання"),
                    (2, "Читання і редагування"),
                    (3, "Форматування") 
                }, 1, photos[14]) },
                {new Test("Які переваги користувачу надає цифрова ідентифікація?", new List<(int, string)>() {
                    (0, "Банківські послуги онлайн"), 
                    (1, "Медична допомога"),
                    (2, "Цифрове посвідчення особи"),
                    (3, "Усе вищеперераховане") 
                }, 3, photos[15]) },
                {new Test("Який захист особистих даних Вашого мобільного пристрою є найбільш надійним (таким, що неможливо відтворити без Вашої добровільної згоди)?", new List<(int, string)>() {
                    (0, "Відбитки пальців"), 
                    (1, "Система розпізнавання обличчя"),
                    (2, "Код доступу/графічний ключ"),
                    (3, "Дівоче прізвище матері") 
                }, 2, photos[17]) },
                {new Test("Як власноруч назавжди поміняти мову браузера?", new List<(int, string)>() {
                    (0, "Мова залежить від вашого географічного розташування і власноруч не змінюється"), 
                    (1, "Під пошуковим рядком натиснути Налаштування — Мови та вибрати необхідну мову"),
                    (2, "Під пошуковим рядком натиснути Інструменти і вибрати мову"),
                    (3, "Ввести в пошуковий рядок назву браузера та країну з необхідною мовою") 
                }, 1, photos[16]) },
                {new Test("Чи можна вибрати час, за який показуватиме результати пошуку?", new List<(int, string)>() {
                    (0, "Результати завжди показуються за весь час"), 
                    (1, "Під пошуковим рядком натиснути Налаштування — Час"),
                    (2, "Результати пошуку завжди фільтруються за релевантністю, тому в цьому немає потреби"),
                    (3, "Під пошуковим рядком натиснути Інструменти, в кнопці «Будь-коли» вибрати необхідний проміжок часу") 
                }, 2, photos[18]) },
                {new Test("Вебсторінку потрібно перезавантажити. Що з цього треба натиснути?", new List<(int, string)>() {
                    (0, "1"), 
                    (1, "2"),
                    (2, "3"),
                    (3, "4") 
                }, 1, photos[2]) },
                {new Test("Як відрізнити об'єктивну від суб’єктивної інформацію в інтернеті? Об’єктивна інформація…", new List<(int, string)>() {
                    (0, "Дуже детальна, надає багато прикладів та цитат"), 
                    (1, "Надає посилання на думки відомих людей"),
                    (2, "Надає конкретні факти та посилання на офіційні джерела інформації"),
                    (3, "Надає відгуки та враження від багатьох людей/ користувачів") 
                }, 2, photos[19]) },
                {new Test("Ви шукали рецепт оселедця під шубою і випадково прочитали у Facebook, що поєднання оселедця з буряком страшенно шкідливе для здоров’я. Тепер Ви не знаєте, готувати цей салат чи ні. Як визначитися, чи можна довіряти джерелу?", new List<(int, string)>() {
                    (0, "Якщо це вже опубліковано, то цій інформації можна довіряти. Хто публікуватиме неправду про салат?"), 
                    (1, "Якщо багато людей поширює цю інформацію — вона, найімовірніше, правдива"),
                    (2, "Це допис у Facebook, а отже, чиясь точка зору. Треба пошукати інші джерела"),
                    (3, "Автор допису пропонує здорову альтернативу — придбати в нього тофу. Це конструктивна порада, джерелу довіряти можна") 
                }, 2, photos[20]) },
                {new Test("Ви перевірили та переконались, що новина про гречку — це фейк (неправда) і тепер хочете написати про це на своїй сторінці у Facebook. Яке поле вам потрібно обрати, щоб це зробити?", new List<(int, string)>() {
                    (0, "Профіль подруги в меню ліворуч"), 
                    (1, "Кнопка «Створити» на панелі зверху"),
                    (2, "Пошук на панелі зверху"),
                    (3, "Поле «Що у вас на думці, _______?» на головній сторінці") 
                }, 3, photos[21]) },
                {new Test("Вам потрібний зручний месенджер для переписки, з можливістю підписатися на групи з різним контентом. Найкращий варіант — це:", new List<(int, string)>() {
                    (0, "Reddit"), 
                    (1, "Google +"),
                    (2, "Telegram"),
                    (3, "Signal") 
                }, 2, photos[22]) },
            };
        }
        public static List<(string text, string pathToImg)> GetTheory()
        {
            return new List<(string text, string pathToImg)>() {
(@"Видалену ненавмисно папку можна відновити на тому самому мцсці, з якого вона була видалена на Робочому столі потрібно відкрити (Кошик) - знайти потрібну папку - в конкретному меню обрати (Відновити)", photos[9]),
//---------------------------------------------
(@"Принцип програмного керування роботою комп'ютера передбачає: Можливість виконання без зовнішнього втручання цілої серії команд", photos[23]),
//---------------------------------------------
(@"Відкрити вкладку яку ви ненароком закрили допоможе опція Історія", photos[24]),
//---------------------------------------------
(@"Для того щоб почати створювати файл в операційній системі Windows вам необхідно обрати (Файл - Створити)", photos[9]),
//---------------------------------------------
(@"значок камери на телефоні", photos[3]),
//---------------------------------------------
(@"Ця опція в Facebook допоможе конторювати усі згадки про вас", photos[4]),
//---------------------------------------------
(@"Любе повідомлення можна видалити, натиснувши на нього та вибравши відповідну опцію", photos[25]),
//---------------------------------------------
(@"https - це розширення протоколу http для безпечого шифрування в цілях підвищеня безпеки", photos[11]),
//---------------------------------------------
(@"Ви почули цікаву пісню на радіо, але не запам’ятали назву, лише приспів. Як вам відшукати цю пісню в інтернеті?", photos[12]),
//---------------------------------------------
(@"Слово (вислів) ставлть в лапки для пошуку сайту, з таким ж словом (висловом)", photos[13]),
//---------------------------------------------
(@"Пдчас пошуку найкраще використовувати назву предмету яку ви шукаєте, без лишніх додатків", photos[12]),
//---------------------------------------------
(@"Документ підписаний цифровим підписом, можна тільки переглядати", photos[9]),
//---------------------------------------------
(@"Цифрова ідентифікація дозволяє: користуватися банками онлайн, викликати медичну допомогу та надає вам цифрове посвідчення особи", photos[14]),
//---------------------------------------------
(@"Найкращий захист ваших персональних данних на телефоні це код доступу або графічний ключ", photos[15]),
//---------------------------------------------
(@"Для того щоб власноруч змінити мову браузера вам необхідно під пошуковим рядком натиснути Налаштування — Мови та вибрати необхідну мову", photos[16]),
//---------------------------------------------
(@"Результати пошуку завжди фільтруються за релевантністю, тому в цьому немає потреби", photos[12]),
//---------------------------------------------
(@"Ця кнопка використовується для перезавантаження сторінки", photos[5]),
//---------------------------------------------
(@"Об’єктивна інформація надає конкретні факти та посилання на офіційні джерела інформації", photos[13]),
//---------------------------------------------
(@"Не довіряйте усім постам в інтернеті, перепровіряйте інформацію", photos[19]),
//---------------------------------------------
(@"Для того щоб поділитись інформацією в Facebook вам потрібно обрати поле «Що у вас на думці, _______?» на головній сторінці", photos[20]),
//---------------------------------------------
(@"Telegram хороший месенджер для переписок, без обмежень у виборі груп з різним контентом", photos[22])
            };
        }
    }
}
