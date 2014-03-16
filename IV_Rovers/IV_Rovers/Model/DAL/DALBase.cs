using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace IV_Rovers.Model.DAL
{
    public abstract class DALBase
    {
        //Deklaration av anslutningssträng
        private static string _connectionString;

        static DALBase()
        {
           //tilldelar anslutningssträngen ett värde
            _connectionString = WebConfigurationManager.ConnectionStrings["ProjektConnectionString"].ConnectionString;
        }

        protected SqlConnection createConnection()
        {
           //Returnerar anslutningssträngen. Om ett fel inträffar kastas ett undantag
            try
            {
                return new SqlConnection(_connectionString);
            }

            catch
            {
                throw new ApplicationException("Ett oväntat fel inträffade");
            }
        }
    }
}