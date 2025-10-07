#pragma warning disable CS8602
using Game.LevelData;
public class Program {
	static void Main(string[] args) {
		LevelData levelData = new LevelData();
		levelData.Load("Levels/Level1.txt");

		Player? player = levelData.Player;


		while (true) {
			if(Console.KeyAvailable) {
 			ConsoleKeyInfo key = Console.ReadKey(true);
				if(key.Key == ConsoleKey.UpArrow) {
				player.MoveUp(levelData);
				}
				if(key.Key == ConsoleKey.DownArrow) {
				player.MoveDown(levelData);
				}
				if(key.Key == ConsoleKey.LeftArrow) {
				player.MoveLeft(levelData);
				}
				if(key.Key == ConsoleKey.RightArrow){
				player.MoveRight(levelData);
				}
			}
		}
	}

}
