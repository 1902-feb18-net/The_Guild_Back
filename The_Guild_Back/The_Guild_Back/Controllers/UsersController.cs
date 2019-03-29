﻿using System;
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
    public class UsersController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IApiMapper _mapp;

        public UsersController(IRepository Repository, IApiMapper Mapper)
        {
            _repo = Repository;
            _mapp = Mapper;
        }

        // GET: api/Users
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IEnumerable<ApiUsers> Get()
        {
            //repo call for all users
            var users = _repo.GetAllUsers().Select(x => _mapp.Map(x));
            return users;

            ////if no users at all,
            //return NotFound(); 
            //won't work with nick's automatic 200 OK wrapping of IEnumerable?
            //(needs to return actual ActionResult)
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "GetUser")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiUsers>> GetById(int id)
        {
                //repo.get call for specific user id
                if (await _repo.GetUserByIdAsync(id) is Users user) //if found
                {
                    return _mapp.Map(user);
                }

                //if user not found,
                return NotFound();
        }

        // POST: api/Users
        [HttpPost]
        [ProducesResponseType(typeof(Users), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] ApiUsers apiUser)
        {
            //validate
            //if problem, return 400

            //repo add
            Users user = _mapp.Map(apiUser);
            user.Id =  _repo.AddUser(user);
            ApiUsers newApiUser = _mapp.Map(user);

            return CreatedAtAction(nameof(GetById), new { id = newApiUser.Id },
                newApiUser); //201

        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] ApiUsers apiUser)
        {
            //validate    
            //if problem, return 400

            //need repo methods implemented
            if (await _repo.GetUserByIdAsync(id) is Users user) //if found
            {
                //update with given user info
                Users upUser = _mapp.Map(apiUser);
                await _repo.UpdateUserAsync(upUser);
                return NoContent(); // 204
            }

            //if not found, 
            return NotFound(); //404

        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _repo.GetUserByIdAsync(id) is Users user) //if found
            {
                //delete user
                await _repo.DeleteUserAsync(user.Id);
                return NoContent(); // 204
            }

            //if not found,
            return NotFound(); //404
        }
    }
}
