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

        private PlayerTypeDAL _playerTypeDAL;

        private PlayerTypeDAL PlayerTypeDAL
        {
            get { return _playerTypeDAL ?? (_playerTypeDAL = new PlayerTypeDAL()); }
        }

        private PositionDAL _positionDAL;

        private PositionDAL PositionDAL
        {
            get { return _positionDAL ?? (_positionDAL = new PositionDAL()); }
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

        public IEnumerable<PlayerType> GetPlayerTypes()
        {
            return PlayerTypeDAL.GetPlayerTypes();
        }

        public void SavePosition(Position position)
        {
            PositionDAL.InsertPosition(position);
        }

        public void DeletePosition(Position position)
        {
            PositionDAL.Delete(position);
        }

        public IEnumerable<Position> GetPosition(int id)
        {
            return PositionDAL.GetPlayerPosition(id);
        }

        public PlayerType GetPlayerTypeByID(int PlTypeID)
        {
            return PlayerTypeDAL.GetPlayerTypeByID(PlTypeID);
        }
    }
}