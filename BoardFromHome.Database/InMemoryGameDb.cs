using BoardFromHome.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoardFromHome.Database
{
    public class InMemoryGameDb : ICardGameData
    {
        private List<BoardGame> games;
        public InMemoryGameDb()
        {
            games = new List<BoardGame>()
            {

            };
        }
        public BoardGame add(BoardGame game)
        {
            game.id = (games == null) ? 0 : games.Max(r => r.id) + 1;
            games.Add(game);
            return game;
        }

        public int commit()
        {
            return 0;
        }

        public BoardGame delete(BoardGame game)
        {
            games.Remove(game);
            return game;
        }

        public BoardGame getById(int id)
        {
            BoardGame game = games.FirstOrDefault(r => r.id == id);
            return (game == null) ? null : game;
        }

        public BoardGame update(BoardGame newGame)
        {
            BoardGame oldGame = games.FirstOrDefault(r => r.id == newGame.id);
            if(oldGame != null)
            {
                oldGame.maxPlayers = newGame.maxPlayers;
                oldGame.minPlayers = newGame.minPlayers;
                oldGame.ruleSet = newGame.ruleSet;
                oldGame.uniqueItemAmounts = newGame.uniqueItemAmounts;
                return oldGame;
            }
            else
            {
                return null;
            }
        }
    }
}
