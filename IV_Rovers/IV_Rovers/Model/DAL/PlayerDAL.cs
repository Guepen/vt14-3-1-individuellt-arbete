using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
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

        public Player GetPlayerByID(int playerID)
        {
            using (SqlConnection conn = createConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("AppSchema.uspGetPlayerByID", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PlayerID", playerID);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var PlayerIDIndex = reader.GetOrdinal("PlayerID");
                        var FNameIndex = reader.GetOrdinal("FName");
                        var LNameIndex = reader.GetOrdinal("LName");
                        var HeightIndex = reader.GetOrdinal("Height");
                        var WeightIndex = reader.GetOrdinal("Weight");
                        var ShirtNrIndex = reader.GetOrdinal("ShirtNr");

                        while (reader.Read())
                        {
                            
                            return new Player
                            {
                                PlayerID = reader.GetInt32(PlayerIDIndex),
                                FName = reader.GetString(FNameIndex),
                                LName = reader.GetString(LNameIndex),
                                Height = reader.GetInt32(HeightIndex),
                                Weight = reader.GetInt32(WeightIndex),
                                ShirtNr = reader.GetByte(ShirtNrIndex)
                            };
                        }
                    }

                    return null;
                }

                catch
                {
                    throw new ApplicationException("Ett fel inträffade vid hämtning av spelare");
                }
            }
        }

        public void InsertPlayer(Player player)
        {
            using (SqlConnection conn = createConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("AppSchema.uspAddPlayer", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FName", SqlDbType.VarChar, 50).Value = player.FName;
                    cmd.Parameters.Add("@LName", SqlDbType.VarChar, 50).Value = player.LName;
                    cmd.Parameters.Add("@Height", SqlDbType.Int).Value = player.Height;
                    cmd.Parameters.Add("@Weight", SqlDbType.Int).Value = player.Weight;
                    cmd.Parameters.Add("@ShirtNr", SqlDbType.TinyInt).Value = player.ShirtNr;
                    cmd.Parameters.Add("@PlayerID", SqlDbType.Int).Direction = ParameterDirection.Output;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    player.PlayerID = (int)cmd.Parameters["@PlayerID"].Value;

                }

                catch
                {
                    throw new ApplicationException("Ett fel uppstod när spelare skulle läggas till");
                }
            }
        }

        public void UpdatePlayer(Player player)
        {
            using (SqlConnection conn = createConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("AppSchema.uspUpdatePlayer", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FName", SqlDbType.VarChar, 50).Value = player.FName;
                    cmd.Parameters.Add("@LName", SqlDbType.VarChar, 30).Value = player.LName;
                    cmd.Parameters.Add("@Height", SqlDbType.Int).Value = player.Height;
                    cmd.Parameters.Add("@Weight", SqlDbType.Int).Value = player.Weight;
                    cmd.Parameters.Add("@ShirtNr", SqlDbType.Int).Value = player.ShirtNr;
                    cmd.Parameters.Add(@"PlayerID", SqlDbType.Int).Value = player.PlayerID;

                    conn.Open();
                    cmd.ExecuteNonQuery();


                }

                catch
                {
                    throw;
                }
            }
        }

        public void DeletePlayer(int playerID)
        {
            using (SqlConnection conn = createConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("AppSchema.uspDeletePlayer", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(@"PlayerID", SqlDbType.Int, 4).Value = playerID;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                catch
                {
                    throw new ArgumentException("Det gick inte att ta bort kontakten");
                }
            }
        }
    }
}
