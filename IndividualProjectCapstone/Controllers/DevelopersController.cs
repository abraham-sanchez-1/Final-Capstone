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
using SendGrid;
using SendGrid.Helpers.Mail;

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
            var _opening = await _context.Openings.Where(m => m.Id == Id).FirstOrDefaultAsync();
            PendingApplicationViewModel _pendingApplicationViewModel = new PendingApplicationViewModel();
            _pendingApplicationViewModel.Opening = _opening;
            return View(_pendingApplicationViewModel);
    
        }

        // GET: Developers/ProfileIndex/5
        public async Task<IActionResult> ProfileIndex(int? id)
        {
            var developer = await _context.Developers.FirstOrDefaultAsync(m => m.Id == id);
            return View(developer);
        }

        public async Task<IActionResult> PendingIndex(int? id)
        {
            var opening = await _context.Openings.FirstOrDefaultAsync(m => m.Id == id);
            var pendingApplications = await _context.PendingApplications.Where(m => m.OpeningId == id).Include(l => l.Developer).ToListAsync();
            PendingApplicationsViewModel pendingApplicationsView = new PendingApplicationsViewModel();
            pendingApplicationsView.Opening = opening;
            pendingApplicationsView.PendingApplications = pendingApplications;
            return View(pendingApplicationsView);
        }

        public async Task<IActionResult> ActiveProjectIndex()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var developer = _context.Developers.FirstOrDefault(a => a.UserId == userId);
            var projectIds = _context.ProjectMembers.Where(m => m.DeveloperId == developer.Id).Select(m => m.ProjectId).ToList();
            var allProjects = _context.Projects.Where(m => projectIds.Contains(m.Id)).ToList();
            foreach (Project project in allProjects)
            {
                project.Openings = _context.Openings.Where(o => o.ProjectId == project.Id).ToList();
                var developerIds = _context.ProjectMembers.Where(p => p.ProjectId == project.Id)
                             .Select(p => p.DeveloperId)
                             .ToList();
                project.DeveloperMembers = _context.Developers
                             .Where(m => developerIds.Contains(m.Id))
                             .ToList();
            }
            var activeProjects = allProjects.Where(m => m.IsComplete == false).ToList();
            var completedProjects = allProjects.Where(m => m.IsComplete == true).ToList();
            ActiveProjectViewModel _activeProjectViewModel = new ActiveProjectViewModel();
            _activeProjectViewModel.CurrentUser = developer;
            _activeProjectViewModel.ActiveProjects = activeProjects;
            _activeProjectViewModel.CompletedProjects = completedProjects;
            return View(_activeProjectViewModel);
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
                _project.StartDate = DateTime.Now;
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

        // POST: /Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePendingApplication(PendingApplicationViewModel pendingApplicationViewModel)
        {
           
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var developer = _context.Developers.FirstOrDefault(a => a.UserId == userId);
            var roleOpeningId = pendingApplicationViewModel.Opening.Id;
            PendingApplication pendingApplication = new PendingApplication();
            pendingApplication.OpeningId = roleOpeningId;
            pendingApplication.DeveloperId = developer.Id;
            pendingApplication.Email = pendingApplicationViewModel.PendingApplication.Email;
            _context.PendingApplications.Add(pendingApplication);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

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

        //Accept Pending Application
        public async Task<IActionResult> AcceptPendingApplication(int Id)
        {
            var pendingApplication = await _context.PendingApplications.FirstOrDefaultAsync(m => m.Id == Id);
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Opening opening = await _context.Openings.FirstOrDefaultAsync(m => m.Id == pendingApplication.OpeningId);
            var developer = await _context.Developers.FirstOrDefaultAsync(a => a.Id == pendingApplication.DeveloperId);
            var project = await _context.Projects.FirstOrDefaultAsync(m => m.Id == opening.ProjectId);
            var projectName = _context.Projects.Where(m => m.Id == opening.ProjectId).Select(m => m.Name);

            var currentUser = _context.Users.FirstOrDefault(m => m.Id == userId);
            ProjectMember projectMember = new ProjectMember();
            projectMember.DeveloperId = pendingApplication.DeveloperId;
            projectMember.JoinDate = DateTime.Now;
            projectMember.Email = pendingApplication.Email;
            projectMember.RoleId = developer.RoleId;
            projectMember.ProjectId = opening.ProjectId;
            opening.IsFilled = true;
            await _context.ProjectMembers.AddAsync(projectMember);


            //SendGrid API
            var apiKey = API_KEYS.SendGridAPI;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(currentUser.Email);
            var to = new EmailAddress(pendingApplication.Email, developer.UserName);
            var subject = "Your application has been accepted for project: " + projectName;
            var plainTextContent = "Here is your link to joing the githubt repository! Link: " + project.GithubUrl;
            var htmlContent = "<strong>Get your CodeSquad on!!!</strong>";
            var msg = MailHelper.CreateSingleEmail(
                from,
                to,
                subject,
                plainTextContent,
                htmlContent
             );

            var response = await client.SendEmailAsync(msg);

            _context.PendingApplications.Remove(pendingApplication);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ProjectIndex));
        }

        //Delete Pending Application
        public async Task<IActionResult> DenyPendingApplication (int Id)
        {
            var pendingApplication = await _context.PendingApplications.FirstOrDefaultAsync(m => m.Id == Id);
            _context.PendingApplications.Remove(pendingApplication);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ProjectIndex));
        }

        // GET: Developers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var _project = _context.Projects.Where(m => m.Id == id).FirstOrDefault();

            return View(_project);
        }

        // POST: Developers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var _Project = await _context.Projects.FindAsync(id);
            var _Openings = await _context.Openings.Where(m => m.ProjectId == id).ToListAsync();
            var _OpeningIds = _Openings.Select(m => m.Id).ToList();
            var _PendingApplications = await _context.PendingApplications.Where(m => _OpeningIds.Contains(m.Id)).ToListAsync();
            var _ProjectMembers = await _context.ProjectMembers.Where(m => m.ProjectId == id).ToListAsync();
            _context.PendingApplications.RemoveRange(_PendingApplications);
            _context.ProjectMembers.RemoveRange(_ProjectMembers);
            _context.Openings.RemoveRange(_Openings);
            _context.Projects.Remove(_Project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ProjectIndex));
        }

        private bool DeveloperExists(int id)
        {
            return _context.Developers.Any(e => e.Id == id);
        }
    }
}
