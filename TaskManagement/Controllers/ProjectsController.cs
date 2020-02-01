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
    public class ProjectsController : ControllerBase
    {
        private readonly ProjectService _projectService;


        public ProjectsController(ProjectService service)
        {
            _projectService = service;
        }

        //GET: api/Projects
        [HttpGet]
        [Authorize]
        public string Oi() => $"Bem vindo, {User.Identity.Name}";
        // public async Task<ActionResult<IEnumerable<Project>>> Index()
        // {

        //     return await _projectService.GetProjects();
        // }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> Show(long id)
        {

            var project = await _projectService.GetProjects(id);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }



        [HttpPost]
        public async Task<ActionResult<Project>> PostProject([FromBody]Project project)
        {

            await _projectService.CreateProject(project);
            return CreatedAtAction(nameof(Index), new { id = project.Id }, project);

        }
    }
}