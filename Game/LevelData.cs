#pragma warning disable CS8602, CS8618

namespace Game.LevelData;
using Game.Utilities;

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
						Console.SetCursorPosition(x, y);
						Console.Write(' ');
					}
				}
			}
			Console.Clear();
			toolBarY = lines.Length - 1;
			Utility.DrawToolbar(0, toolBarY, this);
		} catch(FileNotFoundException) {
			Console.WriteLine("File was not found! Check your path!");
		}
	}
}
