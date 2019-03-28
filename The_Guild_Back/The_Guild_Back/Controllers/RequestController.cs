using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using The_Guild_Back.API.Models;
using The_Guild_Back.BLL;

namespace The_Guild_Back.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IAPIMapper _mapp; //to map BLL to API and vice-versa

        public RequestController(IRepository Repository, IAPIMapper Mapper)
        {
            _repo = Repository;
            _mapp = Mapper;
        }

        // GET: api/request
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IEnumerable<APIRequest> Get()
        {
            //repo call for all Request
            var request = _repo.GetAllRequests().Select(x => _mapp.Map(x));
            return request;

            ////if no Request at all,
            //return NotFound(); 
            //won't work with nick's automatic 200 OK wrapping of IEnumerable?
            //(needs to return actual ActionResult)
        }

        // GET: api/request/5
        [HttpGet("{id}", Name = "GetRequest")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIRequest>> GetById(int id)
        {
            //repo.get call for specific Request id
            if (await _repo.GetRequestByIdAsync(id) is Request request) //if found
            {
                return _mapp.Map(request);
            }

            //if request not found,
            return NotFound();
        }

        // POST: api/request
        [HttpPost]
        [ProducesResponseType(typeof(Request), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] APIRequest apiRequest)
        {
            //validate
            //if problem, return 400

            //repo add
            Request request = _mapp.Map(apiRequest);
            request.Id = _repo.AddRequest(request);
            APIRequest newApiRequest = _mapp.Map(request);

            return CreatedAtAction(nameof(GetById), new { id = newApiRequest.Id },
                newApiRequest); //201

        }

        // PUT: api/request/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] APIRequest apiRequest)
        {
            //validate    
            //if problem, return 400

            //need repo methods implemented
            if (await _repo.GetRequestByIdAsync(id) is Request request) //if found
            {
                //update with given Request info
                Request upRequest = _mapp.Map(apiRequest);
                await _repo.UpdateRequestAsync(upRequest);
                return NoContent(); // 204
            }

            //if not found, 
            return NotFound(); //404

        }

        // DELETE: api/request/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _repo.GetRequestByIdAsync(id) is Request request) //if found
            {
                //delete Request
                await _repo.DeleteRequestAsync(request.Id);
                return NoContent(); // 204
            }

            //if not found,
            return NotFound(); //404
        }
    }
}