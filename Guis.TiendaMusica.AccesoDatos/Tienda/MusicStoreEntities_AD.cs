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
    public class MusicStoreEntities_AD
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MvcMusicStoreEntities"].ConnectionString;

        public List<MusicStoreEntities> ListarGeneroAlbum(string Generonombre)
        {
            List<MusicStoreEntities> listaP = new List<MusicStoreEntities>();
            MusicStoreEntities entidad = new MusicStoreEntities();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_mvcstore_GeneroAlbum_Lst", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombregenero", Generonombre);
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        entidad = new MusicStoreEntities();
                        entidad.GenreId = Convert.ToInt32(reader["GenreId"].ToString());
                        entidad.NameGen = reader["NameGen"].ToString();
                        entidad.Description = reader["Description"].ToString();
                        entidad.Title = reader["Title"].ToString();
                        entidad.NameArt = reader["Title"].ToString();
                        entidad.Price = Convert.ToDecimal(reader["Price"].ToString());
                        entidad.AlbumId = Convert.ToInt32(reader["AlbumId"].ToString());
                        entidad.ArtistId = Convert.ToInt32(reader["ArtistId"].ToString());

                        listaP.Add(entidad);
                    }
                }
                con.Close();
            }
            return listaP;
        }
    }
}
