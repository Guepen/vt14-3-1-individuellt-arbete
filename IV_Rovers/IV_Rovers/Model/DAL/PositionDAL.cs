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
        //Lägger till ny positon i databasen
        public void InsertPosition(Position position)
        {
            //anslutningsobjekt till databasen
            using (SqlConnection conn = createConnection())
            {
                try
                {
                    //Skapar ett objekt av typen SqlCommand 
                    //Som används för att exekvera en lagrad procedur
                    SqlCommand cmd = new SqlCommand("AppSchema.uspAddPosition", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Parametetrar i den lagrade proceduren
                    cmd.Parameters.Add("@PlTypeID", SqlDbType.TinyInt).Value = position.PlTypeID;
                    cmd.Parameters.Add("@PlayerID", SqlDbType.Int).Value = position.PlayerID;

                    //Öppnar anslutningen till databasen
                    conn.Open();

                    //inga rader returneras därför används ExecuteNonQuery för att exekvera Proceduren
                    cmd.ExecuteNonQuery();
                }

                catch
                {
                    throw new ApplicationException("Ett fel uppstod när spelare skulle läggas till");
                }
            }
        }

       //Tar bort en position för databasen
        public void DeletePosition(Position position)
        {
            //anslutningsobjekt till databasen
            using (SqlConnection conn = createConnection())
            {
                try
                {
                    //Skapar ett objekt av typen SqlCommand 
                    //Som används för att exekvera en lagrad procedur
                    SqlCommand cmd = new SqlCommand("AppSchema.uspDeletePosition", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Parametrar i den lagrade proceduren
                    cmd.Parameters.Add(@"PlTypeID", SqlDbType.TinyInt).Value = position.PlTypeID;
                    cmd.Parameters.Add(@"PlayerID", SqlDbType.Int).Value = position.PlayerID;

                    //Öppnar anslutningen till databasen
                    conn.Open();

                    //inga rader returneras därför används ExecuteNonQuery för att exekvera Proceduren
                    cmd.ExecuteNonQuery();
                }

                catch
                {
                    throw new ArgumentException("Det gick inte att ta bort positionen");
                }
            }
        }

       //Hämtar en spelares positioner i databasen
        public IEnumerable<Position> GetPlayerPosition(int PlayerID)
        {
            //anslutningsobjekt till databasen
            using (SqlConnection conn = createConnection())
            {
                try
                {
                    //Skapar en lista på spelaren med det medskickade ID positioner
                    var positions = new List<Position>(20);

                    //Skapar ett objekt av typen SqlCommand 
                    //Som används för att exekvera en lagrad procedur
                    SqlCommand cmd = new SqlCommand("AppSchema.uspGetPosition ", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Parameter i den lagrade proceduren
                    cmd.Parameters.AddWithValue("@PlayerID", PlayerID);

                    //Öppnar anslutningen till databasen
                    conn.Open();

                    //Den lagrade proceduren kommer att returnera flera rader som
                    //SqlDataReader-objektet tar hand om 
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        //hämtar indexet på kolumnen
                        var PlTypeIDIndex = reader.GetOrdinal("PlTypeID");

                        while (reader.Read())
                        {

                           //Lägger in spelarens positioner i listan positions
                            positions.Add(new Position
                            {
                                PlayerID = PlayerID,
                                PlTypeID = reader.GetByte(PlTypeIDIndex)
                            });
                        }

                        //Avallokerar mine
                        positions.TrimExcess();

                        //Returnerar en referens till listan positions
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