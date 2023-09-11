using System;
namespace Jeannie_Game
{
    public class Board
    {
        // fields
        private int width;
        private int height;
        private char blank;
        public Piece[,] status; //declare array that stores different status(positions)
        public char GetSign(int x, int y) //get the sign of piece from position
        {

            return status[x - 1,y - 1].piece_sign;
        }
        public int GetCol() { return width; } 
        public int GetRow() { return height; }

        //return if status is blank or not
        public bool IsBlank(int x, int y)
        {
            return (status[x - 1,y - 1].piece_sign == blank);
        }
        public void PlacePiece(int x, int y, char piece_sign)
        {
            status[x - 1,y - 1] = new Piece(piece_sign); 
        }
        public void RemovePiece(int x, int y)
        {
            status[x - 1,y - 1] = new Piece(blank);
        }
        //check if an input is valid
        public bool CheckAvailable(int x, int y)
        {
            if (x <= 0 || y <= 0 || x > width || y > height)
            {
                return false;
            }

            return true;
        }
        //return top of col
        public int UnfilledTop(int x)
        {
            for (int i = 1; i <= this.GetRow(); i++)
            {
                if (this.IsBlank(x, i) == true)
                {
                    return i;
                }
            }
            return -1; //if column is filled up
        }

        //This function takes in starting x y position of a piece and returns its lenth of connected piece
        public int InARow(int start_x, int start_y, int[] direction, char sign)
        {
            int len = 0;
            int neighbor_x = start_x + direction[0];
            int neighbor_y = start_y + direction[1];
          
            while (this.CheckAvailable(neighbor_x, neighbor_y) && this.GetSign(neighbor_x, neighbor_y) == sign)
            {
                neighbor_x += direction[0];
                neighbor_y += direction[1];
                len++;                
            }
            return len;
        }

        // no drection declared
        //contrusctor1
        public Board(int width, int height, char blank)
        {
            this.width = width;
            this.height = height;
            this.blank = blank;
            status = new Piece[width,height]; 

            for (int i = 0; i < width; i++)
            {                

                for (int j = 0; j < height; j++)
                {
                    status[i,j] = new Piece(blank);
                }
            }
        }

        //constructor 2
        public Board(Piece[,] state, int width, int height, char blank)
        {
            this.width = width;
            this.height = height;
            this.blank = blank;
            this.status = state;
        }
        //Function to display the board
        public string Display()
        {
            string board_view = "";

            for (int i = this.GetRow(); i >= 1; i--)
            {
                for(int j =1; j<=this.GetCol(); j++)
                {
                    board_view += this.GetSign(j, i);
                    if(j != this.GetCol())
                    {
                        board_view += "|";
                    }                    
                }
                board_view += "\n";
            }
            return board_view;
        }
    }
}
