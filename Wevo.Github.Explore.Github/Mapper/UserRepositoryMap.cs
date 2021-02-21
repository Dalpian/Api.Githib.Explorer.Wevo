using System;
using System.Collections.Generic;
using System.Text;
using Wevo.Github.Explore.Domain.Entities;
using Wevo.Github.Explore.Github.Model;

namespace Wevo.Github.Explore.Github.Mapper
{
    public static class UserRepositoryMap
    {
        public static UserRepository Map(UserRepositoryGithub userRepositoryGithub) => userRepositoryGithub == null ? default(UserRepository) : new UserRepository()
        {
            Id = userRepositoryGithub.Id,
            Name = userRepositoryGithub.Name,
            Html_url = userRepositoryGithub.Html_url
        };
    }
}
