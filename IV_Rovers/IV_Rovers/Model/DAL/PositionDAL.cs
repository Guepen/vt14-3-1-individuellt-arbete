using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace IV_Rovers.Model.DAL
{
    public class PositionDAL : DALBase
    {
        public void InsertPosition(Position position)
        {
            using (SqlConnection conn = createConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("AppSchema.uspAddPosition", conn);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@PlTypeID", SqlDbType.TinyInt).Value = position.PlTypeID;
                    cmd.Parameters.Add("@PlayerID", SqlDbType.Int).Value = position.PlayerID;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }

                catch
                {
                    throw new ApplicationException("Ett fel uppstod när spelare skulle läggas till");
                }
            }
        }

       /* public void Delete(int positionID)
        {
            using (SqlConnection conn = createConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("AppSchema.uspDeletePosition", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(@"PlayerID", SqlDbType.Int, 4).Value = positionID;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                catch
                {
                    throw new ArgumentException("Det gick inte att ta bort kontakten");
                }
        }*/

        public IEnumerable<Position> GetPlayerPosition(int PlayerID)
        {
            using (SqlConnection conn = createConnection())
            {
                try
                {
                    var positions = new List<Position>(25);
                    
                    SqlCommand cmd = new SqlCommand("AppSchema.uspGetPosition ", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PlayerID", PlayerID);

                    conn.Open();
                    
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var PlTypeIDIndex = reader.GetOrdinal("PlTypeID");

                        while (reader.Read())
                        {

                            positions.Add(new Position
                            {
                                PlayerID = PlayerID,
                                PlTypeID = reader.GetByte(PlTypeIDIndex)
                            });
                        }

                        positions.TrimExcess();
                        return positions;
                    }
                }

                catch
                {
                    throw new ApplicationException("Ett fel inträffade vid hämtning av spelare");
                }
            }
        }


    }
}