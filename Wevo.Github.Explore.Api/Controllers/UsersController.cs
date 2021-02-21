using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Wevo.Github.Explore.Api.Models;
using Wevo.Github.Explore.Domain.Commands.UserCmd;
using Wevo.Github.Explore.Domain.Entities;
using Wevo.Github.Explore.Domain.Interfaces.Repositories;
using Wevo.Github.Explore.Domain.Interfaces.Services;
using Wevo.Github.Explorer.Api.Models;

namespace Wevo.Github.Explore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;


        public UsersController(IMapper mapper, IUserService userService, IUserRepository userRepository, IMediator mediator)
        {
            _mapper = mapper;
            _userService = userService;
            _userRepository = userRepository;
            _mediator = mediator;
        }

        [HttpPost()]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<User>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<User>>> Add(AddUserRequest addUserRequest)
        {
            var command = new AddUserCommand(
                addUserRequest.Nome,
                addUserRequest.CPF,
                addUserRequest.Email,
                addUserRequest.Telefone,
                addUserRequest.Sexo,
                addUserRequest.DataNascimento,
                addUserRequest.UserGithub);

            var addUserResponse = await _mediator.Send(command);
            return Ok(addUserResponse);
        }

        [HttpPut]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<User>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<User>>> Put(PutUserRequest putUserRequest)

        {
            var putUserResponse = await _mediator.Send(new PutUserCommand(putUserRequest.Id,
                                                       putUserRequest.Nome,
                                                       putUserRequest.CPF,
                                                       putUserRequest.Email,
                                                       putUserRequest.Telefone,
                                                       putUserRequest.Sexo,
                                                       putUserRequest.DataNascimento,
                                                       putUserRequest.UserGithub));


            if (putUserResponse == null) return NotFound();
            return Ok(putUserResponse);
        }

        [HttpGet("GetAllUsers")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<User>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var response = await _userRepository.GetAll();
            if (response == null) return BadRequest();
            return Ok(response);
        }

        [HttpGet("GetUserById/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<User>> GetUserById(Guid id)
        {
            var response = await _userRepository.GetByid(id);
            if (response == null) return BadRequest();
            return Ok(response);
        }

        [HttpDelete("DeleteUserById/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<User>> DeleteUserById(string id)
        {
            var putUserResponse = await _mediator.Send(new DelUserCommand(id));

            if (putUserResponse == null) return NotFound();
            return Ok(putUserResponse);
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(UsersGithub), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UserGithubResponse>> GetAll([FromQuery] int since = 0)
        {
            var response = await _userService.GetUsersGithub(since);
            if (response == null) return BadRequest();
            return Ok(response);
        }

        [HttpGet("{username}/details")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(List<UserGithubResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UserGithubResponse>> Details(string username)
        {
            var response = await _userService.GetDetail(username);
            if (response == null) return BadRequest();
            var itemResponse = _mapper.Map<UserDetailResponse>(response);
            return Ok(itemResponse);
        }

        [HttpGet("{username}/repos")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(List<UserGithubResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UserGithubResponse>> Repositories(string username)
        {
            var response = await _userService.GetRepository(username);
            if (response == null) return BadRequest();
            var itemResponse = _mapper.Map<IEnumerable<UserRepositoryResponse>>(response);
            return Ok(itemResponse);
        }
    }
}
