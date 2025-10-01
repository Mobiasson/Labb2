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
