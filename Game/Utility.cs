#pragma warning disable

namespace Game.Utilities;

using Game.LevelData;

public static class Utility {

	private static HashSet<LevelElement> visibleObjects = new HashSet<LevelElement>();
	private static HashSet<LevelElement> seenWalls = new HashSet<LevelElement>();
	private static List<KeyValuePair<LevelElement, (int X, int Y)>> lastDrawnPositions = new List<KeyValuePair<LevelElement, (int X, int Y)>>();

	public static bool CheckSurrounding(int checkX, int checkY, LevelData levelData) => !levelData.Elements.Any(ele => ele is Wall && ele.X == checkX && ele.Y == checkY);


	public static void ClearCurrentCell(int x, int y) {
		Console.SetCursorPosition(x, y);
		Console.Write(' ');
	}

	public static void UpdateType(Type entityType, LevelData levelData) {
		var elementsCopyList = levelData.Elements.ToList();
		foreach(var ele in elementsCopyList.Where(e => entityType.IsInstanceOfType(e))) {
			((Entity)ele).Update(levelData);
		}
	}
	public static void DrawToolbar(int x, int y, LevelData levelData) {
		Console.SetCursorPosition(x, y);
		if(levelData.Player != null) Console.Write($"Player: {levelData.Player.name} | HP: {levelData.Player.healthPoints} | AttackDice: {levelData.Player.attackDice} | DefenceDice: {levelData.Player.defenceDice} | Turn: {levelData.Player.turn}");
	}

	public static void VisualRange(LevelData levelData) {
		foreach(var ele in levelData.Elements) {
			bool inRange = levelData.Player.IsInVisualRange(ele.X, ele.Y);
			if((ele is Rat or Snake) && !inRange) {
				ClearCurrentCell(ele.X, ele.Y);
				lastDrawnPositions.RemoveAll(p => p.Key == ele);
				continue;
			}
			if(inRange) {
				if((ele is Rat or Snake) && !visibleObjects.Contains(ele)) visibleObjects.Add(ele);
				if(ele is Wall && !seenWalls.Contains(ele)) {
					seenWalls.Add(ele);
					ele.Draw();
					continue;
				}
			}
			if(inRange && ele is (Rat or Snake)) {
				var drawn = lastDrawnPositions.FirstOrDefault(p => p.Key == ele);
				var lastPos = drawn.Value;
				if(drawn.Key == null || lastPos.X != ele.X || lastPos.Y != ele.Y) {
					ClearCurrentCell(lastPos.X, lastPos.Y);
					ele.Draw();
					if(drawn.Key != null) lastDrawnPositions.Remove(drawn);
					lastDrawnPositions.Add(new KeyValuePair<LevelElement, (int, int)>(ele, (ele.X, ele.Y)));
				}
			}
		}
		foreach(var wall in seenWalls) {
			if(!levelData.Elements.Contains(wall)) continue;
			if(!lastDrawnPositions.Any(p => p.Key == wall)) {
				wall.Draw();
				lastDrawnPositions.Add(new KeyValuePair<LevelElement, (int, int)>(wall, (wall.X, wall.Y)));
			}
		}
	}
}
