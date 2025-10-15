namespace Game.LevelData;

public class LevelData {

	private readonly List<LevelElement> elements = new();
	public IReadOnlyList<LevelElement> Elements => elements.AsReadOnly();
	public Player? Player { get; set; }
	public bool YouSuck { get; set; }
	public bool RemoveElement(LevelElement element) => elements.Remove(element);
	public int toolBarY;

	public void Load(string fileName) {
		try {
			string[] lines = File.ReadAllLines(fileName);
			Console.CursorVisible = false;
			for(int y = 0; y < lines.Length; y++) {
				string line = lines[y];
				for(int x = 0; x < line.Length; x++) {
					char ch = line[x];
					if(ch.Equals('#')) elements.Add(new Wall(x, y));
					else if(ch.Equals('r')) elements.Add(new Rat(x, y));
					else if(ch.Equals('s')) elements.Add(new Snake(x, y));
					else if(ch.Equals('@')) elements.Add(Player = new Player(x, y));
					else if(ch.Equals(' ')) Console.SetCursorPosition(x, y); Console.Write(' ');
				}
			}
			Console.Clear();
			toolBarY = lines.Length - 1;
		} catch(FileNotFoundException) {
			Console.WriteLine("File was not found! Check your path!");
		}
	}
}


