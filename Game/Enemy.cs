abstract class Enemy : LevelElement {
	public string name;
	public int healthPoints;
	public Dice attackDice;
	public Dice defenceDice;

	public abstract void Update();
}
