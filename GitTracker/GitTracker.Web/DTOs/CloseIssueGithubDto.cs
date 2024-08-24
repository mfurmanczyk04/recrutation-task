namespace GitTracker.Web.DTOs
{
    public class CloseIssueGithubDto
    {
        public string? IssueId { get; set; }
        public required string PersonalAccesToken { get; set; }
        public string? RepositoryName { get; set; }
        public string? RepositoryOwner { get; set; }
    }
}
