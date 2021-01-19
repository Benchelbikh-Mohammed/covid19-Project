using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class infectedController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public infectedController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string cnxS = _configuration.GetConnectionString("CitoyenAppCon");
            DataTable table = new DataTable();
            using (SqlConnection cnx = new SqlConnection(cnxS))
            {
                cnx.Open();

                using (var cmd = new SqlCommand("get_infected", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    table.Load(reader);

                    reader.Close();
                    cnx.Close();
                }
            }

            return new JsonResult(table);
        }
    }
}
