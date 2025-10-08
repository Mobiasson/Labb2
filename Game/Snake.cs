using Game.LevelData;

public class Snake : Entity {
	public Snake(int x, int y) : base(x, y) {
		name = "Snake";
		Ch = 's';
		Color = ConsoleColor.DarkGreen;
		healthPoints = 25;
		attackDice = new Dice(3, 6, 3);
	}

	public override void Update(LevelData levelData) {
	Random rnd = new Random();
	if(healthPoints <= 0) Console.WriteLine("DEAD");
	int direction = rnd.Next(4);
	int newX = X; int newY = Y;
	switch (direction){
			case 0: newY--; break;
			case 1: newY++; break;
			case 2: newX--; break;
			case 3: newX++; break;
		}
	}

}
