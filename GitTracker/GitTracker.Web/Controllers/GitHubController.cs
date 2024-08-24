using GitTracker.Core.Entities;
using GitTracker.Core.Interfaces;
using GitTracker.Core.Services;
using GitTracker.Web.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;

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
        public async Task<ActionResult<string>> CreateIssue(AddIssueGithubDto newIssueDto)
        {
            try
            {
                var newIssue = new Issue
                {
                    PersonalAccesToken = newIssueDto.PersonalAccesToken,
                    Title = newIssueDto.Title,
                    Description = newIssueDto.Description,
                    RepositoryName = newIssueDto.RepositoryName,
                    RepositoryOwner = newIssueDto.RepositoryOwner
                };
                var response = await _gitHubService.CreateIssue(newIssue);
                return Ok(response);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPatch("update")]
        public async Task<ActionResult<string>> UpdateIssue(UpdateIssueGithubDto updatedIssueDto)
        {
            var updatedIssue = new Issue()
                {
                    PersonalAccesToken = updatedIssueDto.PersonalAccesToken,
                    Title = updatedIssueDto.Title,
                    Description = updatedIssueDto.Description,
                    RepositoryName = updatedIssueDto.RepositoryName,
                    RepositoryOwner = updatedIssueDto.RepositoryOwner,
                    IssueId = updatedIssueDto.IssueId
                };
        
            try
            {
                var response = await _gitHubService.UpdateIssue(updatedIssue);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("close")]
        public async Task<ActionResult<string>> CloseIssue(CloseIssueGithubDto closeIssueDto)
        {
            var closeIssue = new Issue()
            {
                PersonalAccesToken = closeIssueDto.PersonalAccesToken,
                RepositoryName = closeIssueDto.RepositoryName,
                RepositoryOwner = closeIssueDto.RepositoryOwner,
                IssueId = closeIssueDto.IssueId
            };
            try
            {
                var response = await _gitHubService.CloseIssue(closeIssue);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
