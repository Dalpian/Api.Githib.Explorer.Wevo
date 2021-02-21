using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Wevo.Github.Explore.Domain.Entities;
using Wevo.Github.Explore.Domain.Interfaces.ApiServices;
using Wevo.Github.Explore.Github.Mapper;
using Wevo.Github.Explore.Github.Model;
using Wevo.Github.Explorer.Github.Model;

namespace Wevo.Github.Explore.Github.Service
{
    public class GithubService : IGithubService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public GithubService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<List<Domain.Entities.UserGithub>> GetUsersGithub(int since)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                _httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd("api.sp.github.explore");
                _httpClient.BaseAddress = new Uri(_configuration["Github:Endpoint"]);

                var response = await _httpClient.GetAsync($"users?since={since}");
                if (!response.IsSuccessStatusCode)
                {
                    var error = response.Content.ReadAsStringAsync();
                    throw new Exception(error.Result);
                }
                var usersResponse = JsonConvert.DeserializeObject<List<Model.UserGithubExternal>>(await response.Content.ReadAsStringAsync());
                return usersResponse.Select(UserGithubMap.Map).ToList();
            }
            catch (Exception e)
            {
                var erro = e;
                return default;
            }
        }

        public async Task<UserDetail> GetDetail(string userName)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                _httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd("api.sp.github.explore");
                _httpClient.BaseAddress = new Uri(_configuration["Github:Endpoint"]);

                var response = await _httpClient.GetAsync($"users/{userName}");
                if (!response.IsSuccessStatusCode)
                {
                    var error = response.Content.ReadAsStringAsync();
                    throw new Exception(error.Result);
                }
                var userDetailResponse = JsonConvert.DeserializeObject<UserDetailGithub>(await response.Content.ReadAsStringAsync());
                return UserDetailMap.Map(userDetailResponse);
            }
            catch (Exception e)
            {
                var erro = e;
                return default;
            }
        }

        public async Task<List<UserRepository>> GetRepository(string userName)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                _httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd("api.sp.github.explore");
                _httpClient.BaseAddress = new Uri(_configuration["Github:Endpoint"]);

                var response = await _httpClient.GetAsync($"users/{userName}/repos");
                if (!response.IsSuccessStatusCode)
                {
                    var error = response.Content.ReadAsStringAsync();
                    throw new Exception(error.Result);
                }
                var usersResponse = JsonConvert.DeserializeObject<List<UserRepositoryGithub>>(await response.Content.ReadAsStringAsync());
                return usersResponse.Select(UserRepositoryMap.Map).ToList();
            }
            catch (Exception e)
            {
                var erro = e;
                return default;
            }
        }

    }
}
