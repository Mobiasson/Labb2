#pragma warning disable CS8602

public class LevelData {
	private List<LevelElement>? elements = new List<LevelElement>();
	public (double x, double y) playerStartPos {get; private set;}
	readonly List<LevelElement>? Elements;

	public void Load(string fileName) {
		try {
		string[] lines = File.ReadAllLines(fileName); // Read line by line
            for (int y = 0; y < lines.Length; y++) {
                string line = lines[y];
                for (int x = 0; x < line.Length; x++) {
                    char ch = line[x];
				if(ch == '#') {
				elements.Add(new Wall());
				}
				else if (ch == 'r') {
					elements.Add(new Rat());
				}
				else if (ch == 's') {
					elements.Add(new Snake());
				}
				Console.Write(ch); //for testing
			}
			Console.WriteLine();
		}
		} catch(FileNotFoundException) {
			Console.WriteLine("File was not found! Check your path!");
		}
	}
public void PrintElements() {
        elements.ForEach(e => Console.WriteLine($"Type: {e.GetType().Name}, Char: {e.ch}, X: {e.x}, Y: {e.y}"));
        Console.WriteLine($"Player Start Position: ({playerStartPos.x}, {playerStartPos.y})");
    }}
