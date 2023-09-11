using System;
namespace Jeannie_Game
{
    public abstract class Round
    {
        protected Player action_player;
        protected Player opponent;
        protected Board board;
        protected History history;
        protected char game_type;
        protected Rules rules;
        protected Connect4Game game;
        protected UndoCommand undo;
        protected RedoCommand redo;


        public Round(Player action_player, Player opponent, Board board, Rules rules, History history, UndoCommand undo, RedoCommand redo) //game type, History history, Rules rules
        {
            this.action_player = action_player;
            this.opponent = opponent;
            this.board = board;
            this.rules = rules;
            this.history = history;
            this.undo = undo;
            this.redo = redo;
        }
        public abstract string Move();
    }   
}
