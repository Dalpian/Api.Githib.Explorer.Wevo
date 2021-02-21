using System;
using System.Collections.Generic;
using System.Text;
using Wevo.Github.Explore.Domain.Entities;
using Wevo.Github.Explore.Github.Model;

namespace Wevo.Github.Explore.Github.Mapper
{
    public static class UserGithubMap
    {
        public static Domain.Entities.UserGithub Map(Model.UserGithubExternal userGithub) => userGithub == null ? default(Domain.Entities.UserGithub) : new Domain.Entities.UserGithub()
        {
            Login = userGithub.Login,
            Id = userGithub.Id,
        };
    }
}
