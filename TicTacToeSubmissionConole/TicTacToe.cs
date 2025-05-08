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


        void CheckBoard(){
            for(int row =0; row<3;row++){
                for(int col =0; col<3; col++){
                    board[row,col] = " ";
                }
            }
        }
        
        bool CheckWin(string player){

            if(board[0,0]==player&& board[0,1]==player && board[0,2]==player){
                return true;
            }
            else if(board[1,0]==player&& board[1,1]==player && board[1,2]==player){
                return true;
            }
            else
            return false;

        }

        public void Run()
        {

            // FOR ILLUSTRATION CHANGE TO YOUR OWN LOGIC TO DO TIC TAC TOE

            Console.SetCursorPosition(2, 19);

            Console.Write("Player X");

            Console.SetCursorPosition(2, 20);

            Console.Write("Please Enter Row: ");
            var row = Console.ReadLine();

            Console.SetCursorPosition(2, 22);


            Console.Write("Please Enter Column: ");
            var column = Console.ReadLine();

            
            // THIS JUST DRAWS THE BOARD (NO TIC TAC TOE LOGIC)
            _boardRenderer.AddMove(int.Parse(row), int.Parse(column), PlayerEnum.X, true);            

        }

    }
}
