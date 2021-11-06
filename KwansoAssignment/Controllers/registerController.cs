using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KwansoAssignment.Models;

namespace KwansoAssignment.Controllers
{
    [Route("[controller]")] // /register(POST)    it does not require any Auth or JWT just a Post Method to post
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly KwansoContext _context;

        public RegisterController(KwansoContext context)
        {
            _context = context;
        }


        // POST: Kindly head to /register to create a user in postman Post Section via Json.
        // for example
        // {  
        //     "email": "test@testRec.com",
        //     "password": "Testpassword"
        // }


    [HttpPost]
        public async Task<ActionResult<UserInfo>> PostUserInfo(UserInfo userInfo)
        {
            _context.UserInfo.Add(userInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserInfo", new { id = userInfo.Id }, userInfo);
        }
    }
}
