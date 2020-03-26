using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IndividualProjectCapstone.Data;
using IndividualProjectCapstone.Models;
using System.Security.Claims;

namespace IndividualProjectCapstone.Controllers
{
    public class DevelopersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DevelopersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Developers
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var developer = _context.Developers.FirstOrDefault(a => a.UserId == userId);
            if (developer is null)
            {
                return RedirectToAction("Create");
            }
            //DeveloperViewModel _developerViewModel = new DeveloperViewModel();
            //_developerViewModel.CurrentUser = developer;
            //foreach (var eachProject in _context.Projects)
            //{
            //    var projectId = eachProject.Id;
            //    ProjectViewModel _projectViewModel = new ProjectViewModel();
            //    _projectViewModel.Project = eachProject;
            //    _projectViewModel.Openings = _context.RoleOpenings.Where(m => m.ProjectId == projectId).ToList();
            //    _projectViewModel.DevelopersInProject = _context.Developers.Where(m => _context.ProjectMembers.Where(p => p.ProjectId == projectId).Select(p => p.DeveloperId).ToList().Contains(m.Id)).ToList();
            //    _developerViewModel.Add(_projectViewModel);
            //}

            List<Project> projects = _context.Projects
                .Include(l => l.Developer)
                .ToList();

            foreach(Project project in projects)
            {
                project.Openings = _context.Openings.Where(o => o.ProjectId == project.Id).ToList();
                var developerIds = _context.ProjectMembers.Where(p => p.ProjectId == project.Id)
                             .Select(p => p.DeveloperId)
                             .ToList();
                project.DeveloperMembers = _context.Developers
                             .Where(m => developerIds.Contains(m.Id))
                             .ToList();
            }
            DeveloperViewModel _developerViewModel = new DeveloperViewModel();
            _developerViewModel.CurrentUser = developer;
            _developerViewModel.AllProjects = projects;
            return View(_developerViewModel);
            //List<Projects>
        }

        // GET: Own Projects
        public async Task<IActionResult> ProjectIndex()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var developer = _context.Developers.FirstOrDefault(a => a.UserId == userId);
            if (developer is null)
            {
                return RedirectToAction("Create");
            }
            List<Project> projects = _context.Projects.Where(m => m.DeveloperId == developer.Id).ToList();

            foreach (Project project in projects)
            {
                project.Openings = _context.Openings.Where(o => o.ProjectId == project.Id).ToList();
                var developerIds = _context.ProjectMembers.Where(p => p.ProjectId == project.Id)
                             .Select(p => p.DeveloperId)
                             .ToList();
                project.DeveloperMembers = _context.Developers
                             .Where(m => developerIds.Contains(m.Id))
                             .ToList();
            }
            DeveloperViewModel _developerViewModel = new DeveloperViewModel();
            _developerViewModel.CurrentUser = developer;
            _developerViewModel.AllProjects = projects;
            return View(_developerViewModel);
            //List<Projects>
        }

        // GET: Roles by Id
        public async Task<IActionResult> RoleIndex(int? Id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var developer = _context.Developers.FirstOrDefault(a => a.UserId == userId);
            if (developer is null)
            {
                return RedirectToAction("Create");
            }
            List<Project> projects = _context.Projects.Where(m => m.DeveloperId == developer.Id).ToList();

            foreach (Project project in projects)
            {
                project.Openings = _context.Openings.Where(o => o.ProjectId == project.Id).ToList();
                var developerIds = _context.ProjectMembers.Where(p => p.ProjectId == project.Id)
                             .Select(p => p.DeveloperId)
                             .ToList();
                project.DeveloperMembers = _context.Developers
                             .Where(m => developerIds.Contains(m.Id))
                             .ToList();
            }
            DeveloperViewModel _developerViewModel = new DeveloperViewModel();
            _developerViewModel.CurrentUser = developer;
            _developerViewModel.AllProjects = projects;
            return View(_developerViewModel);
            //List<Projects>
        }

        // GET: Developers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var developer = await _context.Developers
                .Include(d => d.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (developer == null)
            {
                return NotFound();
            }

            return View(developer);
        }

        // GET: Developers/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Developers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Developer developer)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var _developer = developer;
                _developer.UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                _context.Developers.Add(_developer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", developer.UserId);
            return RedirectToAction(nameof(Index));
        }
        // GET: Projects/Create
        public IActionResult CreateProject()
        {
            
            return View();
        }

        // POST: Developers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProject(Project project)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var developer = _context.Developers.FirstOrDefault(a => a.UserId == userId);
                var _project = project;
                _project.DeveloperId = developer.Id;
                _context.Projects.Add(_project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ProjectIndex));
            }
            return View(project);
        }

        // GET: CreateRole/Create
        public IActionResult CreateRole(int? Id)
        {
            var projectId = Id;
            var _project = _context.Projects.Where(m => m.Id == projectId).FirstOrDefault();
            RoleViewModel roleViewModel = new RoleViewModel();
            roleViewModel.Project = _project;
            return View(roleViewModel);
        }

        // POST: Developers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRole(RoleViewModel roleViewModel)
        {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var viewOpening = roleViewModel.Opening;
                Opening newOpening = new Opening();
                var currentProjectId = roleViewModel.Project.Id;
                newOpening = viewOpening;
                newOpening.ProjectId = currentProjectId;
                _context.Openings.Add(newOpening);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ProjectIndex));

        }


        // GET: Developers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var developer = await _context.Developers.FindAsync(id);
            if (developer == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", developer.UserId);
            return View(developer);
        }

        // POST: Developers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,UserId,DeveloperType,ProficiencyLevel,AboutUser")] Developer developer)
        {
            if (id != developer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(developer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeveloperExists(developer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", developer.UserId);
            return View(developer);
        }

        // GET: Developers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var developer = await _context.Developers
                .Include(d => d.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (developer == null)
            {
                return NotFound();
            }

            return View(developer);
        }

        // POST: Developers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var developer = await _context.Developers.FindAsync(id);
            _context.Developers.Remove(developer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeveloperExists(int id)
        {
            return _context.Developers.Any(e => e.Id == id);
        }
    }
}
