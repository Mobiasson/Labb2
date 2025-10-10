#pragma warning disable CS8602, CS8618

namespace Game.LevelData;

using Game.Utilities;

public class LevelData {
	private List<LevelElement>? elements = new List<LevelElement>();
	public Player Player { get; private set; }
	public IReadOnlyList<LevelElement> Elements => elements.AsReadOnly();
	public int toolBarY;
	private List<(int x, int y)> visibleWalls = new List<(int x, int y)>();
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
			DrawVisible();
			Utility.DrawToolbar(0, lines.Length - 1, this);
		} catch(FileNotFoundException) {
			Console.WriteLine("File was not found! Check your path!");
		}
	}
	public void DrawVisible() {
		Console.Clear();
		foreach(var ele in elements) {
			if(ele == Player) ele.Draw();
			else if(ele is Wall wall && (Player.IsInVisualRange(wall.X, wall.Y) || visibleWalls.Contains((wall.X, wall.Y)))) {
				ele.Draw();
				visibleWalls.Add((wall.X, wall.Y));
			} else if(Player.IsInVisualRange(ele.X, ele.Y)) ele.Draw();
			else Utility.ClearCurrentCell(ele.X, ele.Y);
		}
		Utility.DrawToolbar(0, toolBarY, this);
	}
}




