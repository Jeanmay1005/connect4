using System;
namespace Jeannie_Game
{
    //abstract class of player
    public abstract class Player
    {
        char piece_sign;
        string player_name;

        public Player(char piece_sign, string player_name) //constructor
        {
            this.piece_sign = piece_sign;
            this.player_name = player_name;
        }

        //method that returns a string of movement
        public abstract string MakeMovement(Board board); 
        public char GetPieceSign() 
        {
            return piece_sign;
        }
        public string GetName()
        {
            return player_name;
        }
    }
          
}
