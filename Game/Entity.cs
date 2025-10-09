#pragma warning disable CS8618
using Game.LevelData;
public abstract class Entity : LevelElement {
	public Entity(int x, int y) {
		X = x;
		Y = y;
	}

	public string name { get; set; }
	public int healthPoints { get; set; }
	public Dice attackDice { get; set; }
	public Dice defenceDice { get; set; }

	public abstract void Move(int xDirection, int yDirection, LevelData levelData);

	public abstract void Update(LevelData levelData);

}
