using Microsoft.AspNetCore.Identity;
using System.Linq;
using Wevo.Github.Explore.Domain.Entities;
using Wevo.Github.Explorer.Infra.Data.Contexts;

namespace Wevo.Github.Explorer.Infra.Data.Services
{
    public class SeedingService
    {
        private GithubExplorerContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public SeedingService(GithubExplorerContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (!_context.Users.Any())
            {
                #region usuario padrao
                var user = new User()
                {
                    Nome = "Gabriel Fülber Dalpian",
                    CPF = "000.000.00-70",
                    Email = "gabrieldalpian@gmail.com",
                    Telefone = "51 99122-9558",
                    Sexo = "Maculino",
                    DataNascimento = new System.DateTime(1991,11,22),
                    UserGithub = "Dalpian"
                };

                _context.Users.Add(user);

                _context.SaveChanges();
                #endregion usuario padrao

            }

        }
    }
}
