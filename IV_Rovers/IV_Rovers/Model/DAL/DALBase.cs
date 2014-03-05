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
        private static string _connectionString;

        static DALBase()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["ProjektConnectionString"].ConnectionString;
        }

        protected SqlConnection createConnection()
        {
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