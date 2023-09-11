using System;
using System.IO;
using System.Collections.Generic;
namespace Jeannie_Game
{
    public class History
    {
        public List<string> record;
        public List<string> archived_step;
        public void UpdateRecord(string move)
        {
            record.Add(move);
        }

        public History()
        {
            record = new List<string>();
            archived_step = new List<string>();
        }

        public History(List<string> record, List<string> archived_step)
        {
            this.record = record;
            this.archived_step = archived_step;
        }

        //Savefile 
        public void SaveFile(string file_name, Board board, Player player1, Player player2)
        {    
            FileStream save_file = new FileStream(file_name, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(save_file);
            //display board
            writer.Write(board.Display());
            //status
            Console.WriteLine(board.status.GetLength(0));
            Console.WriteLine(board.status.GetLength(1));
            for (int i = 0; i <= 6; i++)
            {
                for (int j = 0; j <= 5; j++)
                {
                    writer.WriteLine(board.status[i, j].piece_sign);
                }
            }
            //player info
            writer.WriteLine(player1.GetName());
            writer.WriteLine(player1.GetPieceSign());
            writer.WriteLine(player2.GetName());
            writer.WriteLine(player2.GetPieceSign());
            writer.Close();
            save_file.Close();            
        }

        //LoadFile return status, action player 
        public Piece[,] ReturnStatus(string file_path)
        {
            Piece[,] status = new Piece[7,6];
            string[] lines = File.ReadAllLines(file_path);
            string[] signs = lines[6..49];

            //parse piece sign back to status

            for (int i = 0; i <= 6; i++)
            {
                for (int j = 0; j <= 5; j++)
                {
                    status[i,j] = new Piece(' ');
                    status[i,j].piece_sign = Convert.ToChar(signs[6 * i + j]);
                }
            }
            return status;            
        }

        public void LoadFile(string file_path) 
        {
            Console.WriteLine("Loading game...");
            Piece[,] status = ReturnStatus(file_path);
            string[] lines = File.ReadAllLines(file_path);
            string player1name = lines[^4];
            string player2name = lines[^2];
            char player1sign = Convert.ToChar(lines[^3]);
            char player2sign = Convert.ToChar(lines[^1]);           
            Game game = new Connect4Game(status, player1name, player2name, player1sign, player2sign);
            game.Action();
            Console.WriteLine("Redirecting to the previous game...");
        }

    }
}