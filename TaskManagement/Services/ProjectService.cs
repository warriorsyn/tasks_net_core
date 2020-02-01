using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Models;
using TaskManagement.Services;

namespace TaskManagement.Services
{
    public class ProjectService
    {

        private readonly  TaskManagementeContext _context;

        public ProjectService(TaskManagementeContext context)
        {
            _context = context;
        }

  
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects() {
            return await _context.Project.Include(join => join.TodoItem).ToListAsync();
        }

   
        public async Task<ActionResult<Project>> GetProjects(long id) {
            return await _context.Project.FindAsync(id);
        }

        public async Task CreateProject(Project project)
        {
            _context.Project.Add(project);
            await _context.SaveChangesAsync();
        }

    }
}
