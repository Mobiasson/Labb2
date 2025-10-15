using Game.LevelData;
using Game.Utilities;
using Game.GameLogic;

public class Program {
	static void Main(string[] args) {
		while(true) {
			LevelData levelData = new LevelData();
			levelData.Load("Levels/Level1.txt");
			while(true) {
				if(Console.KeyAvailable) {
					ConsoleKeyInfo key = Console.ReadKey(true);
					int xOffset = 0, yOffset = 0;
					switch(key.Key) {
						case ConsoleKey.UpArrow: yOffset = -1; break;
						case ConsoleKey.DownArrow: yOffset = 1; break;
						case ConsoleKey.LeftArrow: xOffset = -1; break;
						case ConsoleKey.RightArrow: xOffset = 1; break;
						default: continue;
					}
					levelData.Player.Move(xOffset, yOffset, levelData);
					Utility.UpdateType(typeof(Rat), levelData);
					Utility.UpdateType(typeof(Snake), levelData);
					Utility.DrawToolbar(0, levelData.toolBarY + 1, levelData);
					if(levelData.YouSuck) {
						break;
					}
				}
			}
			GameLogic.YouSuck(levelData);
			if(!levelData.YouSuck) {
				continue;
			}
			break;
		}
	}
}
