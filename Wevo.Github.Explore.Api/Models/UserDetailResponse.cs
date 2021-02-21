using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wevo.Github.Explore.Api.Models
{
    public class UserDetailResponse
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Html_url { get; set; }
        public DateTime Created_at { get; set; }
    }
}

