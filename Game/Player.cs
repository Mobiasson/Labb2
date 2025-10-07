#pragma warning disable CS8602, CS8604

using Game.LevelData;
public class Player : LevelElement {

	public Player(int x, int y) {
		X = x;
		Y = y;
		Ch = '@';
		Color = ConsoleColor.White;
	}

	public void MoveUp(LevelData levelData) {
	if(CheckSurrounding(X, Y - 1, levelData)) {
	ClearCurrentCell();
	Y -= 1;
	Draw();
		}
	}

	public void MoveDown(LevelData levelData) {
	if(CheckSurrounding(X, Y + 1, levelData)) {
		ClearCurrentCell();
	Y += 1;
	Draw();
		}
	}

	public void MoveLeft(LevelData levelData) {
	if(CheckSurrounding(X - 1, Y, levelData)) {
	ClearCurrentCell();
	X -= 1;
	Draw();
		}
	}

	public void MoveRight(LevelData levelData) {
	if(CheckSurrounding(X + 1, Y, levelData)) {
	ClearCurrentCell();
	X += 1;
	Draw();
		}
	}

	public void ClearCurrentCell() {
	Console.SetCursorPosition(X, Y);
	Console.Write(' ');
	}

	public bool CheckSurrounding(int checkX, int checkY, LevelData levelData) {
	return !levelData.Elements.Any(ele => ele is Wall && ele.X == checkX && ele.Y == checkY);
	}
}
