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
				player.Move(0, -1, levelData);
				foreach (var entity in levelData.Elements.OfType<Rat>()) {
                entity.Update(levelData);
        			}
				}
				if(key.Key == ConsoleKey.DownArrow) {
				player.Move(0, +1, levelData);
				}
				if(key.Key == ConsoleKey.LeftArrow) {
				player.Move(-1, 0, levelData);
				}
				if(key.Key == ConsoleKey.RightArrow){
				player.Move(+1, 0, levelData);
				}
			}
		}
	}
}
