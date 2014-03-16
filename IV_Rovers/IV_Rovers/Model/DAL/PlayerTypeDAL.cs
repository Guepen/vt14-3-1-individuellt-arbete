using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace IV_Rovers.Model.DAL
{
    public class PlayerTypeDAL : DALBase
    {
        //Hämtar spelartyper från databasen
        public IEnumerable<PlayerType> GetPlayerTypes()
        {
            //anslutningsobjekt till databasen
            using (var conn = createConnection())
            {
                try
                {
                    //En lista skapas som ska innehålla alla spelartyper
                    var playerTypes = new List<PlayerType>(20);

                    //Skapar ett objekt av typen SqlCommand 
                    //Som används för att exekvera en lagrad procedur
                    var cmd = new SqlCommand("AppSchema.uspGetPlayerTypes", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Öppnar anslutningen till databasen
                    conn.Open();

                    //Den lagrade proceduren kommer att returnera flera rader som
                    //SqlDataReader-objektet tar hand om 
                    using (var reader = cmd.ExecuteReader())
                    {
                        //hämtar indexet på kolumnerna
                        var PlTypeIdIndex = reader.GetOrdinal("PlTypeID");
                        var plTypeIndex = reader.GetOrdinal("PlType");

                        //Medan det finns data att läsa 
                        while (reader.Read())
                        {
                            //Lägger till ny spelartyp i listan playerTypes
                            playerTypes.Add(new PlayerType
                            {
                                PlTypeID = reader.GetByte(PlTypeIdIndex),
                                PlType = reader.GetString(plTypeIndex)

                            });
                        }
                    }

                   //Avallokerar minne
                    playerTypes.TrimExcess();

                    //Returnerar en referens till listan playerTypes
                    return playerTypes;
                }

                catch
                {
                    throw new ApplicationException("ett fel uppstod när spelartyper skulle hämtas");
                }
            }
        }

        //Hämtar ut en specifik spelartyp
        public PlayerType GetPlayerTypeByID(int PlTypeID)
        {
            //anslutningsobjekt till databasen
            using (SqlConnection conn = createConnection())
            {
                try
                {
                    //Skapar ett objekt av typen SqlCommand 
                    //Som används för att exekvera en lagrad procedur
                    SqlCommand cmd = new SqlCommand("AppSchema.uspGetPlayerTypeByID", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Parameter i den lagrade proceduren
                    cmd.Parameters.AddWithValue("@PlTypeID", PlTypeID);

                    //Öppnar anslutningen till databasen
                    conn.Open();

                    //Den lagrade proceduren kan returnera flera rader. 
                    //Det tar SqlDataReader-objektet hand om 
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        //hämtar indexet på kolumnen
                        var PlTypeIndex = reader.GetOrdinal("PlType");

                        //Medan det finns data att läsa 
                        while (reader.Read())
                        {

                            //Returnerar en referens till  det skapade PlayerType-objektet
                            return new PlayerType
                            {
                               PlType = reader.GetString(PlTypeIndex),
                               PlTypeID = (byte) PlTypeID
                            };
                        }
                    }

                    //Om det inte finns någon spelartyp på det medskickade ID
                    return null;
                }

                catch
                {
                    throw new ApplicationException("Ett fel inträffade vid hämtning av spelare");
                }
            }
        }
        }
    }
