using Game.LevelData;
using Game.Utilities;
public class Snake : Entity {

	public Snake(int x, int y) : base(x, y) => (name, ch, color, healthPoints, attackDice, defenceDice) = ("Snake", 's', ConsoleColor.DarkGreen, 25, new Dice(3, 6 ,3), new Dice(2, 2, 2));

	public override void Move(int xDirection, int yDirection, LevelData levelData) {
		int distance = (int)Math.Sqrt(Math.Pow((Y - levelData.Player.Y), 2) + Math.Pow((X - levelData.Player.X), 2));
		if(distance >= 2) return;
		int checkX = X + (X - levelData.Player.X);
		int checkY = Y + (Y - levelData.Player.Y);
		if(Utility.CheckSurrounding(checkX, checkY, levelData)) {
			Utility.ClearCurrentCell(X, Y);
			X = checkX;
			Y = checkY;
			Utility.VisualRange(levelData);
		}
	}
	public override void Update(LevelData levelData) {
		if(healthPoints <= 0) Console.WriteLine("DEAD");
		Move(X, Y, levelData);
	}
}
