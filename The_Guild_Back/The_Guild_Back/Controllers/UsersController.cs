﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using The_Guild_Back.API.Models;
using The_Guild_Back.BLL;

namespace The_Guild_Back.API.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IAPIMapper _mapp;

        public UsersController(IRepository Repository, IAPIMapper Mapper)
        {
            _repo = Repository;
            _mapp = Mapper;
        }

        // GET: api/Users
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IEnumerable<APIUsers> Get()
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
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Users> GetById(int id)
        {
            //repo.get call for specific user id
            if (_repo.GetUserById(id) is Users user)
            {
                return user;
            }

            //if user not found,
            return NotFound();
        }

        // POST: api/Users
        [HttpPost]
        [ProducesResponseType(typeof(Users), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] APIUsers apiUser)
        {
            //validate
            //if problem, return 400

            //repo add
            Users user = _mapp.Map(apiUser);
            user.Id =  _repo.AddUser(user);
            _repo.Save();
            APIUsers newApiUser = _mapp.Map(user);

            return CreatedAtAction(nameof(GetById), new { id = newApiUser.Id },
                newApiUser); //201

        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(int id, [FromBody] APIUsers apiUser)
        {
            //validate    
            //if problem, return 400

            //need repo methods implemented
            if (_repo.GetUserById(id) is Users user) //if found
            {
                //update with given user info
                Users upUser = _mapp.Map(apiUser);
                _repo.UpdateUser(upUser);
                _repo.Save();
                return NoContent(); // 204
            }

            //if not found, 
            return NotFound(); //404

        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            if (_repo.GetUserById(id) is Users user) //if found
            {
                //delete user
                _repo.DeleteUser(user.Id);
                _repo.Save();
                return NoContent(); // 204
            }

            //if not found,
            return NotFound(); //404
        }
    }
}
