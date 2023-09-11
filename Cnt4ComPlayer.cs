using System;
namespace Jeannie_Game
{
    public class Cnt4ComPlayer : Player
    {
        public override string MakeMovement(Board board)
        {
            Random random = new Random();
            int x = random.Next(1, board.GetCol());
            while (true)
            {
                if (board.UnfilledTop(x) != -1)
                {
                    break;
                }
                else
                {
                    x = random.Next(1, board.GetCol());
                }
            }
            return Convert.ToString(x);
        }
        public Cnt4ComPlayer(char piece_sign, string player_name) : base(piece_sign, player_name)
        {
        }
    }
}
