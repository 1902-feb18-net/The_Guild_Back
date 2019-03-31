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
    public class RequestingGroupController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IApiMapper _mapp; //to map BLL to API and vice-versa

        public RequestingGroupController(IRepository Repository, IApiMapper Mapper)
        {
            _repo = Repository;
            _mapp = Mapper;
        }

        // GET: api/RequestingGroup
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IEnumerable<ApiRequestingParty> Get()
        {
            //repo call for all Ranks
            var parties = _repo.GetAllRequestingGroups().Select(x => _mapp.Map(x));
            return parties;

            ////if no Ranks at all,
            //would normally return not found (404) 
            //won't work with nick's automatic 200 OK wrapping of IEnumerable?
            //(needs to return actual ActionResult)
        }

        // GET: api/RequestingGroup/5
        [HttpGet("{id}", Name = "GetRequestingGroup")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiRequestingParty>> GetById(int id)
        {
            //repo.get call for specific Ranks id
            if (await _repo.GetRequestingGroupByIdAsync(id) is RequestingGroup party) //if found
            {
                return _mapp.Map(party);
            }

            //if not found,
            return NotFound();
        }
    }
}