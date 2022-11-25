using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Application.IUserDao;
using Application.Logic;
using Application.LogicInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace WebAPI.Services;

public class AuthService : IAuthService
{
    private readonly UserLoginDto userLogicdto;
    private readonly IUserDao userDao;

    public AuthService(IUserDao userDao)
    {
        this.userDao = userDao;
    }
        
        private readonly HttpClient client = new ();

        public async Task<User> ValidateUser(string username, string password)
        {
            User? existingUser = await userDao.GetByUsernameAsync(username);

            if (existingUser == null)
            {
                throw new Exception("User not found");
            }

            if (!existingUser.Password.Equals(password))
            {
                throw new Exception("Password mismatch");
            }

            return existingUser;
        }

        public Task RegisterUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUser(string username, string password)
        {
            throw new NotImplementedException();
        }
        public static string? Jwt { get; private set; } = "";
    
        private static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            string payload = jwt.Split('.')[1];
            byte[] jsonBytes = ParseBase64WithoutPadding(payload);
            Dictionary<string, object>? keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            return keyValuePairs!.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()!));
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2:
                    base64 += "==";
                    break;
                case 3:
                    base64 += "=";
                    break;
            }

            return Convert.FromBase64String(base64);
        }

        public async Task LoginAsync(string username, string password)
        {
            /*
            User user = await userLogicdto.(username, password);
            */
            
            UserLoginDto userLoginDto = new(username, password)
            {
                UserName = username,
                Password = password
            };

            string userAsJson = JsonSerializer.Serialize(userLoginDto);
            StringContent content = new(userAsJson, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("http://localhost:7055/auth/login", content);
            string responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(responseContent);
            }

            string token = responseContent;
            Jwt = token;

            ClaimsPrincipal principal = CreateClaimsPrincipal();

            OnAuthStateChanged.Invoke(principal);
        }
        
        private static ClaimsPrincipal CreateClaimsPrincipal()
        {
            if (string.IsNullOrEmpty(Jwt))
            {
                return new ClaimsPrincipal();
            }

            IEnumerable<Claim> claims = ParseClaimsFromJwt(Jwt);
    
            ClaimsIdentity identity = new(claims, "jwt");

            ClaimsPrincipal principal = new(identity);
            return principal;
        }

        public Task LogoutAsync()
        {
            throw new NotImplementedException();
        }

        public Task RegisterAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<ClaimsPrincipal> GetAuthAsync()
        {
            throw new NotImplementedException();
        }

        public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
    }


