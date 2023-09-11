using System;
namespace Jeannie_Game
{
    public class UndoCommand : ICommand
    {
        public void Execute(History history, Board board, Player action_player, Player opponent)
        {
            if (history.record.Count < 2) { Console.WriteLine("No more moves can be undone, please place piece!"); }
            else
            {
                //store last two moves to variable 
                string first_last = history.record[history.record.Count - 1];
                string second_last = history.record[history.record.Count - 2];

                //add to archived steps (in case of redo)
                history.archived_step.Insert(0, first_last);
                history.archived_step.Insert(0, second_last);
                board.RemovePiece(Convert.ToInt32(first_last), board.UnfilledTop(Convert.ToInt32(first_last)) - 1);
                board.RemovePiece(Convert.ToInt32(second_last), board.UnfilledTop(Convert.ToInt32(second_last)) - 1);

                //remove the undone moves from record
                history.record.RemoveAt(history.record.Count - 1);
                history.record.RemoveAt(history.record.Count - 1);
            }
        }
        public UndoCommand()
        {    }
    }
}
