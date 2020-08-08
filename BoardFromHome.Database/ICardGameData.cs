using BoardFromHome.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoardFromHome.Database
{
    public interface ICardGameData
    {
        public BoardGame add(BoardGame game);
        public BoardGame delete(BoardGame game);
        public BoardGame getById(string id);
        public BoardGame update(BoardGame newGame);
        public int commit();
    }
}
