using System;
using System.Collections.Generic;
using System.Text;

namespace Wevo.Github.Explore.Domain.Entities
{
    public class UsersGithub
    {
        public List<UserGithub> UserList { get; set; }
        public string NextPage { get; set; }
    }
}
