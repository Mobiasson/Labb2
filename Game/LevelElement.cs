using Game.LevelData;
public abstract class LevelElement {
	public int X { get; set; }
	public int Y { get; set; }
	public char ch { get; set; }
	public ConsoleColor color { get; set; }
	LevelData levelData = new LevelData();

	public void Draw() {
		Console.SetCursorPosition(X, Y);
		Console.ForegroundColor = color;
		Console.Write(ch);
		Console.ResetColor();
	}

}
