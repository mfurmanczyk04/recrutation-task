namespace GitTracker.Web.DTOs
{
    public class UpdateIssueGitlabDto
    {
        public required string PersonalAccesToken { get; set; }
        public string? GitlabProjectId { get; set; }
        public string? IssueId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
