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
            var points = new List<Point>();
            using (SqlConnection cnx = new SqlConnection(cnxS))
            {
                string request = "Select * from locations";
                cnx.Open();

                using (SqlCommand cmd = new SqlCommand(request, cnx))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Position position = new Position(Convert.ToDouble(rdr["latitude"]), Convert.ToDouble(rdr["longitude"]));
                        points.Add(new Point(position));
                    }

                    rdr.Close();
                    cnx.Close();
                }
            }
            var multiPoint = new MultiPoint(points);

            var geojson = JsonConvert.SerializeObject(multiPoint);

            return geojson;
        }

    }
}
