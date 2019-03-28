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
    public class ProgressController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IAPIMapper _mapp; //to map BLL to API and vice-versa

        public ProgressController(IRepository Repository, IAPIMapper Mapper)
        {
            _repo = Repository;
            _mapp = Mapper;
        }

        // GET: api/Progress
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IEnumerable<APIProgress> Get()
        {
            //repo call for all Ranks
            var Progress = _repo.GetAllProgress().Select(x => _mapp.Map(x));
            return Progress;

            ////if no Ranks at all,
            //return NotFound(); 
            //won't work with nick's automatic 200 OK wrapping of IEnumerable?
            //(needs to return actual ActionResult)
        }

        // GET: api/Progress/5
        [HttpGet("{id}", Name = "GetProgress")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIProgress>> GetById(int id)
        {
            //repo.get call for specific Ranks id
            if (await _repo.GetProgressByIdAsync(id) is Progress Progress) //if found
            {
                return _mapp.Map(Progress);
            }

            //if Ranks not found,
            return NotFound();
        }
    }
}