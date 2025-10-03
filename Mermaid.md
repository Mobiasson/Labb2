# Dungeon Crawler Class Diagram

```mermaid
classDiagram
    class LevelElement {
        +int X
        +int Y
        +char Symbol
        +ConsoleColor Color
        +Draw() void
    }
    class Wall {
        +Symbol = '#'
        +Color = Gray
    }
    class Enemy {
        +string Name
        +int HP
        +Dice AttackDice
        +Dice DefenceDice
        +Update() void
    }
    class Rat {
        +HP = 10
        +AttackDice = 1d6+3
        +DefenceDice = 1d6+1
        +Update() void
    }
    class Snake {
        +HP = 25
        +AttackDice = 3d4+2
        +DefenceDice = 1d8+5
        +Update() void
    }
    class Player {
        +HP = 100
        +AttackDice = 2d6+2
        +DefenceDice = 2d6+0
        +Move() void
    }
    class LevelData {
        -List~LevelElement~ elements
        +Elements : List~LevelElement~ [readonly]
        +Load(string filename) void
    }
    class Dice {
        +int NumberOfDice
        +int SidesPerDice
        +int Modifier
        +Throw() int
        +ToString() string
    }

    LevelElement <|-- Wall
    LevelElement <|-- Enemy
    LevelElement <|-- Player
    Enemy <|-- Rat
    Enemy <|-- Snake
    LevelData o--> "many" LevelElement : contains
    Enemy *--> "2" Dice : uses
    Player *--> "2" Dice : uses
