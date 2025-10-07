#pragma warning disable CS8618
public abstract class Enemy : LevelElement {
	public Enemy(int x, int y) {
		X = x;
		Y = y;
	}

	Random rnd = new Random();
	public string name { get; set; }
	public int healthPoints { get; set; }
	public Dice attackDice { get; set; }
	public Dice defenceDice { get; set; }

	public abstract void Update();

	public abstract void Move(int x, int y);
}
