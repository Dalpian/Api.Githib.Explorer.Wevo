using System;
using System.Threading.Tasks;

namespace Wevo.Github.Explore.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> CommitAsync();
    }
}
