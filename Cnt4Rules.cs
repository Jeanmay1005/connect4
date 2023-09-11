using System;
namespace Jeannie_Game
{
    public class Cnt4Rules : Rules
    {
        public override bool MoveValid(string move, Board board)
        {
            int x = Convert.ToInt32(move);
            if (x > board.GetCol() || x < 1) { return false; }
            else { return true; }
        }
        //winning sirection : horizontal, vertical, diagnol
        public static int[][] directions = new int[][] {new int[] {-1, -1}, new int[] {1, 1},
            new int[] {-1, 0}, new int[] {1, 0}, new int[] {0, -1}, new int[] {0, 1}, new int[] {-1, 1 }, new int[] {1, -1 } };

        public override bool Winner(Board board, string move, char sign)
        {

            int x = Convert.ToInt32(move);
            int y = board.UnfilledTop(x) - 1;

            for (int i = 0; i < directions.Length; i += 2)
            {                
                int connected_len = 1;
                connected_len += board.InARow(x, y, directions[i], sign);
                connected_len += board.InARow(x, y, directions[i+1], sign);           
                if (connected_len >= 4)
                {
                    return true;                    
                }
            }    
            
            return false;
        }
        string description =
            "========================== Connect Four Rules and Commands ========================== " +
            "\nRules: " +
            "\nEach player places one piece at a time from the top of the slot." +
            "\nThe player to first connect their pieces with at least 4-in-a-row wins."+
            "\nHorizontal, vertical, and diagonal connections are all accountable."+
            "\n"+
            "\nCommands:"+
            "\n1. Enter a valid number to place a piece in the according slot." +
            "\n2. Enter undo to undo a move."+
            "\n3. Enter redo to redo an undone move."+
            "\n4. Enter save and then assign a file name to save your current progress."+
            "\n5. Enter load and then assign a file name to load a previous saved progress."+
            "\n6. PLease note that all commands are case sensitive, please enter in low case format."+
            "\n=====================================================================================";
        public override void ShowRule()
        {
            Console.WriteLine(description);
        }

    }
}
