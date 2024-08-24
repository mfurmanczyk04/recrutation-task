using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitTracker.Core.Entities
{
    public class Issue
    {
        public string? IssueId { get; set; }
        public required string PersonalAccesToken { get; set; }
        public string? RepositoryName { get; set; }
        public string? RepositoryOwner { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Enum? State { get; set; }
        public string? GitlabProjectId { get; set; }
    }
}
