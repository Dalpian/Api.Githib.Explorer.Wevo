using System.Linq;
using Microsoft.EntityFrameworkCore;
using Wevo.Github.Explorer.Infra.Data.Contexts;

namespace Wevo.Github.Explorer.Infra.Data.UoW
{
    public static class EntityContextExtension
    {
        public static void DetachLocal<T>(this GithubExplorerContext context, T t, int entryId) where T : class, IIdentifier
        {
            var local = context.Set<T>()
                .Local
                .FirstOrDefault(entry => entry.Id.Equals(entryId));


            if (local != null)
            {
                context.Entry(local).State = EntityState.Detached;
            }
            context.Entry(t).State = EntityState.Modified;
        }

    }
}