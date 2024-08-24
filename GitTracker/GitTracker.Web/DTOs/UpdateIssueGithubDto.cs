namespace GitTracker.Web.DTOs
{
    public class UpdateIssueGithubDto
    {
        public required string PersonalAccesToken { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? RepositoryName { get; set; }
        public string? RepositoryOwner { get; set; }
        public string? IssueId { get; set; }
    }
}
