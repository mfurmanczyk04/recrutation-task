﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitTracker.Core.Interfaces
{
    public interface IGitService
    {
        Task<string> CreateIssue(string repository, string title, string description);
        Task<bool> UpdateIssue(string repository, string issueId,string? title, string? description);
        Task<bool> CloseIssue(string repository, string issueId);
    }
}
