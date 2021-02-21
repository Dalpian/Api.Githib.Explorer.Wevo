using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Configuration;
using Vivan.Mediator.Commands;
using Vivan.Notifications.Interfaces;
using Wevo.Github.Explore.Domain.Entities;
using Wevo.Github.Explore.Domain.Interfaces;
using Wevo.Github.Explore.Domain.Interfaces.Repositories;

namespace Wevo.Github.Explore.Domain.Commands.UserCmd
{
    public class AddUserCommandHandler : CommandHandler, IRequestHandler<AddUserCommand, IEnumerable<User>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _uow;
        private readonly INotificationContext _notificationContext;

        public AddUserCommandHandler(IMediator mediator, IConfiguration configuration, INotificationContext notificationContext, IUserRepository userRepository, IUnitOfWork uow) : base(mediator, notificationContext)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _notificationContext = notificationContext;
            _uow = uow;
        }

        public async Task<IEnumerable<User>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Nome = request.Nome,
                CPF = request.CPF,
                Email = request.Email,
                Telefone = request.Telefone,
                Sexo = request.Sexo,
                DataNascimento = request.DataNascimento,
                UserGithub = request.UserGithub
            };

            await _userRepository.AddAsync(user);

            try
            {
                await _uow.CommitAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _notificationContext.AddNotification("error", e.Message);
            }

            var listUser = await _userRepository.GetAll();

            return listUser;
        }
    }
}