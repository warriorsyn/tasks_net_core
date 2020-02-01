using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using TaskManagement.Models;
using TaskManagement.Services;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly TaskManagementeContext _context;


        public UserController(TaskManagementeContext context)
        {
            _context = context;
        }

        //GET: api/Projects
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> CreateAccount([FromBody] User user)
        {

            var alreadyExists = await _context.User.Where(x => x.Email == user.Email).FirstOrDefaultAsync();

            if (alreadyExists != null)
            {
                return BadRequest(new { message = "Email already exists!" });
            }



            user.Password = CrypterService.HashPassword(user.Password);

            _context.User.Add(user);

            await _context.SaveChangesAsync();

            return user;
        }


    }
}
