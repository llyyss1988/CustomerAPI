using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace customerAPI.Controllers
{
    /// <summary>
    /// Person Operations
    /// </summary>
    [Produces("application/json")]
    [Route("Person")]
    public class PersonController : Controller
    {
        /// <summary>
        /// Get by Id
        /// </summary>
        /// <param name="id">Id to get</param>
        /// <returns>Person or null</returns>
        /// <response code="200">Person</response>
        /// <response code="400">Bad ID value</response>
        /// <response code="404">ID Not Found</response>
        [ProducesResponseType(typeof(Models.Person), 200)]
        [HttpGet("{id}")]
        public Models.Person Get(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("id must be a valid value", nameof(id));
            }
            var model = DataAccess.DataFactory.People.Where(p => p._id == id).FirstOrDefault();
            if(model == null)
            {
                throw new KeyNotFoundException("No Key Found Matching: " + id);
            }
            return model;
        }

        /// <summary>
        /// Search for people
        /// </summary>
        /// <param name="text">Search Text</param>
        /// <returns>Search results</returns>
        /// <response code="400">Missing Search Text</response>
        [ProducesResponseType(typeof(IEnumerable<Models.Person>), 200)]
        [HttpGet("Search/{text}")]
        public IEnumerable<Models.Person> Search(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException("Search Text must be provided", nameof(text));
            }

            var results = DataAccess.DataFactory.People.Where(p => ((p.NameFirst.Contains(text) || p.NameLast.Contains(text) || p.EMail.Contains(text)))).ToList();
            return results;
        }

    }
}