using Game.LevelData;
using Game.Utilities;
public class Rat : Entity {

	private Random rnd = new Random();

	public Rat(int x, int y) : base(x, y) {
		name = "Rat";
		Ch = 'r';
		Color = ConsoleColor.DarkRed;
		healthPoints = 15;
		attackDice = new Dice(2, 6, 2);
	}

	public override void Move(int xDirection, int yDirection, LevelData levelData) {
		(int x, int y)[] directions = { (0, -1), (0, 1), (-1, 0), (1, 0), (0, 0) };
		var direction = directions[rnd.Next(0, directions.Length)];
		int checkX = X + direction.x;
		int checkY = Y + direction.y;
		if(Utility.CheckSurrounding(checkX, checkY, levelData)) {
			Utility.ClearCurrentCell(X, Y);
			X = checkX;
			Y = checkY;
			Draw();
		}
	}

	public override void Update(LevelData levelData) {
		if(healthPoints <= 0) Console.WriteLine("A DEAD RAT IS A GOOD RAT");
		Move(X, Y, levelData);
	}

}
