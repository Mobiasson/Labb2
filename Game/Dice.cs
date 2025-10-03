class Dice {
	readonly static Random rnd = new Random();
	public int numberOfDice = rnd.Next(2);
	public int sidesPerDice = rnd.Next(1, 6);
	public int modifier = 2;

	public Dice(int numberOfDice, int sidesPerDice, int modifier) {
		this.numberOfDice = numberOfDice;
		this.sidesPerDice = sidesPerDice;
		this.modifier = modifier;
	}

	public int Throw() {
		return numberOfDice + sidesPerDice;
	}

	public override string? ToString() {
		return $"{numberOfDice}d{sidesPerDice}+{modifier}";
	}
}
