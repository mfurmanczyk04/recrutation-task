using GitTracker.Core.Entities;
using GitTracker.Core.Enums;
using GitTracker.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace GitTracker.Core.Services
{
    public class GitHubService : IGitService
    {
        private readonly HttpClient _httpClient;
        private readonly string _installationUrl = "https://api.github.com/repos";

        public GitHubService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<string?> CreateIssue(Issue newIssue)
        {
            if (newIssue.Description == null || newIssue.Title == null)
            {
                throw new ArgumentNullException(nameof(newIssue));
            }

            var requestContent = new
            {
                title = newIssue.Title,
                body = newIssue.Description
            };

            var content = new StringContent(JsonSerializer.Serialize(requestContent), Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, $"{_installationUrl}/{newIssue.RepositoryOwner}/{newIssue.RepositoryName}/issues");
            request.Headers.Add("Authorization", $"token {newIssue.PersonalAccesToken}");
            request.Headers.Add("User-Agent", "MyApp");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github+json"));
            request.Content = content;
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();
            var issue = JsonSerializer.Deserialize<JsonElement>(responseData);
            return issue.GetProperty("html_url").GetString();

        }
        public Task<bool> CloseIssue(string repository, string issueId)
        {
            throw new NotImplementedException();
        }


        public async Task<string> UpdateIssue(Issue updatedIssue)
        {
            if (updatedIssue.Description == null || updatedIssue.Title == null || updatedIssue.IssueId == null)
            {
                throw new ArgumentNullException(nameof(updatedIssue));
            }

            var requestContent = new
            {
                title = updatedIssue.Title,
                body = updatedIssue.Description,
            };

            var content = new StringContent(JsonSerializer.Serialize(requestContent), Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Patch, $"{_installationUrl}/{updatedIssue.RepositoryOwner}/{updatedIssue.RepositoryName}/issues/{updatedIssue.IssueId}");
            request.Headers.Add("Authorization", $"token {updatedIssue.PersonalAccesToken}");
            request.Headers.Add("User-Agent", "MyApp");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github+json"));
            request.Content = content;
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();
            var issue = JsonSerializer.Deserialize<JsonElement>(responseData);
            return issue.GetProperty("html_url").GetString();
        }
        public async Task<string> CloseIssue(Issue closeIssue)
        {
            var requestContent = new
            {
                state = GithubIssueState.closed.ToString(),
            };

            var content = new StringContent(JsonSerializer.Serialize(requestContent), Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Patch, $"{_installationUrl}/{closeIssue.RepositoryOwner}/{closeIssue.RepositoryName}/issues/{closeIssue.IssueId}");
            request.Headers.Add("Authorization", $"token {closeIssue.PersonalAccesToken}");
            request.Headers.Add("User-Agent", "MyApp");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github+json"));
            request.Content = content;
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();
            var issue = JsonSerializer.Deserialize<JsonElement>(responseData);
            return issue.GetProperty("html_url").GetString();
        }
    }
}

