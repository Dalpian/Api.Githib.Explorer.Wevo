using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wevo.Github.Explore.Domain.Entities;
using Wevo.Github.Explore.Domain.Interfaces.ApiServices;

namespace Wevo.Github.Explore.Domain.Interfaces.Services
{
    public class UserGithubService : IUserService
    {
        private readonly IGithubService _githubService;
        private readonly IConfiguration _configuration;

        public UserGithubService(IGithubService githubService, IConfiguration configuration)
        {
            _githubService = githubService;
            _configuration = configuration;
        }

        public async Task<UsersGithub> GetUsersGithub(int since)
        {
            try
            {
                var users = new UsersGithub
                {
                    UserList = new List<UserGithub>()
                };

                var usersList = await _githubService.GetUsersGithub(since);

                users.UserList.AddRange(usersList);

                var sincePagination = usersList.Last().Id.ToString();
                var urlApp = _configuration["API:Endpoint"];
                users.NextPage = $"{urlApp}users?since={sincePagination}";

                return users;
            }

            catch (Exception e)
            {
                var error = e;
                return default;
            }

        }

        public async Task<UserDetail> GetDetail(string userName)
        {
            return await _githubService.GetDetail(userName);
        }

        public async Task<List<UserRepository>> GetRepository(string userName)
        {
            return await _githubService.GetRepository(userName);
        }
    }
}

