using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MvsixAPI.Models;
using MvsixAPI.Utils;
using System.Data;

namespace MvsixAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {

        readonly SqlConnection conn = new(StringConstants.SqlConnString);

        // GET: api/<ArtistsController>
        [HttpGet]
        public IEnumerable<Artist> Get()
        {
            conn.Open();
            SqlCommand command = conn.CreateCommand();

            command.CommandText = StringConstants.MvsixProcAartist;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ACCION", 4);
            
            List<Artist> artists = new();
            
            using (SqlDataReader artistReader = command.ExecuteReader())
            {
                while (artistReader.Read())
                {
                    artists.Add(new Artist() {
                        Id = artistReader.GetInt32("ARTISTID"),
                        ArtistName = artistReader.GetString("ARTISTNAME"),
                        ArtistDescription = artistReader.GetString("ARTISTDESCRIPTION"),
                    });
                }
            };
            conn.Close();
            return artists;
        }

        // GET api/<ArtistsController>/5
        [HttpGet("{id}")]
        public Artist Get(int id)
        {
            conn.Open();
            SqlCommand command = conn.CreateCommand();

            command.CommandText = StringConstants.MvsixProcAartist;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ACCION", 5);
            command.Parameters.AddWithValue("@ARTISTID", id);

            Artist artist = new();
            
            using (SqlDataReader artistReader = command.ExecuteReader())
            {
                while (artistReader.Read())
                {
                    artist = new Artist()
                    {
                        Id = artistReader.GetInt32("ARTISTID"),
                        ArtistName = artistReader.GetString("ARTISTNAME"),
                        ArtistDescription = artistReader.GetString("ARTISTDESCRIPTION"),
                    };
                }
            };
            conn.Close();
            return artist;
        }

        // POST api/<ArtistsController>
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Artist artist)
        {
            conn.Open();
            SqlCommand command = conn.CreateCommand();

            command.CommandText = StringConstants.MvsixProcAartist;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ACCION", 1);
            command.Parameters.AddWithValue("@ARTISTNAME", artist.ArtistName);
            command.Parameters.AddWithValue("@ARTISTDESCRIPTION", artist.ArtistDescription);

            command.ExecuteNonQuery();

            conn.Close();

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }

        // PUT api/<ArtistsController>/5
        [HttpPut]
        public HttpResponseMessage Put([FromBody] Artist artist)
        {
            conn.Open();
            SqlCommand command = conn.CreateCommand();

            command.CommandText = StringConstants.MvsixProcAartist;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ACCION", 2);
            command.Parameters.AddWithValue("@ARTISTID", artist.Id);
            command.Parameters.AddWithValue("@ARTISTNAME", artist.ArtistName);
            command.Parameters.AddWithValue("@ARTISTDESCRIPTION", artist.ArtistDescription);

            command.ExecuteNonQuery();

            conn.Close();

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }

        // DELETE api/<ArtistsController>/5
        [HttpDelete("{id}")]
        public HttpResponseMessage Delete(int id)
        {
            conn.Open();
            SqlCommand command = conn.CreateCommand();

            command.CommandText = StringConstants.MvsixProcAartist;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ACCION", 2);  

            command.ExecuteNonQuery();
            
            conn.Close();
            
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }
    }
}
