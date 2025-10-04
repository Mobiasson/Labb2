abstract class LevelElement {
	public int X { get; set; }
	public int Y { get; set; }
	public char Ch { get; set; }
	public ConsoleColor Color { get; set; }


	public void Draw() {
	Console.SetCursorPosition(X, Y);
	Console.Write(Ch);
	}
}
