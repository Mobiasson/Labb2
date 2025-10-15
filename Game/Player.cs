using Game.LevelData;
using Game.GameLogic;
using Game.Utilities;

public class Player : Entity {
	public int turn = 0;

	public Player(int x, int y) : base(x, y) => (ch, name, healthPoints, attackDice, defenceDice, color) = ('@', "Player", 100, new Dice(2, 6, 2), new Dice(2, 6, 0), ConsoleColor.White);

	public override void Move(int xDirection, int yDirection, LevelData levelData) {
		if(GameLogic.IsCombatActive()) return;
		int newX = X + xDirection, newY = Y + yDirection;
		if(!Utility.CheckSurrounding(newX, newY, levelData)) return;
		Utility.ClearCurrentCell(X, Y);
		(X, Y) = (newX, newY);
		turn++;
		Draw();
		Utility.VisualRange(levelData);
		Update(levelData);
	}

	public bool IsInVisualRange(int x, int y) {
		int differenceX = Math.Abs(X - x);
		int differenceY = Math.Abs(Y - y);
		return differenceX <= 5 && differenceY <= 5;

	}

	public override void Update(LevelData levelData) {
		foreach(var entity in levelData.Elements.Where(e => e is (Rat or Snake) && e != this)) {
			int dx = Math.Abs(X - entity.X);
			int dy = Math.Abs(Y - entity.Y);
			if((dx == 0 && dy == 0) || (dx == 0 && dy == 0)) {
				GameLogic.Combat(this, entity as Entity, levelData, true);
				break;
			}
		}
	}
}
