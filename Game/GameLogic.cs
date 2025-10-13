#pragma warning disable
namespace Game.GameLogic;

using Game.LevelData;
using Game.Utilities;

public static class GameLogic {
	private static readonly List<string> combatLog = new();
	private static int logIndex = 0;

	public static bool IsMoving(Entity mover, int x, int y, LevelData levelData, bool playerInitiated) =>
		levelData?.Elements != null &&
		levelData.Elements.Any(ele => ele is (Rat or Snake or Player) && ele != mover && ele.X == x && ele.Y == y) &&
		Combat(mover, levelData.Elements.Single(ele => ele is (Rat or Snake or Player) && ele != mover && ele.X == x && ele.Y == y) as Entity, levelData, playerInitiated);

	public static bool Combat(Entity attacker, Entity defender, LevelData levelData, bool playerInitiated) {
		combatLog.Add($"{attacker.name} started combat with {defender.name ?? defender.GetType().Name}.");
		bool result = false;
		int attackScore = attacker.attackDice.ThrowDice(), defenseScore = defender.defenceDice.ThrowDice();
		combatLog.Add($"{attacker.name} attacked {defender.name} for {attackScore} (roll)");
		combatLog.Add($"{attacker.name} rolled a {attacker.attackDice.ToString()}");
		combatLog.Add($"{defender.name} defended with {defenseScore} (roll)");
		if(attackScore > defenseScore) {
			int damage = attackScore - defenseScore;
			defender.healthPoints -= damage;
			combatLog.Add($"{attacker.name} dealt {damage} damage to {defender.name} (HP: {defender.healthPoints})");
			result = true;
		}
		if (defender.healthPoints <= 0)
		{
		    combatLog.Add($"{defender.name} died");
		    if (defender is Player) YouSuck(levelData);
		    else if (levelData.RemoveElement(defender)) Utility.ClearCurrentCell(defender.X, defender.Y);
		}
		if(defender.healthPoints > 0) {
			attackScore = defender.attackDice.ThrowDice();
			defenseScore = attacker.defenceDice.ThrowDice();
			combatLog.Add($"{defender.name} attacked {attacker.name} for {attackScore} (roll)");
			combatLog.Add($"{attacker.name} defended with {defenseScore} (roll)");
			if(attackScore > defenseScore) {
				int damage = attackScore - defenseScore;
				attacker.healthPoints -= damage;
				combatLog.Add($"{defender.name} dealt {damage} damage to {attacker.name} (HP: {attacker.healthPoints})");
				result = true;
			}
			if (attacker.healthPoints <= 0)
			{
			    combatLog.Add($"{attacker.name ?? attacker.GetType().Name} died");
			    if (attacker is Player) YouSuck(levelData);
			    else if (levelData.RemoveElement(attacker)) Utility.ClearCurrentCell(attacker.X, attacker.Y);
			}
		}

		return result;
	}

	public static void CombatLog(int x, int y, LevelData levelData) {
		if(levelData.Player == null || combatLog.Count == 0) return;
		for(int i = 0; i < combatLog.Count; i++) {
			Console.SetCursorPosition(x, y + i);
			Console.Write(new string(' ', Console.WindowWidth - x));
			Console.SetCursorPosition(x, y + i);
			Console.Write(combatLog[i]);
		}
	}

	public static void ClearCombatLog() {
		combatLog.Clear();
		logIndex = 0;
	}

	public static void YouSuck(LevelData levelData)
	{
	    combatLog.Add("You suck!");
	    levelData.GameOver = true;
	    CombatLog(0, levelData.toolBarY + 1, levelData);
	}
}
