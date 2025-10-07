using Game.LevelData;
public class Player : LevelElement {

	public Player(int x, int y) {
		X = x;
		Y = y;
		Ch = '@';
		Color = ConsoleColor.White;
	}

	public void MoveUp(LevelData levelData) {
	Y--;
	Clear();
	Draw();
	}

	public void MoveDown(LevelData levelData) {
	Y++;
	Clear();
	Draw();
	}

	public void MoveLeft(LevelData levelData) {
	X--;
	Clear();
	Draw();
	}

	public void MoveRight(LevelData levelData) {
	X++;
	Clear();
	Draw();
	}

	public void Clear() {
		Console.SetCursorPosition(X, Y);
		Console.Write(' ');
	}
}
