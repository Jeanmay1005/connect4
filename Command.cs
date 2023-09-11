using System;
namespace Jeannie_Game
{
    public interface ICommand
    {
        public abstract void Execute(History history, Board board, Player action_player, Player opponent);
    }
}
