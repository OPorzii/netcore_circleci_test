using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace netcore_circleci_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2", "value3", "value4" };
        }

        // GET api/values/5
        
        [HttpGet("from2client")]
        public async Task<string>  GetFromClientTwo()
        {
            using (var client = new HttpClient())
            {
                var url = new Uri($"http://34.87.40.137:8000/api/values");
                var response = await client.GetAsync(url);
                string resStr;
                using (var content = response.Content)
                {
                    resStr = await content.ReadAsStringAsync();
                }

                string result = "Hello Message From WebAPI 1\n\n" + resStr;
                
                return result;
            }

        }


    }
}
