using PasswordManagerClient.ApiReturnTypes;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;

namespace PasswordManagerClient.Services
{
    public class UserApiClient
    {
        private readonly HttpClient httpClient;

        public UserApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<User>?> GetUsersAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("api/users");

                if (response.IsSuccessStatusCode)
                {
                    var users = await response.Content.ReadFromJsonAsync<List<User>>();
                    Console.WriteLine(users);
                    return users;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return new List<User>();
        }

        public async Task<bool> AuthenticateAsync(string email, string password)
        {
            try
            {

                var credentials = new
                {
                    Email = email,
                    Password = password
                };

                var json = JsonSerializer.Serialize(credentials);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("api/users/auth", content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
    }
}
