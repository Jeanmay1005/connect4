using System;
using static System.Console;

namespace Jeannie_Game
{
    class Menu
    {
        private static string[] game_options = {"Connect Four", "Gomoku"};
        static void Main(string[] args)
        {
            WriteLine("Welcome!");
            Game game = ChooseGame();
            game.Action();
        }

        private static Game ChooseGame()
        {
            while(true)
            {
                WriteLine("Please choose game type. Enter 1 for {0}, and 2 for {1}.", game_options[0], game_options[1]);
                string response = ReadLine();
                if (response == "1")
                {
                    WriteLine("Entering Connect Four Game...");
                    Rules rules = new Cnt4Rules();
                    rules.ShowRule();
                    return new Connect4Game("a");
                }
                else if (response == "2")
                {
                    WriteLine("Gomoku is still under development, please stay tuned!");
                }
                else { WriteLine("Please enter a valid number."); }

            }
        }
    }
}

