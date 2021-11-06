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
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class listtasksController : ControllerBase
    {
        private readonly KwansoContext _context;

        public listtasksController(KwansoContext context)
        {
            _context = context;
        }

        // GET: api/Task
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskInfo>>> GetTaskInfo()
        {
            return await _context.TaskInfo.ToListAsync();
        }

        // DELETE: 
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskInfo>> DeleteTaskInfo(int id)
        {
            var taskInfo = await _context.TaskInfo.FindAsync(id);
            if (taskInfo == null)
            {
                return NotFound();
            }

            _context.TaskInfo.Remove(taskInfo);
            await _context.SaveChangesAsync();

            return taskInfo;
        }
    }
}
