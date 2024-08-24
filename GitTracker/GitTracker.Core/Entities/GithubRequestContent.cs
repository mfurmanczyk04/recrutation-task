using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitTracker.Core.Entities
{
    public class GithubRequestContent
    {
        public string? title { get; set; }
        public string? body { get; set; }
        public string? state { get; set; }
    }
}
