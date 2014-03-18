using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IV_Rovers.Model.DAL;
using System.ComponentModel.DataAnnotations;

namespace IV_Rovers.Model
{
    public class Service
    {
        private PlayerDAL _playerDAL;
        private PlayerTypeDAL _playerTypeDAL;
        private PositionDAL _positionDAL;

        //Lazy initialision, objekten skapas först när de behövs 
        private PlayerDAL PlayerDAL
        {
            get { return _playerDAL ?? (_playerDAL = new PlayerDAL()); }
        }

        private PlayerTypeDAL PlayerTypeDAL
        {
            get { return _playerTypeDAL ?? (_playerTypeDAL = new PlayerTypeDAL()); }
        }

        private PositionDAL PositionDAL
        {
            get { return _positionDAL ?? (_positionDAL = new PositionDAL()); }
        }

       //spelarens ID skickas som parameter till metoden DeletePlayerID här nedan.
        public void DeletePlayer(Player player)
        {
            DeletePlayerID(player.PlayerID);
        }

        public void DeletePlayerID(int playerID)
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
            ICollection<ValidationResult> validationResults;
            if (!player.ValidatePlayer(out validationResults))
            {
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }
            
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
            var playerTypes = HttpContext.Current.Cache["PlayerTypes"] as IEnumerable<PlayerType>;

            if (playerTypes == null)
            {
                playerTypes = PlayerTypeDAL.GetPlayerTypes();

                HttpContext.Current.Cache.Insert("PlayerTypes", playerTypes, null, DateTime.Now.AddMinutes(15), TimeSpan.Zero);
            }

            return playerTypes;
        }

        public PlayerType GetPlayerTypeByID(int PlTypeID)
        {
            return PlayerTypeDAL.GetPlayerTypeByID(PlTypeID);
        }

        public void SavePosition(Position position)
        { 
            PositionDAL.InsertPosition(position);
        }

        public void DeletePosition(Position position)
        {
            PositionDAL.DeletePosition(position);
        }

        public IEnumerable<Position> GetPosition(int id)
        {
            return PositionDAL.GetPlayerPosition(id);
        }

    }
}