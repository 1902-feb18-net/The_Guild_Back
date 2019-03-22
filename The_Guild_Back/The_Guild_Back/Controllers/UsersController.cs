using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using The_Guild_Back.BLL;

namespace The_Guild_Back.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/Users
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Users>> Get()
        {
            //repo call for all users
            //users = 
            //return users;

            //if no users at all,
            return NotFound();
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Users> GetById(int id)
        {
            //repo.get call for specific user id
            //user = 
            //return user;

            //if user not found,
            return NotFound();
        }

        // POST: api/Users
        [HttpPost]
        [ProducesResponseType(typeof(Users), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Users user)
        {
            //validate
            //if problem, return 400

            //repo add

            //return CreatedAtAction(nameof(GetById), new { id = user.Id}, user); //201

            
            return NotFound(); //remove this when implemented
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(int id, [FromBody] Users user)
        {
            //validate 

            //repo.get call for specific user id

            //update with given user info

            //repo.update call

            //return NoContent(); // 204

            //if not found,
            return NotFound(); //404
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            //repo.get call for specific user id

            //repo.delete call
            //return NoContent(); // 204

            //if not found
            return NotFound(); //404
        }
    }
}
