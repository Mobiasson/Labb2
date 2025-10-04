#pragma warning disable CS8618
abstract class Enemy : LevelElement {
	public Enemy(int x, int y) {
		X = x;
		Y = y;
	}

	public string name { get; set; }
	public int healthPoints { get; set; }
	public Dice attackDice { get; set; }
	public Dice defenceDice { get; set; }

	public abstract void Update();
}
