using System;

namespace Wevo.Github.Explorer.Api.Models
{
    public class AddUserRequest
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string UserGithub { get; set; }

    }
}
