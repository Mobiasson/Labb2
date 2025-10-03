# Dungeon Crawler - Labb 2

## Översikt
I den här inlämningen ska vi skapa ett spel i form av ett **dungeon crawler** i C#. Spelet går ut på att utforska en labyrint, bekämpa fiender och kunna navigera runt sig.

## Spelbeskrivning
- **Bana**: En labyrint ("dungeon") definierad i `Level1.txt` med väggar, en spelarstartposition och två typer av monster ("rats" och "snakes").
- **Mål**: Läsa in filen och skapa objekt för väggar, spelare och fiender. Objekten ska vara oberoende och hantera sina egna data och metoder.

## Krav
- **Data**:
  - **Position**: Var objektet befinner sig på banan.
  - **Färg**: Visuell representation för konsolen.
  - **Hälsa**: För spelare och fiender.
- **Metoder**:
  - Förflyttning av objekt.
  - Attackfunktioner för spelare och fiender.

## Tekniska detaljer
- **Språk**: C#
- **Inläsning**: Läser in `Level1.txt` för att skapa spelvärlden.
- **Objektorientering**: Objekt (t.ex. spelare, fiender, väggar) ska vara självständiga med egna attribut och metoder.

## Uppgift
Skriv kod som:
1. Läser in och tolkar `Level1.txt`.
2. Skapar objekt för spelare, fiender och väggar.
3. Hanterar objektens data (position, färg, hälsa) och beteenden (förflyttning, attacker).

## Extra
- Lägg till items, vapen, föremål och sätt att återställa HP.

## Overview of relationships
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
