using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Guis.TiendaMusica.Entidades.Tienda;

namespace Guis.TiendaMusica.AccesoDatos.Tienda
{

    
    public class Genre_AD
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MvcMusicStoreEntities"].ConnectionString;

        public Genre_AD() { }

        #region Data Reader

        public Genre LlenarEntidad(IDataReader reader)
        {
            Genre rGenero = new Genre();

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='GenreId'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["GenreId"]))
                    rGenero.GenreId = Convert.ToInt32(reader["GenreId"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Name'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["Name"]))
                    rGenero.Name = Convert.ToString(reader["Name"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Description'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["Description"]))
                    rGenero.Description = Convert.ToString(reader["Description"]);
            }

            return rGenero;
        }

        #endregion

        public List<Genre> ListarGeneros()
        {
            List<Genre> listaGeneros = new List<Genre>();
            Genre entidad = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_listar_generos", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["Timeout_AccessData"]);
                    
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            entidad = LlenarEntidad(reader);
                            listaGeneros.Add(entidad);
                        }
                    }
                }
            }
            return listaGeneros;
        }

    }
}
