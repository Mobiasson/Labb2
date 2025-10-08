#pragma warning disable CS8602, CS8604

using Game.LevelData;
public class Player : Entity {

	public int turn = 0;

	public Player(int x, int y) : base(x, y) {
		Ch = '@';
		name = "Player";
		healthPoints = 100;
		attackDice = new Dice(2, 6, 2);
		defenceDice = new Dice(1, 6, 1);
		Color = ConsoleColor.White;
	}

	public void Move(int xDirection, int yDirection, LevelData levelData) {
    if (CheckSurrounding(X + xDirection, Y + yDirection, levelData)) {
        ClearCurrentCell();
        X += xDirection;
        Y += yDirection;
        Draw();
		turn++;
		levelData.DrawToolbar(0, levelData.toolBarY);
    }
}

	// public void MoveUp(LevelData levelData) {
	// if(CheckSurrounding(X, Y - 1, levelData)) {
	// ClearCurrentCell();
	// Y -= 1;
	// Draw();
	// levelData.Player.turn++;
	// 	}
	// }

	// public void MoveDown(LevelData levelData) {
	// if(CheckSurrounding(X, Y + 1, levelData)) {
	// 	ClearCurrentCell();
	// Y += 1;
	// Draw();
	// 	}
	// }

	// public void MoveLeft(LevelData levelData) {
	// if(CheckSurrounding(X - 1, Y, levelData)) {
	// ClearCurrentCell();
	// X -= 1;
	// Draw();
	// 	}
	// }

	// public void MoveRight(LevelData levelData) {
	// if(CheckSurrounding(X + 1, Y, levelData)) {
	// ClearCurrentCell();
	// X += 1;
	// Draw();
	// 	}
	// }

	public void ClearCurrentCell() {
	Console.SetCursorPosition(X, Y);
	Console.Write(' ');
	}

	public override void Update(LevelData levelData) {
		throw new NotImplementedException();
	}

}
