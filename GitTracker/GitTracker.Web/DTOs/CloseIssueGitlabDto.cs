namespace GitTracker.Web.DTOs
{
    public class CloseIssueGitlabDto
    {
        public string? IssueId { get; set; }
        public required string PersonalAccesToken { get; set; }
        public string? GitlabProjectId { get; set; }
    }
}
