    public class LevelData // Make class public
    {
        private List<LevelElement> elements;
        public readonly List<LevelElement> Elements;
        public void Load(string fileName)
        {
            using StreamReader sr = new StreamReader(fileName);
            while (sr.Peek() >= 0)
            {
                Console.WriteLine((char)sr.Read());
            }
        }
    }