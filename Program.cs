using System;

namespace Lab04_TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            StartGame();
        }

        static void StartGame()
        {
            // Initializes players and the game object, and manages the game loop.
            Player player1 = new Player("Player 1", "X");
            Player player2 = new Player("Player 2", "O");
            Game game = new Game(player1, player2);

            Console.WriteLine("Welcome to Tic-Tac-Toe!");
            game.DisplayBoard();

            while (!game.IsGameOver())
            {
                Player currentPlayer = game.GetCurrentPlayer();
                Console.WriteLine($"{currentPlayer.Name}, it's your turn.");
                Console.Write("Enter the position number (1-9) where you want to place your mark: ");
                int position = Convert.ToInt32(Console.ReadLine());

                if (game.IsValidMove(position))
                {
                    game.MakeMove(position);
                    game.DisplayBoard();
                    game.SwitchPlayer();
                }
                else
                {
                    Console.WriteLine("Invalid move. Please try again.");
                }
            }

            if (game.HasWinner())
            {
                Player winner = game.GetWinner();
                Console.WriteLine($"Congratulations {winner.Name}! You won the game.");
            }
            else
            {
                Console.WriteLine("It's a draw. No winner.");
            }
        }
    }

    class Player
    {
        public string Name { get; }
        public string Marker { get; }

        public Player(string name, string marker)
        {
            // Initializes a player with the given name and marker.
            Name = name;
            Marker = marker;
        }
    }

    class Game
    {
        private Player[] players;
        private Player currentPlayer;
        private string[] board;

        public Game(Player player1, Player player2)
        {
            // Initializes the game with the given players and sets up the initial game board.
            players = new Player[] { player1, player2 };
            currentPlayer = player1;
            board = new string[9];
            for (int i = 0; i < 9; i++)
            {
                board[i] = (i + 1).ToString();
            }
        }

        /// Displays the current state of the game board.
        public void DisplayBoard()
        {
            Console.WriteLine();
            Console.WriteLine($"|{board[0]}||{board[1]}||{board[2]}|");
            Console.WriteLine($"|{board[3]}||{board[4]}||{board[5]}|");
            Console.WriteLine($"|{board[6]}||{board[7]}||{board[8]}|");
            Console.WriteLine();
        }

        /// Retrieves the current player.
        public Player GetCurrentPlayer()
        {
            return currentPlayer;
        }

        /// Switches the current player to the other player.
        public void SwitchPlayer()
        {
            currentPlayer = (currentPlayer == players[0]) ? players[1] : players[0];
        }

        /// Checks if a move is valid at the given position.
        public bool IsValidMove(int position)
        {
            return board[position - 1] != "X" && board[position - 1] != "O";
        }

        /// Updates the game board with the current player's marker at the given position.
        public void MakeMove(int position)
        {
            board[position - 1] = currentPlayer.Marker;
        }

        /// Checks if the game is over (either a winner or a draw).
        public bool IsGameOver()
        {
            return HasWinner() || IsBoardFull();
        }

        /// Checks if there is a winner.
        public bool HasWinner()
        {
            // Check rows
            for (int i = 0; i < 9; i += 3)
            {
                if (board[i] == board[i + 1] && board[i] == board[i + 2])
                    return true;
            }

            // Check columns
            for (int i = 0; i < 3; i++)
            {
                if (board[i] == board[i + 3] && board[i] == board[i + 6])
                    return true;
            }

            // Check diagonals
            if ((board[0] == board[4] && board[0] == board[8]) ||
                (board[2] == board[4] && board[2] == board[6]))
                return true;

            return false;
        }

        /// Checks if the game board is full.
        public bool IsBoardFull()
        {
            foreach (string position in board)
            {
                if (position != "X" && position != "O")
                    return false;
            }
            return true;
        }

        /// Retrieves the winning player (if any).
        public Player GetWinner()
        {
            for (int i = 0; i < 9; i += 3)
            {
                if (board[i] == board[i + 1] && board[i] == board[i + 2])
                    return GetPlayerByMarker(board[i]);
            }

            for (int i = 0; i < 3; i++)
            {
                if (board[i] == board[i + 3] && board[i] == board[i + 6])
                    return GetPlayerByMarker(board[i]);
            }

            if (board[0] == board[4] && board[0] == board[8])
                return GetPlayerByMarker(board[0]);

            if (board[2] == board[4] && board[2] == board[6])
                return GetPlayerByMarker(board[2]);

            return null;
        }

        /// Retrieves a player object based on their marker.
        private Player GetPlayerByMarker(string marker)
        {
            foreach (Player player in players)
            {
                if (player.Marker == marker)
                    return player;
            }
            return null;
        }
    }
}
