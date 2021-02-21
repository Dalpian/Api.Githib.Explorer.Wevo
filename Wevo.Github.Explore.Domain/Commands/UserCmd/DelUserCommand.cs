using System;
using System.Collections.Generic;
using MediatR;
using Vivan.Mediator.Commands;
using Wevo.Github.Explore.Domain.Commands.UserCmd.Validators;
using Wevo.Github.Explore.Domain.Entities;

namespace Wevo.Github.Explore.Domain.Commands.UserCmd
{
    public class DelUserCommand : Command<DelUserCommandValidator>, IRequest<IEnumerable<User>>
    {
        public Guid Id { get; set; }

        public DelUserCommand(string id)
        {
            Id = Guid.Parse(id);
        }
    }
}