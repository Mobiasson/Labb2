public class Program
{
    static void Main(string[] args)
    {
   		//LevelData levelData = new LevelData();
	 	// levelData.Load("Levels/Level1.txt");

		Dice dice = new Dice(2, 6, 2);
		Console.WriteLine(dice.ToString());
    }
}
