public class Dice {
	private int numberOfDice, sidesPerDice, modifier;

	public Dice(int numberOfDice, int sidesPerDice, int modifier) =>
		(this.numberOfDice, this.sidesPerDice, this.modifier) = (numberOfDice, sidesPerDice, modifier);

	public int ThrowDice() =>
		Enumerable.Range(0, numberOfDice).Sum(_ => Random.Shared.Next(1, sidesPerDice + 1)) + modifier;

	public override string ToString() => $"{numberOfDice}d{sidesPerDice}+{modifier}";
}
