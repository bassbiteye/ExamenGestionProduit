using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamenGestionProduit.Helpers;
using ExamenGestionProduit.Models;
using ExamenGestionProduit.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamenGestionProduit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private readonly ExamenContext _context;

        public UsersController(IUserService userService, ExamenContext context)
        {
            _userService = userService;
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
        [HttpPost("register")]
        public JsonResult Register([Bind("FirstName,LastName,Username,Password")] User user)
        {
            _context.Add(user);
            _context.SaveChanges();

            return new JsonResult("Inscription réussie");
        }
     //   [Authorize]
        [HttpGet]
        public JsonResult GetAll()
        {
            return new JsonResult( _context.users.ToList());
        }
    }
}
