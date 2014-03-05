using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IV_Rovers.Model.DAL;

namespace IV_Rovers.Model
{
    public class Service
    {
        private PlayerDAL _playerDAL;

        private PlayerDAL PlayerDAL
        {
            get { return _playerDAL ?? (_playerDAL = new PlayerDAL()); }
        }

        public void DeletePlayer(int playerID)
        {
            throw new NotImplementedException();
        }

        public Player GetPlayerByID(int playerID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Player> GetPlayers()
        {
            return PlayerDAL.GetPlayers();

        }
    }
}