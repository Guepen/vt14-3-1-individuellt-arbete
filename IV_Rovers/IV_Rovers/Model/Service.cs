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

        public void DeletePlayer(Player player)
        {
            DeletePlayer(player.PlayerID);
        }

        public void DeletePlayer(int playerID)
        {
            PlayerDAL.DeletePlayer(playerID);
        }

        public Player GetPlayerByID(int playerID)
        {
            return PlayerDAL.GetPlayerByID(playerID);
        }

        public IEnumerable<Player> GetPlayers()
        {
            return PlayerDAL.GetPlayers();

        }

        public void SavePlayer(Player player)
        {
            if (player.PlayerID == 0)
            {
                PlayerDAL.InsertPlayer(player);
            }

            else
            {
                PlayerDAL.UpdatePlayer(player);
            }
        }
    }
}