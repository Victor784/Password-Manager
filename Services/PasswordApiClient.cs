using PasswordManagerClient.ApiReturnTypes;
using System.Net.Http.Json;

namespace PasswordManagerClient.Services
{
    public class PasswordApiClient
    {
        private readonly HttpClient httpClient;

        public PasswordApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Password>?> GetPasswordsAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("api/passwords");

                if (response.IsSuccessStatusCode)
                {
                    var password = await response.Content.ReadFromJsonAsync<List<Password>>();
                    Console.WriteLine(password);
                    return password;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return new List<Password>();
        }

        public async Task<int> AddPasswordAsync(Password password)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync("api/passwords", password);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(response);
                    var createdPasswordId = await response.Content.ReadFromJsonAsync<int>();
                    return createdPasswordId;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return -1;
        }

        public async Task<int> UpdatePasswordAsync(int id, Password password)
        {
            try
            {
                var response = await httpClient.PutAsJsonAsync("api/passwords/" + id.ToString(), password);

                var debug = response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(response);
                    return (int)response.StatusCode;
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
