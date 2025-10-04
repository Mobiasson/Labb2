class Rat : Enemy {
	public Rat() {
		name = "Rat";
		ch = 's';
		color = ConsoleColor.DarkRed;
		healthPoints = 15;
		attackDice = new Dice(2, 6, 2);
	}

	public override void Update() {
		throw new NotImplementedException();
	}
}
