using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Vivan.Mediator.Commands;
using Vivan.Notifications.Interfaces;
using Wevo.Github.Explore.Domain.Entities;
using Wevo.Github.Explore.Domain.Interfaces;
using Wevo.Github.Explore.Domain.Interfaces.Repositories;

namespace Wevo.Github.Explore.Domain.Commands.UserCmd
{
    public class PutUserCommandHandler : CommandHandler, IRequestHandler<PutUserCommand, IEnumerable<User>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserRepository _userRepository;
        private readonly INotificationContext _notificationContext;
        public PutUserCommandHandler(IMediator mediator, INotificationContext notificationContext,
            IUnitOfWork uow, IUserRepository userRepository) : base(mediator,
            notificationContext)
        {
            _userRepository = userRepository;
            _notificationContext = notificationContext;
            _uow = uow;
        }

        public async Task<IEnumerable<User>> Handle(PutUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByid(request.Id);

            user.Nome = request.Nome;
            user.CPF = request.CPF;
            user.Email = request.Email;
            user.Telefone = request.Telefone;
            user.Sexo = request.Sexo;
            user.DataNascimento = request.DataNascimento;
            user.DataAlteracao = DateTime.Now;
            user.UserGithub = request.UserGithub;

            await _userRepository.PutAsync(user);

            try
            {
                await _uow.CommitAsync();
            }
            catch (Exception e)
            {
                _notificationContext.AddNotification("error", e.Message);
            }

            var listUser = await _userRepository.GetAll();

            return listUser;
        }
    }
}