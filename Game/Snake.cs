class Snake : Enemy {
	public Snake() {
	name = "Snake";
	ch = 's';
	color = ConsoleColor.DarkGreen;
	healthPoints = 25;
	attackDice = new Dice(3, 6, 3);
	}

	public override void Update() {
		throw new NotImplementedException();
	}
}
