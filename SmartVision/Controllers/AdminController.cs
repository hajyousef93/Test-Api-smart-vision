﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartVision.Data;
using SmartVision.Data.Repository.Admin;
using SmartVision.ModelViews.Users;

namespace SmartVision.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _repo;

        public AdminController(IAdminRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Route("GetAllUser")]
        public async Task<IEnumerable<ApplicationUser>> GetAllUser()
        {
            var users = await _repo.GetUsers();
            if (users == null)
            {
                return null;
            }
            return users;
        }

        [HttpGet]
        [Route("GetUser/{id}")]
        public async Task<ActionResult<ApplicationUser>> GetUser(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _repo.GetUser(id);
            if (user != null)
            {
                return user;
            }
            return BadRequest();
        }
        [HttpPut]
        [Route("EditUser")]
        public async Task<ActionResult<ApplicationUser>> EditUser(EditUserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var user = await _repo.EditUser(model);
            if (user != null)
            {
                return user;
            }
            return BadRequest();
        }



        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser(AddUserModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _repo.AddUser(model);
                if (user != null)
                {
                    return Ok();
                }

            }
            return BadRequest();
        }

        [HttpPost]
        [Route("DeleteUser")]
        public async Task<IActionResult> DeleteUser(string ids)
        {
            
            var result = await _repo.DeleteUser(ids);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}