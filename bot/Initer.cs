namespace bot
{
    public static class Initer
    {
        public static List<string> photos = new List<string>(){
            "https://pngimg.com/uploads/anime_girl/anime_girl_PNG13.png",
            "https://www.meme-arsenal.com/memes/c6dc216e2cf1d0689dd1d60afb430e93.jpg",
            "https://img5.goodfon.ru/wallpaper/nbig/3/1d/anime-anime-girl-cute-girl.jpg",
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
photos[0]),
//---------------------------------------------
(@"bla bla
blaaaaa", 
photos[2]),
//---------------------------------------------
(@"Зап не убивает мух с 1 тычки", 
photos[1]),
            };
        }
    }
}
