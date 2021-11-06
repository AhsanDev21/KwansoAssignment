using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KwansoAssignment.Models;
using Microsoft.AspNetCore.Authorization;

namespace KwansoAssignment.Controllers
{
    [Authorize] // its token is : Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJLd2Fuc29TZXJ2aWNlQWNjZXNzVG9rZW4iLCJqdGkiOiJkMDE3NjBiMS02N2QwLTRlNGEtOTM5Mi0xYzkwNDQ4MDU4YmIiLCJpYXQiOiIxMS82LzIwMjEgNTowOToxMyBQTSIsIklkIjoiMyIsIkVtYWlsIjoidGVzdEB0ZXN0UmVjLmNvbSIsIkNyZWF0ZWRBdCI6Ijg6NTM6MzMgUE0iLCJVcGRhdGVkQXQiOiI4OjUzOjMzIFBNIiwiZXhwIjoxNjM2MzA0OTU2LCJpc3MiOiJLd2Fuc29BdXRoZW50aWNhdGlvblNlcnZlciIsImF1ZCI6Ikt3YW5zb1NlcnZpY2VQb3N0bWFuQ2xpZW50In0.2en1NkzkjUbvxd630vzGG3P3jhVO83NbHUwUd0e6i6M
    [Route("[controller]")] // /createtask(POST) 
    [ApiController]
    public class createtaskController : ControllerBase
    {
        private readonly KwansoContext _context;

        public createtaskController(KwansoContext context)
        {
            _context = context;
        }

        // POST: Kindly head to /createtask to create a task in postman Post Section via Json.
        // for example
        // {
        //   "taskName": "Fifth Task"
        // }
        [HttpPost]
        public async Task<ActionResult<TaskInfo>> PostTaskInfo(TaskInfo taskInfo)
        {
            _context.TaskInfo.Add(taskInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskInfo", new { id = taskInfo.Id }, taskInfo);
        }

    }
}
