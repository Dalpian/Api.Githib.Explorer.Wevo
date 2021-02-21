using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wevo.Github.Explore.Domain.Entities;
using Wevo.Github.Explore.Domain.Interfaces.Repositories;
using Wevo.Github.Explorer.Infra.Data.Contexts;

namespace Wevo.Github.Explorer.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GithubExplorerContext _context;

        public UserRepository(GithubExplorerContext context)
        {
            _context = context;
        }

        public async Task<User> GetByid(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.Where(u => u.Ativo == true).ToListAsync();
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task PutAsync(User user)
        {
            await Task.Run(() => _context.Entry(user).State = EntityState.Modified);
        }

        public async Task Remove(User user)
        {
            await Task.Run(() => _context.Entry(user).State = EntityState.Modified);
        }
    }
}