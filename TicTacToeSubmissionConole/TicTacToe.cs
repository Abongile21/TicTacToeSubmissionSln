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

            
        }

    }
}
