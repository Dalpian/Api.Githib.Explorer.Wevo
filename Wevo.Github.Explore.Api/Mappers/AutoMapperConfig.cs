using AutoMapper;
using Wevo.Github.Explore.Api.Models;
using Wevo.Github.Explore.Domain.Entities;

namespace Wevo.Github.Explore.Api.Mappers
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<UserGithub, UserGithubResponse>();
            CreateMap<UserDetail, UserDetailResponse>();
            CreateMap<UserRepository, UserRepositoryResponse>();
        }
    }

}