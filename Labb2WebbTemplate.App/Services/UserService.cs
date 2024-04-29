using System.Net;
using System.Net.Http.Headers;
using System.Security.Claims;
using Labb2WebbTemplate.Api.Endpoints.User;
using Labb2WebbTemplate.Shared.Dtos.AddressDtos;
using Labb2WebbTemplate.Shared.Dtos.ErrorsDto;
using Labb2WebbTemplate.Shared.Dtos.UserDtos;
using Labb2WebbTemplate.Shared.Enums;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace Labb2WebbTemplate.App.Services;

public class UserService
{
    private readonly HttpClient _client;
    private readonly ProtectedLocalStorage _localStorage;
    
    public UserService(IHttpClientFactory clientFactory, ProtectedLocalStorage localStorage)
    {
        _client = clientFactory.CreateClient("main");
        _localStorage = localStorage;
        
        var task = SetAuthorization();

    }

    public async Task SetAuthorization()
    {
        var token = await _localStorage.GetAsync<string>("token");
        
        _client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token.Value);
    }
    
    public async Task<UserResponse?> GetByIdAsync(int id)
    {
        var response = await _client.GetFromJsonAsync<UserResponse>($"/user/id/{id}");

        return response;
    }

    public async Task<string> AuthenticateUser(AuthenticateUserRequest user)
    {
        var response = await _client.PostAsJsonAsync("user/login", user);

        if (response.IsSuccessStatusCode)
        {
            var token = await response.Content.ReadFromJsonAsync<string>();

            if (token is not null)
            {
                return token;
            }
        }

        return "NaN";
    }

    public async Task<bool> UserIsAuthorized()
    {
        await SetAuthorization();
        var response = await _client.GetAsync("user/authorize");

        if (response.IsSuccessStatusCode)
        {
            return true;
        }

        return false;
    }

    public async Task<UserResponse?> GetAuthorizedUser()
    {
        var response = await _client.GetFromJsonAsync<int>("user/authorize");

        var user = await GetByIdAsync(response);

        return user;

    }

    public async Task<IEnumerable<UserResponse>> GetAllAsync()
    {
        var response = await _client.GetFromJsonAsync<IEnumerable<UserResponse>>($"/user");
        return response ?? [];
    }

    public async Task<RepositoryStatus> AddAsync(UserRequest newUser)
    {
        var response = await _client.PostAsJsonAsync("/user", newUser);

        if (response.IsSuccessStatusCode)
        {
            return RepositoryStatus.Ok;
        }

        var test = await response.Content.ReadFromJsonAsync<ErrorDto>();
        if (test != null 
            && test.Errors.GeneralErrors[0] == "The provided email is already registered")
        {
            return RepositoryStatus.EmailNotUnique;
        }
        return RepositoryStatus.BadRequest;
    }

    public async Task<bool> EmailIsRegistered(string email)
    {
        var response = await _client.GetFromJsonAsync<bool>($"/user/emailIsRegistered/{email}");
        return response;
    }

    public async Task<HttpStatusCode> UpdateAsync(UserRequest user)
    {
        var response = await _client.PatchAsJsonAsync("/user", user);

        return response.StatusCode;
    }

    public async Task<AddressResponse?> GetUserAddress(int id)
    {
        var response = await _client.GetFromJsonAsync<AddressResponse>($"/user/{id}/address");

        return response;
    }

    public async Task<RepositoryStatus> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UserIsAdmin()
    {
        var result = await _client.GetAsync("user/isAdmin");

        return result.IsSuccessStatusCode;
    }
}