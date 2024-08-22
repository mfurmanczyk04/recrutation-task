using GitTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitTracker.Core.Interfaces
{
    public interface IGitService
    {
        Task<string?> CreateIssue(Issue issue);
        Task<string> UpdateIssue(Issue updatedIssue);
        Task<bool> CloseIssue(string repository, string issueId);
    }
}
