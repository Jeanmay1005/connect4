using System;
namespace Jeannie_Game
{
    public class RedoCommand : ICommand
    {
        protected Player action_player;
        protected Player opponent;
        public void Execute(History history, Board board, Player action_player, Player opponent)
        {
            if (history.archived_step.Count == 0) { Console.WriteLine("No more moves can be redone!"); }
            else
            {
                //get archived's first two
                int x1 = Convert.ToInt32(history.archived_step[0]);
                int x2 = Convert.ToInt32(history.archived_step[1]);
                //place piece back on board
                board.PlacePiece(x1, board.UnfilledTop(x1), action_player.GetPieceSign());
                board.PlacePiece(x2, board.UnfilledTop(x2), opponent.GetPieceSign());
                //add moves back to record
                history.record.Add(history.archived_step[1]);
                history.record.Add(history.archived_step[0]);
                //remove steps from archived
                history.archived_step.RemoveAt(0);
                history.archived_step.RemoveAt(0);
            }
        }
        public RedoCommand()
        {

        }

    }
}
