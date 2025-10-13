#pragma warning disable CS8602, CS8618
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
		combatLog.Add($"{attacker.name} started combat with {defender.name}.");
		bool result = CombatLogic(attacker, defender, levelData);
		if(defender.healthPoints > 0) result |= CombatLogic(defender, attacker, levelData);
		return result;
	}

	public static bool CombatLogic(Entity attacker, Entity defender, LevelData levelData) {
		int attackScore = attacker.attackDice.ThrowDice(), defenseScore = defender.defenceDice.ThrowDice();
		combatLog.Add($"{attacker.name ?? attacker.GetType().Name} attacked {defender.name ?? defender.GetType().Name} for {attackScore} (roll)");
		combatLog.Add($"{defender.name ?? defender.GetType().Name} defended with {defenseScore} (roll)");
		if(attackScore <= defenseScore) return false;
		int damage = attackScore - defenseScore;
		defender.healthPoints -= damage;
		combatLog.Add($"{attacker.name ?? attacker.GetType().Name} dealt {damage} damage to {defender.name ?? defender.GetType().Name} (HP: {defender.healthPoints})");
		// if (defender.healthPoints <= 0)
		// {
		//     combatLog.Add($"{defender.name ?? defender.GetType().Name} died");
		//     if (defender is Player) GameOver(levelData);
		//     else if (levelData.RemoveElement(defender)) Utility.ClearCurrentCell(defender.X, defender.Y);
		// }
		return true;
	}

	public static void CombatLog(int x, int y, LevelData levelData) {
		if(levelData.Player == null || combatLog.Count == 0) return;
		Console.SetCursorPosition(x, y);
		Console.Write(new string(' ', Console.WindowWidth - x));
		Console.SetCursorPosition(x, y);
		Console.Write(combatLog[Math.Min(logIndex, combatLog.Count - 1)]);
		logIndex = (logIndex + 1) % Math.Max(1, combatLog.Count);
	}

	// public static void GameOver(LevelData levelData)
	// {
	//     combatLog.Add("Game Over");
	//     levelData.GameOver = true;
	//     CombatLog(0, levelData.combatLogY, levelData);
	// }
}
