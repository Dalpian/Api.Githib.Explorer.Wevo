using System;

namespace Wevo.Github.Explore.Domain.Entities
{
    public class User : Entity
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string UserGithub { get; set; }

    }
}
