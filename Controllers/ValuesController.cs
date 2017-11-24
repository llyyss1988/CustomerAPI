using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace customerAPI.Controllers
{
    /// <summary>
    /// Values Controller
    /// </summary>
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        /// <summary>
        /// Get some values
        /// </summary>
        /// <returns>IEnumerable(string)</returns>
        // GET api/values
        [ProducesResponseType(typeof(IEnumerable<string>), 200)]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// GET api/values/5
        /// </summary>
        /// <param name="id">ID to fetch</param>
        [ProducesResponseType(typeof(string), 200)]
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// Add a value
        /// </summary>
        /// <param name="value">Value to add</param>
        /// <returns>ID of value</returns>
        [ProducesResponseType(typeof(void),200)]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public int Post( [FromBody]string value)
        {
            int id = 0;
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("message", nameof(value));
            }
            return id;
        }

        /// <summary>
        /// Update value
        /// </summary>
        /// <param name="id">(sic)</param>
        /// <param name="value">(sic)</param>
        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        [ProducesResponseType(typeof(void), 200)]
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// Delete by ID
        /// </summary>
        /// <param name="id">(sic)</param>
        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        [ProducesResponseType(typeof(void), 200)]
        public void Delete(int id)
        {
        }
    }
}
