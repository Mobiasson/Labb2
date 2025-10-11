#pragma warning disable CS0108
public class Wall : LevelElement {
	public Wall(int x, int y) {
		X = x;
		Y = y;
		ch = '#';
		color = ConsoleColor.Gray;
	}

}
