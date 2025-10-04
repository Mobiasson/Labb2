class Snake : Enemy {
	public Snake(int x, int y) : base(x, y) {
		name = "Snake";
		Ch = 's';
		Color = ConsoleColor.DarkGreen;
		healthPoints = 25;
		attackDice = new Dice(3, 6, 3);
	}

	public override void Update() {
		throw new NotImplementedException();
	}
}
