#pragma warning disable CS8602

namespace Game.LevelData;
public class LevelData {
	private List<LevelElement>? elements = new List<LevelElement>();
	public (double x, double y) playerStartPos { get; private set; }
	readonly List<LevelElement>? Elements;

	public void Load(string fileName) {
		try {
			string[] lines = File.ReadAllLines(fileName);
			for(int y = 0; y < lines.Length; y++) {
				string line = lines[y];
				for(int x = 0; x < line.Length; x++) {
					char ch = line[x];
					if(ch == '#') {
						elements.Add(new Wall(x, y));
					} else if(ch == 'r') {
						elements.Add(new Rat(x, y));
					} else if(ch == 's') {
						elements.Add(new Snake(x, y));
					}
				}
			}
		} catch(FileNotFoundException) {
			Console.WriteLine("File was not found! Check your path!");
		}
	}
	public void PrintElements() {
		elements.ForEach(e => Console.WriteLine($"Type: {e.GetType().Name}, Char: {e.Ch}, X: {e.Y}, Y: {e.Y}"));
		Console.WriteLine($"Player Start Position: ({playerStartPos.x}, {playerStartPos.y})");
	}
}
