using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;



using GeoJSON.Net.Feature;
using GeoJSON.Net.Geometry;

using Newtonsoft.Json;
using System.Reflection;
using API.Models;

namespace API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class locationController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public locationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public string Get()
        {
            string cnxS = _configuration.GetConnectionString("CitoyenAppCon");
            List<Location> list = new List<Location>();
            using (SqlConnection cnx = new SqlConnection(cnxS))
            {
                string request = "Select * from locations";
                cnx.Open();
                
                using (SqlCommand cmd = new SqlCommand(request, cnx))
                {
                    

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {

                        while (rdr.Read())
                        {
                            string icon = Convert.ToBoolean(rdr["estUnfoyerdecontamination"]) ? @"https://res.cloudinary.com/db4y2bix8/image/upload/v1609864090/1200px-Red_dot.svg_ndwx4r.png" : @"https://res.cloudinary.com/db4y2bix8/image/upload/v1609865441/Green_Point_vjfeks.gif";
                            list.Add(new Location(Convert.ToString(rdr["adresse"]),
                                Convert.ToDouble(rdr["latitude"]),
                                Convert.ToDouble(rdr["longitude"]),
                                icon));

                        }
                    }
                    cnx.Close();
                }
            }

            var envelope = new
            {
                type = "FeatureCollection",
                features = list
            };


            string geo_json = JsonConvert.SerializeObject(envelope);

            return geo_json;
        }

        [HttpPost]
        public JsonResult Post(LocationPost location)
        {
            string cnxS = _configuration.GetConnectionString("CitoyenAppCon");

            using (var cnx = new SqlConnection(cnxS))
            {
                cnx.Open();
                using (var command = new SqlCommand("Books_Insert", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {

                    command.Parameters.Add(new SqlParameter("@latitude", location.latitude));
                    command.Parameters.Add(new SqlParameter("@longitude", location.longitude));
                    command.Parameters.Add(new SqlParameter("@adresse", location.adresse));
                    command.ExecuteNonQuery();
                }

            }
            return new JsonResult("Added Succesfully");
        }

    }
}
