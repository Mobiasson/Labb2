#pragma warning disable CS8602, CS8618

namespace Game.LevelData;

public class LevelData {
	private List<LevelElement>? elements = new List<LevelElement>();
	public Player Player { get; private set; }
	public IReadOnlyList<LevelElement> Elements => elements.AsReadOnly();
	public int toolBarY;
	public void Load(string fileName) {
		try {
			string[] lines = File.ReadAllLines(fileName);
			Console.CursorVisible = false;
			for(int y = 0; y < lines.Length; y++) {
				string line = lines[y];
				for(int x = 0; x < line.Length; x++) {
					char ch = line[x];
					if(ch.Equals('#')) {
						elements.Add(new Wall(x, y));
					} else if(ch.Equals('r')) {
						elements.Add(new Rat(x, y));
					} else if(ch.Equals('s')) {
						elements.Add(new Snake(x, y));
					} else if(ch.Equals('@')) {
						Player = new Player(x, y);
						elements.Add(Player);
					} else if(ch.Equals(' ')) {
						Console.SetCursorPosition(x, y); Console.Write(' ');
					}
				}
			}
			toolBarY = lines.Length - 1;
			DrawToolbar(0, lines.Length - 1);
			elements.ForEach(ele => ele.Draw());
		} catch(FileNotFoundException) {
			Console.WriteLine("File was not found! Check your path!");
		}
	}
	public void DrawToolbar(int x, int y) {
		Console.SetCursorPosition(x, y);
		if(Player != null) Console.Write($"Player: {Player.name} | HP: {Player.healthPoints} | AttackDice: {Player.attackDice} Turn: {Player.turn}");
		else Console.Write("Player: Not found");
	}
}



