using System;
namespace Jeannie_Game
{
    //concrete class of the connect 4 human player
    class Cnt4HumanPlayer : Player
    {
        // constructor of Human Player
        public Cnt4HumanPlayer(char piece_sign, string player_name) : base(piece_sign, player_name)
        { }
        // recieve info from board 
        public override string MakeMovement(Board board)
        {
            return Console.ReadLine();
        }     
    }
}
