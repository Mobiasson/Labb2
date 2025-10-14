namespace Game.GameLogic;
using Game.LevelData;
using Game.Utilities;

public static class GameLogic {
	private static readonly List<string> combatLog = new();
	private static int logIndex = 0;
	private const int MaxLogLines = 10;
	private static bool isCombatActive = false;

	public static bool IsMoving(Entity mover, int x, int y, LevelData levelData, bool playerInitiated) =>
		levelData.Elements.Any(ele => ele is (Rat or Snake or Player) && ele != mover && ele.X == x && ele.Y == y) &&
		Combat(mover, levelData.Elements.Single(ele => ele is (Rat or Snake or Player) && ele != mover && ele.X == x && ele.Y == y) as Entity, levelData, playerInitiated);

	public static bool Combat(Entity attacker, Entity defender, LevelData levelData, bool playerInitiated) {
		ClearCombatLog();
		isCombatActive = true;
		int turn = 1;
		while(attacker.healthPoints > 0 && defender.healthPoints > 0) {
			int attackScore = attacker.attackDice.ThrowDice();
			int defenseScore = defender.defenceDice.ThrowDice();
			combatLog.Add($"TURN: {turn}");
			combatLog.Add($"ATTACKER: {attacker.name} HP: {attacker.healthPoints}");
			combatLog.Add($"{attacker.name} attackRolled {attackScore}");
			combatLog.Add($"{defender.name} defenceRolled {defenseScore}");
			if(attackScore > defenseScore) {
				int damage = attackScore - defenseScore;
				defender.healthPoints -= damage;
				combatLog.Add($"{attacker.name} dealt {damage} damage");
			}
			if(defender.healthPoints <= 0) {
				combatLog.Add($"{defender.name} died");
				break;
			}
			attackScore = defender.attackDice.ThrowDice();
			defenseScore = attacker.defenceDice.ThrowDice();
			combatLog.Add($"DEFENDER: {defender.name} HP: {defender.healthPoints}");
			combatLog.Add($"{defender.name} attackRolled {attackScore}");
			combatLog.Add($"{attacker.name} defenceRolled {defenseScore}");
			if(attackScore > defenseScore) {
				int damage = attackScore - defenseScore;
				attacker.healthPoints -= damage;
				combatLog.Add($"{defender.name} dealt {damage} damage");
			}
			if(attacker.healthPoints <= 0) {
				combatLog.Add($"{attacker.name} died");
				break;
			}
			turn++;
			DisplayAndWait(levelData);
			ClearCombatLog();
		}
if (attacker.healthPoints <= 0 || defender.healthPoints <= 0)
{
    if (defender is Player && defender.healthPoints <= 0) YouSuck(levelData);
    else if (attacker.healthPoints <= 0 && levelData.RemoveElement(attacker)) Utility.ClearCurrentCell(attacker.X, attacker.Y);
    else if (defender.healthPoints <= 0 && levelData.RemoveElement(defender)) Utility.ClearCurrentCell(defender.X, defender.Y);
    DisplayAndWait(levelData);
}
		isCombatActive = false;
		return attacker.healthPoints > 0 || defender.healthPoints > 0;
	}

	private static void DisplayAndWait(LevelData levelData) {
		CombatLog(0, levelData.toolBarY + 5, levelData);
		Console.ReadKey(true);
			}

	public static void CombatLog(int x, int y, LevelData levelData) {
		int maxLines = Math.Min(MaxLogLines, Console.WindowHeight - y);
		int startIndex = Math.Max(0, combatLog.Count - maxLines);
		for(int i = 0; i < maxLines; i++) {
			int line = y + i;
			if(line < Console.WindowHeight) {
				Console.SetCursorPosition(x, line);
				Console.Write(new string(' ', Console.WindowWidth - x));
			}
		}
		for(int i = startIndex; i < combatLog.Count; i++) {
			int line = y + (i - startIndex);
			if(line < Console.WindowHeight) {
				Console.SetCursorPosition(x, line);
				Console.Write(combatLog[i]);
			}
		}
	}

	public static void ClearCombatLog() {
		combatLog.Clear();
		logIndex = 0;
	}

	public static void YouSuck(LevelData levelData) {
		ClearCombatLog();
		combatLog.Add("Game Over");
		levelData.GameOver = true;
		CombatLog(0, levelData.toolBarY + 5, levelData);
		Console.ReadKey(true);
		for(int i = 0; i < MaxLogLines; i++) {
			int line = levelData.toolBarY + 5 + i;
			if(line < Console.WindowHeight) {
				Console.SetCursorPosition(0, line);
				Console.Write(new string(' ', Console.WindowWidth));
			}
		}
		ClearCombatLog();
	}

	public static bool IsCombatActive() => isCombatActive;
}
