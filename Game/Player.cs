#pragma warning disable

using Game.LevelData;
using Game.GameLogic;
using Game.Utilities;

public class Player : Entity {
	public int turn = 0;

	public Player(int x, int y) : base(x, y) => (ch, name, healthPoints, attackDice, defenceDice, color) = ('@', "Player", 100, new Dice(2, 6, 2), new Dice(2, 6, 0), ConsoleColor.White);

	public override void Move(int xDirection, int yDirection, LevelData levelData) {
		int newX = X + xDirection, newY = Y + yDirection;
		if(levelData?.Elements == null || newX < 0 || newX >= Console.WindowWidth || newY < 0 || newY >= Console.WindowHeight ||
			!Utility.CheckSurrounding(newX, newY, levelData))
			return;
		if(GameLogic.IsMoving(this, newX, newY, levelData, true)) {
			GameLogic.CombatLog(0, levelData.toolBarY + 5, levelData);
			return;
		}
		for(int i = 0; i < 10; i++) {
			Console.SetCursorPosition(0, levelData.toolBarY + 5 + i);
			Console.Write(new string(' ', Console.WindowWidth));
		}
		GameLogic.ClearCombatLog();
		Utility.ClearCurrentCell(X, Y);
		(X, Y, turn) = (newX, newY, turn + 1);
		Draw();
		Utility.VisualRange(levelData);
	}

	public bool IsInVisualRange(int x, int y) {
		int differenceX = Math.Abs(X - x);
		int differenceY = Math.Abs(Y - y);
		return differenceX <= 5 && differenceY <= 5;
	}

	public override void Update(LevelData levelData) {
		throw new NotImplementedException();
	}
}
