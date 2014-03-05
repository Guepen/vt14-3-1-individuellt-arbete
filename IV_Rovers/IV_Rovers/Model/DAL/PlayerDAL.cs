using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace IV_Rovers.Model.DAL
{
    public class PlayerDAL : DALBase
    {
        public IEnumerable<Player> GetPlayers()
        {
            using (var conn = createConnection())
            {
                try
                {
                    var players = new List<Player>(100);

                    var cmd = new SqlCommand("AppSchema.uspGetPlayers", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var PlayerIDIndex = reader.GetOrdinal("PlayerID");
                        var FNameIndex = reader.GetOrdinal("FName");
                        var LNameIndex = reader.GetOrdinal("LName");
                        var HeightIndex = reader.GetOrdinal("Height");
                        var WeightIndex = reader.GetOrdinal("Weight");
                        var ShirtNrIndex = reader.GetOrdinal("ShirtNr");

                        //Medan det finns data att läsa ut
                        while (reader.Read())
                        {
                            players.Add(new Player
                            {
                                PlayerID = reader.GetInt32(PlayerIDIndex),
                                FName = reader.GetString(FNameIndex),
                                LName = reader.GetString(LNameIndex),
                                Height = reader.GetInt32(HeightIndex),
                                Weight = reader.GetInt32(WeightIndex),
                                ShirtNr = reader.GetByte(ShirtNrIndex)
                            });
                        }
                    }

                    //avallokerar minne                     
                    players.TrimExcess();

                    return players;
                }

                catch
                {
                    throw new ApplicationException("Ett fel uppstod vid hämtning av spelarlista");
                }
            }
        }
    }
}
