namespace Game.Utilities;

using Game.LevelData;

public static class Utility {

	private static readonly HashSet<LevelElement> visibleObjects = new HashSet<LevelElement>();
	private static readonly HashSet<LevelElement> seenWalls = new HashSet<LevelElement>();
	private static readonly Dictionary<LevelElement, (int X, int Y)> lastDrawnPositions = new Dictionary<LevelElement, (int X, int Y)>();

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

	public static void VisualRange(LevelData levelData) {
		foreach(var ele in levelData.Elements) {
			bool inRange = levelData.Player.IsInVisualRange(ele.X, ele.Y);
			if((ele is Rat or Snake) && !inRange) {
				ClearCurrentCell(ele.X, ele.Y);
				lastDrawnPositions.Remove(ele);
				continue;
			}
			if(inRange) {
				if((ele is Rat or Snake) && !visibleObjects.Contains(ele))
					visibleObjects.Add(ele);
				if(ele is Wall && !seenWalls.Contains(ele)) {
					seenWalls.Add(ele);
					ele.Draw();
					continue;
				}
			}
			if(inRange && ele is (Rat or Snake)) {
				if(!lastDrawnPositions.TryGetValue(ele, out var lastPos) || lastPos.X != ele.X || lastPos.Y != ele.Y) {
					ClearCurrentCell(lastPos.X, lastPos.Y);
					ele.Draw();
					lastDrawnPositions[ele] = (ele.X, ele.Y);
				}
			}
		}
		foreach(var wall in seenWalls) {
			if(!levelData.Elements.Contains(wall))
				continue;
			if(!lastDrawnPositions.ContainsKey(wall)) {
				wall.Draw();
				lastDrawnPositions[wall] = (wall.X, wall.Y);
			}
		}
	}
}
