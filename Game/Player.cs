#pragma warning disable CS8602, CS8604

using Game.LevelData;
using Game.Utilities;
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

    public override void Move(int xDirection, int yDirection, LevelData levelData) {
        if (Utility.CheckSurrounding(X + xDirection, Y + yDirection, levelData)) {
            Utility.ClearCurrentCell(X, Y);
            X += xDirection;
            Y += yDirection;
            Draw();
            turn++;
			levelData.DrawVisible();
            Utility.DrawToolbar(0, levelData.toolBarY, levelData);
        }
    }

	public bool IsInVisualRange(int x, int y) {
    	int differenceX = Math.Abs(X - x);
    	int differenceY = Math.Abs(Y - y);
    		return differenceX <= 2 && differenceY <= 2;
	}

    public override void Update(LevelData levelData) {
        throw new NotImplementedException();
    }
}
