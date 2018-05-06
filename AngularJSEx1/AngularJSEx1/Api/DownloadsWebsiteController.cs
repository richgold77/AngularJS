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
    public class DownloadsWebsiteController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<DownloadsWebsiteViewModel> Get()
        {
            var cnstr = ConfigurationManager.ConnectionStrings["otherConnectionString"].ConnectionString;

            using (var conn = new SqlConnection(cnstr))
            {

                string downloadsWebsiteSql = @"SELECT * FROM DownloadsWebsite
                                            WHERE SortId <> 0 
                                            ORDER BY SortId
                                            ";


                var myDownloadsWebsite = conn.Query<DownloadsWebsiteViewModel>(downloadsWebsiteSql).ToList();

                List<DownloadsWebsiteViewModel> downloadsWebsiteList = new List<DownloadsWebsiteViewModel>();

                foreach (var item in myDownloadsWebsite)
                {
                    downloadsWebsiteList.Add(new DownloadsWebsiteViewModel()
                    {
                        WebsiteId = item.WebsiteId,
                        WebsiteName = item.WebsiteName,
                        SortId = item.SortId
                    });

                }

                return downloadsWebsiteList;
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