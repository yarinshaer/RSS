using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;


namespace RSS.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public async Task<object> GetAsync()
        {
            try
            {
                string apiResponse;
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("https://rss.walla.co.il/feed/1?type=main"))
                    {
                        apiResponse = await response.Content.ReadAsStringAsync();
                    }
                }
                var responses = this.Request.CreateResponse(HttpStatusCode.OK);
                responses.Content = new StringContent(apiResponse, Encoding.UTF8, "application/json");
                return responses;
            }
            catch
            {
               return NotFound();
            }
          
        }

       
    }
}
