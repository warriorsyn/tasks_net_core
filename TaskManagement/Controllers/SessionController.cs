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
    public class SessionController : ControllerBase
    {
        private readonly TaskManagementeContext _context;


        public SessionController(TaskManagementeContext context)
        {
            _context = context;
        }

        //GET: api/Projects
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Auth([FromBody] User user)
        {

            var loggedUser = await _context.User
                .Where(x => x.Email == user.Email)
                .FirstOrDefaultAsync();


            if (loggedUser == null)
                return NotFound(new { message = "User or password incorrect!" });

            if (!CrypterService.ComparePassword(user.Password, loggedUser.Password))
                return NotFound(new { message = "User or password incorrect!" });

            var token = TokenService.GenerateToken(loggedUser);

            loggedUser.Password = null;


            return new
            {
                user = loggedUser,
                token = token
            };
        }


    }
}
