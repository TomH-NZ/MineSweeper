# MineSweeper

## Minesweeper For Testing

The purpose of this exercise is to understand how to build the core of a system without any IO.

### Requirements

* A new game should start by specifying the difficulty of the game (all boards are squares)
  - e.g. if board has a difficulty of 4, the board has a width of 4 and a height of 4 and 4 mines
* Mines should be placed randomly
* The board should have two modes of display
  - Only squares revealed by the player are displayed
  - The entire revealed board is displayed
* A player should be able to select the next square to reveal
* If the chosen square is a mine, the game is over and the player loses
  - When the player loses, the entire revealed board is displayed
* If the chosen square is not a mine, that square is revealed with the number of mines that surround it, these number are the hints
* If all of the squares are revealed except mines, the player wins

### Game Flow Example

A new game started with specified difficulty

Input:

`Difficulty: 4`

Output:

Hidden

`....`  
`....`  
`....`  
`....`  

Revealed

`1100`  
`*311`  
`*3*2`  
`122*`  

### Stretch Goals
1. The first player move is guaranteed to not be a mine.
2. Add the ability for a player to flag a grid square as a mine.
3. Add color to individual cells that change depending on the contained character.
