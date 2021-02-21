using MediatR;
using System;
using System.Collections.Generic;
using Vivan.Mediator.Commands;
using Wevo.Github.Explore.Domain.Commands.UserCmd.Validators;
using Wevo.Github.Explore.Domain.Entities;

namespace Wevo.Github.Explore.Domain.Commands.UserCmd
{
    public class AddUserCommand : Command<AddUserCommandValidator>, IRequest<IEnumerable<User>>
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string UserGithub { get; set; }

        public AddUserCommand(
         string nome,
         string cpf,
         string email,
         string telefone,
         string sexo,
         DateTime dataNascimento,
         string userGithub
         )
        {
            Nome = nome;
            CPF = cpf;
            Email = email;
            Telefone = telefone;
            Sexo = sexo;
            DataNascimento = dataNascimento;
            UserGithub = userGithub;
        }
    }
}