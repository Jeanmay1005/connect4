using System;
using System.Collections.Generic;
namespace Jeannie_Game
{
    public class CnctRound : Round
    {
        //return status of the board (as a string)
        public override string Move()
        {
            // show board current status
            Console.WriteLine(board.Display());
            //record list for history
            List <string> record = history.record;
            //record steps that are archived
            List <string> archived_step = history.archived_step;
            // accept move from player that is taking action
            while (true) {                 
                bool change = false;             
                Console.WriteLine("{0}'s turn. Please enter commands or enter help to review rules and commands:", action_player.GetName()); //action_player.player_num
                string command = action_player.MakeMovement(board); //Read the command (ReadLine)

                //Check input is number or other
                if (!int.TryParse(command, out int n))
                {
                    if (command == "help") { rules.ShowRule(); }
                    else if (command == "undo")
                    {
                        undo.Execute(history, board, action_player, opponent);
                        Console.WriteLine(board.Display());
                    }
                    else if (command == "redo")
                    {
                        redo.Execute(history, board, action_player, opponent);
                        Console.WriteLine(board.Display());
                    }

                    else if (command == "save")
                    {
                        Console.WriteLine("Please enter saving file name:");
                        string save_file_name = Console.ReadLine();
                        //save_file_name = "/Users/owner/Desktop/Jeannie_Game/Jeannie_Game/"+save_file_name;
                        history.SaveFile(save_file_name, board, action_player, opponent);
                        Console.WriteLine("File save successfully!");
                    }
                    else if (command == "load")
                    {
                        Console.WriteLine("Please enter loading file name:");
                        string load_file_name = Console.ReadLine();
                        //load_file_name = "/Users/owner/Desktop/Jeannie_Game/Jeannie_Game/" + load_file_name;
                        history.LoadFile(load_file_name);
                    }
                    else { Console.WriteLine("Invalid input, please retry:"); }
                }
                
                else if (rules.MoveValid(command, board))
                {
                    history.UpdateRecord(command);
                    int x = Convert.ToInt32(command);
                    if (board.UnfilledTop(x) == -1)
                    {
                        Console.WriteLine("Slot number {0} is filled, please choose another one.", command);
                    }
                    else
                    {
                        board.PlacePiece(x, board.UnfilledTop(x), action_player.GetPieceSign());
                        change = true;
                    }
                    if (change) { return command; }
                }
                else
                {
                    Console.WriteLine("Invalid input, please retry:");
                }                
            }           
        }
        public CnctRound(Player action_player, Player opponent, Board board, Rules rules, History history, UndoCommand undo, RedoCommand redo) : base(action_player, opponent, board, rules, history, undo, redo)
        {
            
        }
    }
}
