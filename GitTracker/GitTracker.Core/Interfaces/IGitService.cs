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
        Task<string?> CreateIssue(Issue newIssue);
        Task<string> UpdateIssue(Issue updatedIssue);
        Task<string> CloseIssue(Issue closeIssue);
    }
}
