using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

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

        [HttpPost]
        public JsonResult Post(Citoyen citoyen)
        {
            string cnxS = _configuration.GetConnectionString("CitoyenAppCon");

            using (var cnx = new SqlConnection(cnxS))
            {
                cnx.Open();
                using (var command = new SqlCommand("Citoyen_Insert", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {

                    command.Parameters.Add(new SqlParameter("@cin", citoyen.cin));
                    command.ExecuteNonQuery();
                }

            }
            return new JsonResult("Added Succesfully");
        }

        [HttpPut]
        public JsonResult Put(Citoyen citoyen)
        {
            string cnxS = _configuration.GetConnectionString("CitoyenAppCon");

            using (var cnx = new SqlConnection(cnxS))
            {
                cnx.Open();
                using (var command = new SqlCommand("Citoyen_Update", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {

                    command.Parameters.Add(new SqlParameter("@cin", citoyen.cin));
                    command.Parameters.Add(new SqlParameter("@isVaccinated", citoyen.isVaccinated));
                    command.Parameters.Add(new SqlParameter("@inQuarantine", citoyen.inQuarantine));
                    command.Parameters.Add(new SqlParameter("@isSuspect", citoyen.isSuspect));
                    command.Parameters.Add(new SqlParameter("@type", citoyen.type));
                    command.ExecuteNonQuery();
                }

            }
            return new JsonResult("Updated Succesfully");
        }


    }
}
