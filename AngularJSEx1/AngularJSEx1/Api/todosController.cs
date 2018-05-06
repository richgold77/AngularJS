using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Configuration;
using Dapper;
using System.Data.SqlClient;
using AngularJSEx1.Models.ViewModels;


namespace AngularJSEx1.Api
{
    public class todosController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<todosViewModel> Get()
        {
            var cnstr = ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;

            using (var conn = new SqlConnection(cnstr))
            {
                string todosSql = "SELECT * FROM todos";

                var myTodosSql = conn.Query<todosViewModel>(todosSql).ToList();
                List<todosViewModel> todos_List = new List<todosViewModel>();

                foreach (var item in myTodosSql)
                {
                    todos_List.Add(new todosViewModel() {
                        id = item.id,
                        action = item.action,
                        complete = item.complete
                    });
                }

                return todos_List;

            }

        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}