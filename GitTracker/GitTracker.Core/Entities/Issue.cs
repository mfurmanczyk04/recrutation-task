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
        public required string RepositoryName { get; set; }
        public required string RepositoryOwner { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
    }
}
