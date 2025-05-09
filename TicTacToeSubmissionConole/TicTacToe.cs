using System;
using TicTacToeRendererLib.Enums;
using TicTacToeRendererLib.Renderer;

namespace TicTacToeSubmissionConole
{
    public class TicTacToe
    {
        private TicTacToeConsoleRenderer _boardRenderer;
        private string[,] board = new string[3, 3];
        private int moveCount = 0;

        public TicTacToe()
        {
            _boardRenderer = new TicTacToeConsoleRenderer(10, 6);
            _boardRenderer.Render();
            InitializeBoard();
        }

        void InitializeBoard()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    board[row, col] = " ";
                }
            }
        }

        private bool IsValidMove(int row, int column)
        {
            return row >= 0 && row < 3 && column >= 0 && column < 3 && board[row, column] == " ";
        }

        bool CheckWin(string player)
        {
            for (int row = 0; row < 3; row++)
            {
                if (board[row, 0] == player && board[row, 1] == player && board[row, 2] == player)
                    return true;
            }

            for (int col = 0; col < 3; col++)
            {
                if (board[0, col] == player && board[1, col] == player && board[2, col] == player)
                    return true;
            }

            if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
                return true;

            if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player)
                return true;

            return false;
        }

        public void Run()
        {
            bool gameComplete = false;

            while (!gameComplete)
            {
                Console.Clear();
                _boardRenderer.Render();

                // --- Player X Movesup ---
                Console.SetCursorPosition(2, 19);
                Console.Write("Player X");

                Console.SetCursorPosition(2, 20);
                Console.Write("Please Enter Row (0-2): ");
                int row = int.Parse(Console.ReadLine());

                Console.SetCursorPosition(2, 22);
                Console.Write("Please Enter Column (0-2): ");
                int column = int.Parse(Console.ReadLine());

                if (IsValidMove(row, column))
                {
                    board[row, column] = "X";
                    _boardRenderer.AddMove(row, column, PlayerEnum.X, true);
                    moveCount++;
                }
                else
                {
                    Console.WriteLine("Invalid move. Try again.");
                    Console.ReadLine();
                    continue;
                }

                if (CheckWin("X"))
                {
                    Console.Clear();
                    _boardRenderer.Render();
                    Console.WriteLine("\n\n\nPlayer X wins!");
                    gameComplete = true;
                    break;
                }

                if (moveCount == 9)
                {
                    Console.Clear();
                    _boardRenderer.Render();
                    Console.WriteLine("\n\n\nIt's a draw!");
                    gameComplete = true;
                    break;
                }

                // --- Player O Moves ---
                Console.Clear();
                _boardRenderer.Render();

                Console.SetCursorPosition(2, 19);
                Console.Write("Player O");

                Console.SetCursorPosition(2, 20);
                Console.Write("Please Enter Row (0-2): ");
                row = int.Parse(Console.ReadLine());

                Console.SetCursorPosition(2, 22);
                Console.Write("Please Enter Column (0-2): ");
                column = int.Parse(Console.ReadLine());

                if (IsValidMove(row, column))
                {
                    board[row, column] = "O";
                    _boardRenderer.AddMove(row, column, PlayerEnum.O, true);
                    moveCount++;
                }
                else
                {
                    Console.WriteLine("\n\n\nInvalid move. Try again.");
                    Console.ReadLine();
                    continue;
                }

                if (CheckWin("O"))
                {
                    Console.Clear();
                    _boardRenderer.Render();
                    Console.WriteLine("\n\nPlayer O wins!");
                    gameComplete = true;
                    break;
                }

                if (moveCount == 9)
                {
                    Console.Clear();
                    _boardRenderer.Render();
                    Console.WriteLine("\n\n\nIt's a draw!");
                    gameComplete = true;
                    break;
                }
            }

            Console.WriteLine("\nGame Over. Press Enter to exit.");
            Console.ReadLine();
        }
    }
}
