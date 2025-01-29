using System.Collections.Generic;

namespace TicTacToeWebApp.Models
{
    public class TicTacToe
    {
        // The Tic-Tac-Toe board (changed to a list of lists for easier serialization)
        public List<List<char>> Board { get; set; }

        // The current player ('X' or 'O')
        public char CurrentPlayer { get; set; }

        // The game result (e.g., "X wins!", "O wins!", "Game in progress")
        public string Result { get; set; }

        public TicTacToe()
        {
            // Initialize the board as a 3x3 list of lists
            Board = new List<List<char>>
            {
                new List<char> { '\0', '\0', '\0' },
                new List<char> { '\0', '\0', '\0' },
                new List<char> { '\0', '\0', '\0' }
            };

            CurrentPlayer = 'X';
            Result = "Game in progress";
        }

        public bool MakeMove(int row, int col)
        {
            // Check if the selected cell is empty
            if (Board[row][col] == '\0')
            {
                // Place the current player's mark and switch to the other player
                Board[row][col] = CurrentPlayer;
                CurrentPlayer = CurrentPlayer == 'X' ? 'O' : 'X';
                return true;
            }
            return false;
        }

        public string CheckWin()
        {
            // Check rows and columns for a win
            for (int i = 0; i < 3; i++)
            {
                if (Board[i][0] != '\0' && Board[i][0] == Board[i][1] && Board[i][1] == Board[i][2])
                    return $"{Board[i][0]} wins!";
                if (Board[0][i] != '\0' && Board[0][i] == Board[1][i] && Board[1][i] == Board[2][i])
                    return $"{Board[0][i]} wins!";
            }

            // Check diagonals for a win
            if (Board[0][0] != '\0' && Board[0][0] == Board[1][1] && Board[1][1] == Board[2][2])
                return $"{Board[0][0]} wins!";
            if (Board[0][2] != '\0' && Board[0][2] == Board[1][1] && Board[1][1] == Board[2][0])
                return $"{Board[0][2]} wins!";

            // Check for a tie
            bool isBoardFull = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Board[i][j] == '\0')
                    {
                        isBoardFull = false;
                        break;
                    }
                }
                if (!isBoardFull) break;
            }

            if (isBoardFull)
                return "It's a tie!";

            // If no win or tie, the game is still in progress
            return "Game in progress";
        }
    }
}
