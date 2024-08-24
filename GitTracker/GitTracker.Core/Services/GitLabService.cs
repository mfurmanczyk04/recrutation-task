using GitTracker.Core.Entities;
using GitTracker.Core.Enums;
using GitTracker.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GitTracker.Core.Services
{
    public class GitLabService
    {
        private readonly HttpClient _httpClient;
        private readonly string _installationUrl = "https://gitlab.com/api/v4";

        public GitLabService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string?> CreateIssue(Issue newIssue)
        {
            if (newIssue.Title == null || newIssue.GitlabProjectId == null)
            {
                throw new ArgumentNullException(nameof(newIssue));
            }

            var requestContent = new
            {
                title = newIssue.Title,
                description = newIssue.Description
            };

            var content = new StringContent(JsonSerializer.Serialize(requestContent), Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, $"{_installationUrl}/projects/{newIssue.GitlabProjectId}/issues");
            request.Headers.Add("Authorization", $"Bearer {newIssue.PersonalAccesToken}");
            request.Content = content;

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();
            var issue = JsonSerializer.Deserialize<JsonElement>(responseData);

            return issue.GetProperty("web_url").GetString();
        }
        public async Task<string> CloseIssue(Issue closeIssue)
        {
            if (closeIssue.GitlabProjectId == null)
            {
                throw new ArgumentNullException(nameof(closeIssue));
            }

            var requestContent = new
            {
                state_event = "close",
            };

            var content = new StringContent(JsonSerializer.Serialize(requestContent), Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Put, $"{_installationUrl}/projects/{closeIssue.GitlabProjectId}/issues/{closeIssue.IssueId}");
            request.Headers.Add("Authorization", $"Bearer {closeIssue.PersonalAccesToken}");
            request.Content = content;

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();
            var issue = JsonSerializer.Deserialize<JsonElement>(responseData);

            return issue.GetProperty("web_url").GetString();
        }


        public async Task<string> UpdateIssue(Issue updatedIssue)
        {
            if (updatedIssue.GitlabProjectId == null || updatedIssue.Title == null || updatedIssue.Description == null)
            {
                throw new ArgumentNullException(nameof(updatedIssue));
            }

            var requestContent = new
            {
                description = updatedIssue.Description,
                title = updatedIssue.Title,
            };

            var content = new StringContent(JsonSerializer.Serialize(requestContent), Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Put, $"{_installationUrl}/projects/{updatedIssue.GitlabProjectId}/issues/{updatedIssue.IssueId}");
            request.Headers.Add("Authorization", $"Bearer {updatedIssue.PersonalAccesToken}");
            request.Content = content;

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();
            var issue = JsonSerializer.Deserialize<JsonElement>(responseData);

            return issue.GetProperty("web_url").GetString();
        }
    }
}
