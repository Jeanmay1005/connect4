using System;
using static System.Console;
namespace Jeannie_Game
{
    public class Connect4Game : Game
    {
        //declare information for te board
        private static char blank = ' ';
        private static int x = 7;
        private static int y = 6;

        //create players
        public override Player CreatePlayer(int player_num, char sign, string name)
        {
            Player new_player = null;            
            string[] options = { "h : human", "c : computer" };
            Console.WriteLine("Please choose option for player{0}: ", player_num);
            bool valid_response = false;
            do
            {
                foreach (string option in options)
                {
                    Console.WriteLine(option);
                }
                string response = Console.ReadLine();
                if (response == "h")
                {
                    new_player = new Cnt4HumanPlayer(sign, name);
                    valid_response = true;
                    break;
                }

                else if (response == "c")
                {
                    new_player = new Cnt4ComPlayer(sign, "Computer"); // default computer's name as comp
                    valid_response = true;
                    break;
                }
                else { Console.WriteLine("Invalid option, please re-enter:"); }
            }
            while (!valid_response);
            return new_player;            
        }

        //make player turn
        public override string PlayAlong()
        {
            //build connect round object and pass info of players and board and game type and rules
            CnctRound turn = new CnctRound(players[player_turn], players[(player_turn + 1) % 2], board, rules, history, undo, redo);
            return turn.Move();
        }

        //Start playing
        public override void Action()
        {
            while (true)
            {                
                string move = PlayAlong();

                if (rules.Winner(board, move, players[player_turn].GetPieceSign()))
                {
                    Console.WriteLine(board.Display());
                    WriteLine("Congrats {0}, you are the winner!!", players[player_turn].GetName());
                    
                    break;
                }
                else
                { player_turn = (player_turn + 1) % players.Length; }
                
            }
        }
        //game constructor 
        public Connect4Game(string a)
        {
            players = new Player[2];
            players[0] = CreatePlayer(1, 'X', "Player 1");
            players[1] = CreatePlayer(2, 'O', "Player 2");
            board = new Board(x, y, blank);
            rules = new Cnt4Rules();
            history = new History();
            undo = new UndoCommand();
            redo = new RedoCommand();
        }
        //alternative constructor!
        public Connect4Game(Piece[,] state, string player1name, string player2name, char player1sign, char player2sign)
        {
            players = new Player[2];
            players[0] = new Cnt4HumanPlayer(player1sign, player1name);
            if (player2name == "Computer") { players[1] = new Cnt4ComPlayer(player2sign, player2name); }
            else { players[1] = new Cnt4HumanPlayer(player2sign, player2name); }
           
            board = new Board(state, x, y, blank);
            history = new History();
            rules = new Cnt4Rules();
            undo = new UndoCommand();
            redo = new RedoCommand();
        }
    }
}
