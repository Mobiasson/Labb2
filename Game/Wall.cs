class Wall : LevelElement {
	public char wall = '#';
	public ConsoleColor color = ConsoleColor.Gray;

	public Wall(char wall, ConsoleColor color) {
		this.wall = wall;
		this.color = color;
	}
}
