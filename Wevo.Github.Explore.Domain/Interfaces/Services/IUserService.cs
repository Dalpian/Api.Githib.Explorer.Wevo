using System.Collections.Generic;
using System.Threading.Tasks;
using Wevo.Github.Explore.Domain.Entities;

namespace Wevo.Github.Explore.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<UsersGithub> GetUsersGithub(int since);
        Task<UserDetail> GetDetail(string userName);
        Task<List<UserRepository>> GetRepository(string userName);
    }
}
