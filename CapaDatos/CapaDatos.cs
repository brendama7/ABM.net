using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using CapaEntidades;
using System.Configuration;

namespace CapaDatos
{
    public class CDTerritories
    {
        private static string GetConection()
        {
            return ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;
        }
        SqlCommand comando = new SqlCommand();
        SqlConnection cn = new SqlConnection(CDTerritories.GetConection());
        public SqlConnection AbrirConexion()
        {

            if (cn.State == ConnectionState.Closed)
                cn.Open();
            return cn;
        }
        public SqlConnection CerrarConexion()
        {

            if (cn.State == ConnectionState.Open)
                cn.Close();
            return cn;
        }
        public void Insertar(string idT, string descT, string descR)
        {
            try
            {
                cn.Open();
                comando = new SqlCommand("InsertarT", cn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@idT", idT));
                comando.Parameters.Add(new SqlParameter("@descT", descT));
                comando.Parameters.Add(new SqlParameter("@descR", descR));
                comando.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
            finally { cn.Close(); }
        }
        public void Modificar(string idT, string descT, string descR)
        {
            try
            {
                cn.Open();
                comando = new SqlCommand("ModificarT", cn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@idT", idT));
                comando.Parameters.Add(new SqlParameter("@descT", descT));
                comando.Parameters.Add(new SqlParameter("@descR", descR));
                comando.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
            finally { cn.Close(); }
        }
        public void Eliminar(string idT)
        {
            cn.Open();
            comando = new SqlCommand("EliminarT", cn);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@idT", idT));
            comando.ExecuteNonQuery();
            cn.Close();

        }
        public List<CETerritories> GetList()
        {
            List<CETerritories> territories = null;
            cn.Open();
            comando.Connection = cn;
            comando = new SqlCommand("ConsultarT", cn);
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.HasRows)
                territories = new List<CETerritories>();
            while (dr.Read())
            {
                CETerritories terr = new CETerritories();
                terr.TerritoryID = Convert.ToString(dr[0]);
                terr.TerritoryDescription = Convert.ToString(dr[1]);
                terr.RegionID = Convert.ToInt16(dr[2]);
                terr.RegionDescription = Convert.ToString(dr[3]);

                territories.Add(terr);
            }
            cn.Close();
            return territories;
        }
    }
}
