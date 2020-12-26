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
    public class CitoyenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        
        public CitoyenController(IConfiguration configuration)
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
                string request = "Select * from citoyens";
                cnx.Open();
                
                using (SqlCommand cmd = new SqlCommand(request, cnx))
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
