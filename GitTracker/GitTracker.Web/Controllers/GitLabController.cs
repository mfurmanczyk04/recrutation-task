using GitTracker.Core.Entities;
using GitTracker.Core.Interfaces;
using GitTracker.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace GitTracker.Web.Controllers
{
    [ApiController]
    [Route("gitlab")]
    public class GitLabController : ControllerBase
    {
        private readonly GitLabService _gitlabService;

        public GitLabController(GitLabService gitLabService)
        {
            _gitlabService = gitLabService;
        }


        [HttpPost]
        public async Task<ActionResult<string>> AddIssue(Issue newIssue)
        {
            try
            {
                var response = await _gitlabService.CreateIssue(newIssue);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return ex is ArgumentNullException ? BadRequest(ex.Message) : NotFound(ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult<string>> UpdateIssue(Issue updatedIssue)
        {
            try
            {
                var response = await _gitlabService.UpdateIssue(updatedIssue);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return ex is ArgumentNullException ? BadRequest(ex.Message) : NotFound(ex.Message);
            }
        }
        [HttpPut("close")]
        public async Task<ActionResult<string>> CloseIssue(Issue closeIssue)
        {
            try
            {
                var response = await _gitlabService.CloseIssue(closeIssue);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return ex is ArgumentNullException ? BadRequest(ex.Message) : NotFound(ex.Message);
            }
        }
    }
}
