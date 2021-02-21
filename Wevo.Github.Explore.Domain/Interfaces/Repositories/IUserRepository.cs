using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wevo.Github.Explore.Domain.Entities;

namespace Wevo.Github.Explore.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByid(Guid id);

        Task<IEnumerable<User>> GetAll();

        Task AddAsync(User user);

        Task PutAsync(User user);

        Task Remove(User user);
    }
}