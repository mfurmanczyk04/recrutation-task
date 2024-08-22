using GitTracker.Core.Entities;
using GitTracker.Core.Interfaces;
using GitTracker.Core.Services;
using GitTracker.Web.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GitTracker.Web.Controllers
{
    [ApiController]
    [Route("github")]

    public class GitHubController : ControllerBase
    {
        private readonly GitHubService _gitHubService;

        public GitHubController(GitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateIssue(Issue newIssue)
        {
            try
            {
                var response = await _gitHubService.CreateIssue(newIssue);
                return Ok(response);
            }
            catch (Exception ex) 
            {
                return (ex is ArgumentNullException ? NotFound(ex.Message) : BadRequest(ex.Message));
            }

        }

        
    }
}
