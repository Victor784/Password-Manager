using PasswordManagerClient.ApiReturnTypes;
using System.Net.Http.Json;

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
    }
}
