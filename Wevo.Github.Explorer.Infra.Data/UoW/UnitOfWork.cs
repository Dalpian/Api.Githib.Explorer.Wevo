using System.Threading.Tasks;
using Wevo.Github.Explore.Domain.Interfaces;
using Wevo.Github.Explorer.Infra.Data.Contexts;

namespace Wevo.Github.Explorer.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GithubExplorerContext _context;

        public UnitOfWork(GithubExplorerContext githubExplorerContext)
        {
            _context = githubExplorerContext;
        }
        public async Task<bool> CommitAsync()
        {
            await _context.SaveChangesAsync();

            return true;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
