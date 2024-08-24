namespace GitTracker.Web.DTOs
{
    public class AddIssueGitlabDto
    {
        public string? GitlabProjectId { get; set; }
        public required string PersonalAccesToken { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
