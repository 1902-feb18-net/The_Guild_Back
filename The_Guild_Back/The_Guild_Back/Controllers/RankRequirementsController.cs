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
    public class RankRequirementsController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IApiMapper _mapp; //to map BLL to API and vice-versa
        public RankRequirementsController(IRepository Repository, IApiMapper Mapper)
        {
            _repo = Repository;
            _mapp = Mapper;
        }


        // GET: api/RankRequirements
        [HttpGet]
        public IEnumerable<ApiRankRequirements> Get()
        {
            var request = _repo.GetAllRankRequirements().Select(x => _mapp.Map(x));
            return request;
        }

        // GET: api/RankRequirements/5
        [HttpGet("{id}", Name = "GetRankRequirements")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiRankRequirements>> GetById(int id)
        {
            if (await _repo.GetRankRequirementsByIdAsync(id) is RankRequirements rankReq) //if found
            {
                return _mapp.Map(rankReq);
            }

            //if request not found,
            return NotFound(); //404
        }

        // POST: api/RankRequirements
        [HttpPost]
        [ProducesResponseType(typeof(RankRequirements), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] ApiRankRequirements apiRankReq)
        {
            //validate
            //if problem, return 400

            //repo add
            RankRequirements RankRequest = _mapp.Map(apiRankReq);
            try
            {
                RankRequest.Id = await _repo.AddRankRequirementsAsync(RankRequest);
            }
            catch(ArgumentException)
            {
                //log it!

                return BadRequest(); 
            }
            ApiRankRequirements newApiReq = _mapp.Map(RankRequest);

            return CreatedAtAction(nameof(GetById), new { id = newApiReq.Id }, newApiReq); //201
        }

        // PUT: api/RankRequirements/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] ApiRankRequirements apiRankRequirements)
        {
            //validate    
            //if problem, return 400

            //need repo methods implemented
            if (await _repo.GetRankRequirementsByIdAsync(id) is RankRequirements RankRequirements) //if found
            {
                //update with given Ranks info
                RankRequirements upRankReqs = _mapp.Map(apiRankRequirements);
                await _repo.UpdateRankRequirementsAsync(upRankReqs);
                return NoContent(); // 204
            }

            //if not found, 
            return NotFound(); //404
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {

            if (await _repo.GetRankRequirementsByIdAsync(id) is RankRequirements RankReq) //if found
            {
                //delete Request
                await _repo.DeleteRequestAsync(RankReq.Id);
                return NoContent(); // 204
            }

            //if not found,
            return NotFound(); //404
        }
    }
}
