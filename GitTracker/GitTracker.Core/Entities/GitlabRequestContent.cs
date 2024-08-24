using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitTracker.Core.Entities
{
    public class GitlabRequestContent
    {
        public string? description { get; set; }
        public string? title { get; set; }
        public string? state_event { get; set; }
    }
}
