class Rat : Enemy {
	public Rat(int x, int y) : base(x, y) {
		name = "Rat";
		Ch = 'r';
		Color = ConsoleColor.DarkRed;
		healthPoints = 15;
		attackDice = new Dice(2, 6, 2);
	}


	public override void Update() {
		throw new NotImplementedException();
	}
}
