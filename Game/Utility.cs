namespace Game.Utilities;

using Game.LevelData;

public static class Utility {

	public static bool CheckSurrounding(int checkX, int checkY, LevelData levelData) {
		return !levelData.Elements.Any(ele => ele is Wall && ele.X == checkX && ele.Y == checkY);
	}

	public static void ClearCurrentCell(int x, int y) {
		Console.SetCursorPosition(x, y);
		Console.Write(' ');
	}

	public static void UpdateType(Type entityType, LevelData levelData) {
		if(entityType == null || !typeof(Entity).IsAssignableFrom(entityType)) return;
		foreach(var ele in levelData.Elements.Where(e => entityType.IsInstanceOfType(e))) {
			((Entity)ele).Update(levelData);
		}
	}

	public static void DrawToolbar(int x, int y, LevelData levelData) {
		Console.SetCursorPosition(x, y);
		if(levelData.Player != null) Console.Write($"Player: {levelData.Player.name} | HP: {levelData.Player.healthPoints} | AttackDice: {levelData.Player.attackDice} Turn: {levelData.Player.turn}");
		else Console.Write("Player: Not found");
	}

}
