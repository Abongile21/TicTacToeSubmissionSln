using System;
using System.Collections.Generic;
using System.Text;
using TicTacToeRendererLib.Enums;
using TicTacToeRendererLib.Renderer;

namespace TicTacToeSubmissionConole
{
    public class TicTacToe
    {
        private TicTacToeConsoleRenderer _boardRenderer;
        private string[,] board = new string[3,3];

        public TicTacToe()
        {
            _boardRenderer = new TicTacToeConsoleRenderer(10,6);
            _boardRenderer.Render();
        }


        void InitializerBoard(){
            for(int row =0; row<3;row++){
                for(int col =0; col<3; col++){
                    board[row,col] = " ";
                }
            }
        }


        private bool IsValidMove(int row, int column)
        {
            return board[row,column]==" ";
        }
        
        
        bool CheckWin(string player){

            for (int rowIndex = 0; rowIndex < 3; rowIndex++)
            {
                if (board[rowIndex, 0] == player && board[rowIndex, 1] == player && board[rowIndex, 2] == player)
                {   
                    return true;
                }           
            }


            for (int columnIndex = 0; columnIndex < 3; columnIndex++)
            {
                if (board[0, columnIndex] == player && board[1, columnIndex] == player && board[2, columnIndex] == player)
                { 
                     return true;
                }
            }

            if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
            {
                return true;
            }
                

            if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player)
            {
                return true;
            }
            else
            return false;

        }

        public void Run()
        {
            bool gameComplete =false;

            while(!gameComplete){
                Console.Clear();
                _boardRenderer.Render();

                Console.SetCursorPosition(2, 19);
                Console.Write("Player X");

                Console.SetCursorPosition(2, 20);
                Console.Write("Please Enter Row: ");
                int row = int.Parse(Console.ReadLine());

                Console.SetCursorPosition(2, 22);
                Console.Write("Please Enter Column: ");
                int column = int.Parse(Console.ReadLine());

                //
                if (IsValidMove(row, column))
                {
                    board[row, column] = "X";
                    _boardRenderer.AddMove(row, column, PlayerEnum.X, true);
                }
                else
                {
                    Console.WriteLine("Invalid move. Try again.");
                    Console.ReadLine();
                    continue;
                }

                if (CheckWin("X"))
                {
                    Console.WriteLine("Player X wins!");
                    gameComplete = true;
                    break;
                }

                Console.Clear();
                _boardRenderer.Render();

                Console.SetCursorPosition(2, 19);
                Console.Write("Player O");

                Console.SetCursorPosition(2, 20);
                Console.Write("Please Enter Row: ");
                row = int.Parse(Console.ReadLine());

                Console.SetCursorPosition(2, 22);
                Console.Write("Please Enter Column: ");
                column = int.Parse(Console.ReadLine());

                if (IsValidMove(row, column))
                {
                    board[row, column] = "O";
                    _boardRenderer.AddMove(row, column, PlayerEnum.O, true);
                }
                else
                {
                    Console.WriteLine("Invalid move. Try again.");
                    Console.ReadLine();
                    continue;
                }

                if (CheckWin("O"))
                {
                    Console.WriteLine("Player O wins!");
                    gameComplete = true;
                }


            }

            
        }

    }
}
