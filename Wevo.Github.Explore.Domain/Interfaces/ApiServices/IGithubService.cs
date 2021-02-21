using System.Collections.Generic;
using System.Threading.Tasks;
using Wevo.Github.Explore.Domain.Entities;

namespace Wevo.Github.Explore.Domain.Interfaces.ApiServices
{
    public interface IGithubService
    {
        Task<List<UserGithub>> GetUsersGithub(int since);
        Task<UserDetail> GetDetail(string userName);
        Task<List<UserRepository>> GetRepository(string userName);
    }
}
