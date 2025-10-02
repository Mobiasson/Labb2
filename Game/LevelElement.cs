abstract class LevelElement {
	private double x;
	private double y;
	private char[]? ch;
	ConsoleColor color;

	public double X { get => x; set => x = value; }
	public double Y { get => y; set => y = value; }
	public char[] Ch { get => ch; set => ch = value; }
	public ConsoleColor Color { get => color; set => color = value; }

	public void Draw() {

	}
}
