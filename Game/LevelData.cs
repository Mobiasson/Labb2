#pragma warning disable CS8602

public class LevelData {
	private List<LevelElement>? elements;
	readonly List<LevelElement>? Elements;

	public void Load(string fileName) {
		try {
			using StreamReader sr = new StreamReader(fileName);
			string content = sr.ReadToEnd();
			foreach(char ch in content) {
				if(ch == '#') {

				}
				Console.Write(ch);
			}
			Console.WriteLine();
		} catch(FileNotFoundException) {
			Console.WriteLine("File was not found! Check your path!");
		}
	}
}
