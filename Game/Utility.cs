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

	public static void GetType(Type entityType, LevelData levelData) {
    	if (entityType == null || !typeof(Entity).IsAssignableFrom(entityType)) return;
    	foreach (var ele in levelData.Elements.Where(e => entityType.IsInstanceOfType(e))) {
        	((Entity)ele).Update(levelData);
		}
	}
}
