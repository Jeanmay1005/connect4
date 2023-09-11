using System;
namespace Jeannie_Game
{
    //This is the main gaming system 
    public abstract class Game
    {
        
        public Player[] players; //list of player
        public int player_turn = 0; 
        public Board board;
        public Rules rules;
        public History history;
        public UndoCommand undo;
        public RedoCommand redo;
        public Connect4Game game;

        public abstract string PlayAlong();
        public abstract void Action();
        public abstract Player CreatePlayer(int player_num, char sign, string name);
    }
}
