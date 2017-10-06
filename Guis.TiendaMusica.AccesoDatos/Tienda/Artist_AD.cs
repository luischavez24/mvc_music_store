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
    public class Artist_AD
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MvcMusicStoreEntities"].ConnectionString;
        
        public Artist_AD() { }

        public Artist LlenarEntidad(IDataReader reader)
        {
            Artist rArtista = new Artist();

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ArtistId'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["ArtistId"]))
                    rArtista.ArtistId = Convert.ToInt32(reader["ArtistId"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Name'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["Name"]))
                    rArtista.Name = Convert.ToString(reader["Name"]);
            }

            return rArtista;
        }

        public List<Artist> ListarArtistas()
        {
            List<Artist> listaArtistas = new List<Artist>();
            Artist entidad = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("usp_mvcstore_Artist_Lista", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["Timeout_AccessData"]);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            entidad = LlenarEntidad(reader);
                            listaArtistas.Add(entidad);
                        }
                    }
                }
            }
            return listaArtistas;
        }
    }
}
