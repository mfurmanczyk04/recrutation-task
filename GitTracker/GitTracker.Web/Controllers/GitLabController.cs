using GitTracker.Core.Entities;
using GitTracker.Core.Interfaces;
using GitTracker.Core.Services;
using GitTracker.Web.DTOs;
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
        public async Task<ActionResult<string>> AddIssue(AddIssueGitlabDto newIssueDto)
        {
            var newIssue = new Issue()
            {
                PersonalAccesToken = newIssueDto.PersonalAccesToken,
                GitlabProjectId = newIssueDto.GitlabProjectId,
                Title = newIssueDto.Title,
                Description = newIssueDto.Description
            };

            try
            {
                var response = await _gitlabService.CreateIssue(newIssue);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult<string>> UpdateIssue(UpdateIssueGitlabDto updatedIssueDto)
        {
            var updatedIssue = new Issue()
            {
                PersonalAccesToken = updatedIssueDto.PersonalAccesToken,
                GitlabProjectId = updatedIssueDto.GitlabProjectId,
                Title = updatedIssueDto.Title,
                Description = updatedIssueDto.Description,
                IssueId = updatedIssueDto.IssueId
            };
            try
            {
                var response = await _gitlabService.UpdateIssue(updatedIssue);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("close")]
        public async Task<ActionResult<string>> CloseIssue(CloseIssueGitlabDto closeIssueDto)
        {
            var closeIssue = new Issue()
            {
                PersonalAccesToken = closeIssueDto.PersonalAccesToken,
                GitlabProjectId = closeIssueDto.GitlabProjectId,
                IssueId = closeIssueDto.IssueId
            };
            try
            {
                var response = await _gitlabService.CloseIssue(closeIssue);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
