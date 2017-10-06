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
    public class Album_AD
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MvcMusicStoreEntities"].ConnectionString;

        private Album LlenarEntidad(IDataReader reader)
        {
            Album rAlbum = new Album();

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AlbumId'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["AlbumId"]))
                    rAlbum.AlbumId = Convert.ToInt32(reader["AlbumId"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='GenreId'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["GenreId"]))
                    rAlbum.GenreId = Convert.ToInt32(reader["GenreId"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NameGe'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["NameGe"]))
                    rAlbum.NameGe = Convert.ToString(reader["NameGe"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ArtistId'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["ArtistId"]))
                    rAlbum.ArtistId = Convert.ToInt32(reader["ArtistId"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NameAr'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["NameAr"]))
                    rAlbum.NameAr = Convert.ToString(reader["NameAr"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Title'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["Title"]))
                    rAlbum.Title = Convert.ToString(reader["Title"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Price'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["Price"]))
                    rAlbum.Price = Convert.ToInt32(reader["Price"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AlbumArtUrl'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["AlbumArtUrl"]))
                    rAlbum.AlbumArtUrl = Convert.ToString(reader["AlbumArtUrl"]);
            }
            return rAlbum;
        }

        public Album BuscarAlbumPorId(int id)
        {
            Album entidad = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_mvcstore_Album_Busca", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["Timeout_AccessData"]);
                    // Pasando el parametro id al procedimiento almacenado
                    cmd.Parameters.AddWithValue("@idAlb", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Pasa la query a una clase
                            entidad = LlenarEntidad(reader);
                        }
                    }
                }
            }

            return entidad;
        }

        public List<Album> ListarAlbum()
        {
            Album entidad = null;
            List<Album> listaAlbums = new List<Album>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_mvcstore_Album_Lista", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["Timeout_AccessData"]);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Pasa la query a una clase
                            entidad = LlenarEntidad(reader);
                            listaAlbums.Add(entidad);
                        }
                    }
                }
            }

            return listaAlbums;
        }

        public Album InsertarItem(Album ParamEnt)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                
                using (SqlCommand cmd = new SqlCommand("usp_Album_insert", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["Timeout_AccessData"]);
                    cmd.Parameters.AddWithValue("@as_GenreId",ParamEnt.GenreId);
                    cmd.Parameters.AddWithValue("@as_ArtistId", ParamEnt.ArtistId);
                    cmd.Parameters.AddWithValue("@as_Title", ParamEnt.Title);
                    cmd.Parameters.AddWithValue("@as_Price", ParamEnt.Price);
                    cmd.Parameters.AddWithValue("@as_AlbumArtUrl", ParamEnt.AlbumArtUrl);

                    conn.Open();
                    ParamEnt.AlbumId = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();
                }
            }

            return ParamEnt;
        }
    }
}
