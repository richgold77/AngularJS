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
    public class temp2017_1Controller : ApiController
    {
        // GET api/<controller>
        public IEnumerable<temp2017_1ViewModel> Get()
        {
            var cnstr = ConfigurationManager.ConnectionStrings["otherConnectionString"].ConnectionString;

            using (var conn = new SqlConnection(cnstr))
            {

                string temp2017_1Sql = @"SELECT TOP 20 * FROM temp2017_1 ORDER BY rec_time DESC";

                var myTemp2017_1 = conn.Query<temp2017_1ViewModel>(temp2017_1Sql).ToList();

                List<temp2017_1ViewModel> temp2017_1List = new List<temp2017_1ViewModel>();

                foreach (var item in myTemp2017_1)
                {
                    string test_time = item.rec_time.ToString("yyyy");

                    temp2017_1List.Add(new temp2017_1ViewModel()
                    {
                        id = item.id,
                        rec_time = item.rec_time,
                        
                        website = item.website,
                        password = item.password
                    });

                }

                return temp2017_1List;
            }
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public Object Post([FromBody]temp2017_1ViewModel value)
        {
            var cnstr = ConfigurationManager.ConnectionStrings["otherConnectionString"].ConnectionString;

            value.rec_time = DateTime.Now;

            using (var conn = new SqlConnection(cnstr))
            {
                //var order = new Order() { ShipName = "sherry", giftwrap = true };

                var sqlCommand = @"INSERT INTO temp2017_1 (rec_time, website, password) VALUES(@rec_time, @website, @password ); ";

                conn.Execute(sqlCommand, value);

                int tempNum = 0;

                var temps = conn.Query<temp2017_1ViewModel>("SELECT * FROM temp2017_1 ORDER BY rec_time DESC");

                foreach (var item in temps)
                {
                    tempNum = item.id;
                }

                return tempNum;
            }
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