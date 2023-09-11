using System;
namespace Jeannie_Game
{
    public abstract class Rules
    {
        public abstract bool MoveValid(string move, Board board);
        public abstract bool Winner(Board board, string move, char sign);
        public abstract void ShowRule();
    }

}
