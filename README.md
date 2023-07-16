# Lab 04: Tic-Tac-Toe

**Author:** Mollemira Porphura 

## Overview

This project is a two-person, turn-based Tic-Tac-Toe game implemented in C#. It provides a console-based interface where two players can take turns placing their markers on a 3x3 game board. The goal of the game is to get three markers in a row, either horizontally, vertically, or diagonally, before the opponent does. The game board is displayed after each turn, and the winner or a draw is determined at the end of the game.

## Getting Started

To run the Tic-Tac-Toe game, follow these steps:

1. Clone the repository or download the source code files.
2. Open the project in an IDE or editor that supports C#.
3. Build the solution to ensure all dependencies are resolved.
4. Run the program.
5. Follow the on-screen prompts to play the game.

## Example

Here is an example of how the game may look during play:

Welcome to Tic-Tac-Toe!

|1||2||3|
|4||5||6|
|7||8||9|

Player 1, it's your turn.
Enter the position number (1-9) where you want to place your mark: 5

|1||2||3|
|4||X||6|
|7||8||9|

Player 2, it's your turn.
Enter the position number (1-9) where you want to place your mark: 2

|1||O||3|
|4||X||6|
|7||8||9|

Player 1, it's your turn.
Enter the position number (1-9) where you want to place your mark: 1

|X||O||3|
|4||X||6|
|7||8||9|

Player 2, it's your turn.
Enter the position number (1-9) where you want to place your mark: 3

|X||O||O|
|4||X||6|
|7||8||9|

Player 1, it's your turn.
Enter the position number (1-9) where you want to place your mark: 9

|X||O||O|
|4||X||6|
|7||8||X|

Congratulations Player 1! You won the game.


## Architecture

The project consists of the following classes:

1. `Player`: Represents a player in the game. It holds the player's name and marker.

2. `Game`: Manages the game logic and maintains the state of the game. It handles displaying the game board, validating moves, updating the board with player markers, checking for a winner, and determining if the game is over.

3. `Program`: Contains the entry point of the program and the main game loop.

## Change Log

- Version 1.0.0: Initial release of the Tic-Tac-Toe game.