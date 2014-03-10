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
        public IEnumerable<PlayerType> GetPlayerTypes()
        {
            using (var conn = createConnection())
            {
                try
                {
                    var playerTypes = new List<PlayerType>(100);

                    var cmd = new SqlCommand("AppSchema.uspGetPlayerTypes", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var PlTypeIdIndex = reader.GetOrdinal("PlTypeID");
                        var plTypeIndex = reader.GetOrdinal("PlType");

                        while (reader.Read())
                        {
                            playerTypes.Add(new PlayerType
                            {
                                PlTypeID = reader.GetByte(PlTypeIdIndex),
                                PlType = reader.GetString(plTypeIndex)

                            });
                        }
                    }

                    playerTypes.TrimExcess();

                    return playerTypes;
                }

                catch
                {
                    throw new ApplicationException("ett fel uppstod när spelartyper skulle hämtas");
                }
            }
        }

        public PlayerType GetPlayerTypeByID(int PlTypeID)
        {
            using (SqlConnection conn = createConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("AppSchema.uspGetPlayerTypeByID", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PlTypeID", PlTypeID);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var PlTypeIndex = reader.GetOrdinal("PlType");
                        

                        while (reader.Read())
                        {
                            
                            return new PlayerType
                            {
                               PlType = reader.GetString(PlTypeIndex),
                               PlTypeID = (byte) PlTypeID
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
        }
    }
