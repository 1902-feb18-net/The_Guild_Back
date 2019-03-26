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
    public class RanksController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IAPIMapper _mapp; //to map BLL to API and vice-versa

        public RanksController(IRepository Repository, IAPIMapper Mapper)
        {
            _repo = Repository;
            _mapp = Mapper;
        }

        // GET: api/Ranks
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IEnumerable<APIRanks> Get()
        {
            //repo call for all Ranks
            var Ranks = _repo.GetAllRanks().Select(x => _mapp.Map(x));
            return Ranks;

            ////if no Ranks at all,
            //return NotFound(); 
            //won't work with nick's automatic 200 OK wrapping of IEnumerable?
            //(needs to return actual ActionResult)
        }

        // GET: api/Ranks/5
        [HttpGet("{id}", Name = "GetRanks")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIRanks>> GetById(int id)
        {
            //repo.get call for specific Ranks id
            if (await _repo.GetRankByIdAsync(id) is Ranks Ranks) //if found
            {
                return _mapp.Map(Ranks);
            }

            //if Ranks not found,
            return NotFound();
        }

        // POST: api/Ranks
        [HttpPost]
        [ProducesResponseType(typeof(Ranks), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] APIRanks apiRanks)
        {
            //validate
            //if problem, return 400

            //repo add
            Ranks Rank = _mapp.Map(apiRanks);
            Rank.Id = _repo.AddRank(Rank);
            APIRanks newApiRanks = _mapp.Map(Rank);

            return CreatedAtAction(nameof(GetById), new { id = newApiRanks.Id },
                newApiRanks); //201

        }

        // PUT: api/Ranks/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] APIRanks apiRanks)
        {
            //validate    
            //if problem, return 400

            //need repo methods implemented
            if (await _repo.GetRankByIdAsync(id) is Ranks Ranks) //if found
            {
                //update with given Ranks info
                Ranks upRanks = _mapp.Map(apiRanks);
                await _repo.UpdateRankAsync(upRanks);
                return NoContent(); // 204
            }

            //if not found, 
            return NotFound(); //404

        }

        // DELETE: api/Ranks/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _repo.GetRankByIdAsync(id) is Ranks Ranks) //if found
            {
                //delete Ranks
                await _repo.DeleteRankAsync(Ranks.Id);
                return NoContent(); // 204
            }

            //if not found,
            return NotFound(); //404
        }
    }
}