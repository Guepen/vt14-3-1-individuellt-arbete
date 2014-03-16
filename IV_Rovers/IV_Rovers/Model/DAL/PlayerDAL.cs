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
        //Hämtar alla spelare i databasen
        public IEnumerable<Player> GetPlayers()
        {
            //anslutningsobjekt
            using (var conn = createConnection())
            {
                try
                {
                    var players = new List<Player>(60);

                    var cmd = new SqlCommand("AppSchema.uspGetPlayers", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Öppnar anslutningen till databasen
                    conn.Open();

                    //Den lagrade proceduren kommer att returnera flera rader som
                    //SqlDataReader-objektet tar hand om 
                    using (var reader = cmd.ExecuteReader())
                    {
                        //hämtar indexet på kolumnerna
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
                                Height = reader.GetByte(HeightIndex),
                                Weight = reader.GetByte(WeightIndex),
                                ShirtNr = reader.GetByte(ShirtNrIndex)
                            });
                        }
                    }

                    //avallokerar minne                     
                    players.TrimExcess();

                    //returnerar en referens till listan med spelare
                    return players;
                }

                catch
                {
                    throw new ApplicationException("Ett fel uppstod vid hämtning av spelarlista");
                }
            }
        }

        //Hämtar en spelare och dess information
        public Player GetPlayerByID(int playerID)
        {
            //anslutningsobjekt
            using (SqlConnection conn = createConnection())
            {
                try
                {
                    //Skapar ett objekt av typen SqlCommand
                    SqlCommand cmd = new SqlCommand("AppSchema.uspGetPlayerByID", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Parameter i den lagrade proceduren
                    cmd.Parameters.AddWithValue("@PlayerID", playerID);

                    //Öppnar anslutningen till databasen
                    conn.Open();

                    //Den lagrade proceduren kommer att returnera flera rader som
                    //SqlDataReader-objektet tar hand om 
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        //hämtar indexet på kolumnerna
                        var PlayerIDIndex = reader.GetOrdinal("PlayerID");
                        var FNameIndex = reader.GetOrdinal("FName");
                        var LNameIndex = reader.GetOrdinal("LName");
                        var HeightIndex = reader.GetOrdinal("Height");
                        var WeightIndex = reader.GetOrdinal("Weight");
                        var ShirtNrIndex = reader.GetOrdinal("ShirtNr");

                        //Medan det finns data att läsa 
                        while (reader.Read())
                        {
                            
                            //Returnerar en referens till  det skapade Player-objektet
                            return new Player
                            {
                                PlayerID = reader.GetInt32(PlayerIDIndex),
                                FName = reader.GetString(FNameIndex),
                                LName = reader.GetString(LNameIndex),
                                Height = reader.GetByte(HeightIndex),
                                Weight = reader.GetByte(WeightIndex),
                                ShirtNr = reader.GetByte(ShirtNrIndex)
                            };
                        }
                    }

                    //Om det inte finns någon spelare med det medskickade ID
                    return null;
                }

                catch
                {
                    throw new ApplicationException("Ett fel inträffade vid hämtning av spelare");
                }
            }
        }

        //Lägger tilll en ny spelare i databasen
        public void InsertPlayer(Player player)
        {
            //anslutningsobjekt
            using (SqlConnection conn = createConnection())
            {
                try
                {
                    //Skapar ett objekt av typen SqlCommand
                    SqlCommand cmd = new SqlCommand("AppSchema.uspAddPlayer", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Parametrar i den lagrade proceduren
                    cmd.Parameters.Add("@FName", SqlDbType.VarChar, 50).Value = player.FName;
                    cmd.Parameters.Add("@LName", SqlDbType.VarChar, 50).Value = player.LName;
                    cmd.Parameters.Add("@Height", SqlDbType.TinyInt).Value = player.Height;
                    cmd.Parameters.Add("@Weight", SqlDbType.TinyInt).Value = player.Weight;
                    cmd.Parameters.Add("@ShirtNr", SqlDbType.TinyInt).Value = player.ShirtNr;
                    
                    //tilldelas primäryckelns 
                    cmd.Parameters.Add("@PlayerID", SqlDbType.Int).Direction = ParameterDirection.Output;

                    //Öppnar anslutningen till databasen
                    conn.Open();

                    //inga rader returneras därför används ExecuteNonQuery för att exekvera Proceduren
                    cmd.ExecuteNonQuery();

                    //Tilldelar PlayerID primärnyckelns värde för den nya raden
                    player.PlayerID = (int)cmd.Parameters["@PlayerID"].Value;

                }

                catch
                {
                    throw new ApplicationException("Ett fel uppstod när spelare skulle läggas till");
                }
            }
        }

        //Uppdaterar en spelare i databsen
        public void UpdatePlayer(Player player)
        {
            //anslutningsobjekt
            using (SqlConnection conn = createConnection())
            {
                try
                {
                    //Skapar ett objekt av typen SqlCommand
                    SqlCommand cmd = new SqlCommand("AppSchema.uspUpdatePlayer", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Parametrar i den lagrade proceduren
                    cmd.Parameters.Add("@FName", SqlDbType.VarChar, 50).Value = player.FName;
                    cmd.Parameters.Add("@LName", SqlDbType.VarChar, 30).Value = player.LName;
                    cmd.Parameters.Add("@Height", SqlDbType.TinyInt).Value = player.Height;
                    cmd.Parameters.Add("@Weight", SqlDbType.TinyInt).Value = player.Weight;
                    cmd.Parameters.Add("@ShirtNr", SqlDbType.TinyInt).Value = player.ShirtNr;
                    cmd.Parameters.Add(@"PlayerID", SqlDbType.Int).Value = player.PlayerID;

                    //Öppnar anslutningen till databasen
                    conn.Open();

                    //inga rader returneras därför används ExecuteNonQuery för att exekvera Proceduren
                    cmd.ExecuteNonQuery();


                }

                catch
                {
                    throw new ApplicationException("Ett fel uppstod när spelare skulle uppdateras");
                }
            }
        }

        //Tar bort spelare från databasen
        public void DeletePlayer(int playerID)
        {
            //anslutningsobjekt
            using (SqlConnection conn = createConnection())
            {
                try
                {
                    //Skapar ett objekt av typen SqlCommand
                    SqlCommand cmd = new SqlCommand("AppSchema.uspDeletePlayer", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Parameter i den lagrade proceduren
                    cmd.Parameters.Add(@"PlayerID", SqlDbType.Int, 4).Value = playerID;

                    //Öppnar anslutningen till databasen
                    conn.Open();

                    //inga rader returneras därför används ExecuteNonQuery för att exekvera Proceduren
                    cmd.ExecuteNonQuery();
                }

                catch
                {
                    throw new ArgumentException("Det gick inte att ta bort spelaren");
                }
            }
        }
    }
}
