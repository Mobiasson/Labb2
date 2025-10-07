using Game.LevelData;
public class Player : LevelElement {

	public Player(int x, int y) {
		X = x;
		Y = y;
		Ch = '@';
		Color = ConsoleColor.White;
	}

	public void MoveUp(LevelData levelData) {
	ClearCurrentCell();
	Y--;
	Draw();
	}

	public void MoveDown(LevelData levelData) {
	ClearCurrentCell();
	Y++;
	Draw();
	}

	public void MoveLeft(LevelData levelData) {
	ClearCurrentCell();
	X--;
	Draw();
	}

	public void MoveRight(LevelData levelData) {
	ClearCurrentCell();
	X++;
	Draw();
	}

	public void ClearCurrentCell() {
		Console.SetCursorPosition(X, Y);
		Console.Write(' ');
	}
}
