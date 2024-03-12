using PasswordManagerClient.ApiReturnTypes;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using System.Net;


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

        public async Task<(bool isAuthenticated, string id)> AuthenticateAsync(string email, string password)
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

                    var responseContent = await response.Content.ReadAsStringAsync();
                    var responseData = JsonSerializer.Deserialize<Dictionary<string, object>>(responseContent);

                    if (responseData.ContainsKey("userId"))
                    {
                        return (true, responseData["userId"].ToString());
                    }
                    else
                    {
                        return (false,"");
                    }
                }
                else
                {
                    return (false, "");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Console.WriteLine($"Error: {ex.Message}");
                return (false, "An error occured in API client");
            }
        }

        public async Task<int> AddUserAsync(User user)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync("api/users", user);

                if (response.StatusCode == HttpStatusCode.Created)
                {
                    Console.WriteLine(response);
                    var createdUser = await response.Content.ReadFromJsonAsync<User>();
                    //var createdUserId = await response.Content.ReadFromJsonAsync<int>();
                    return createdUser.id;
                }
                else if(response.StatusCode == HttpStatusCode.Conflict)
                {
                    return -2;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return -1;
        }
    }
}
