using PasswordManagerClient.ApiReturnTypes;
using PasswordManagerClient.Services;

namespace PasswordManagerClient.Services
{
    public class UserStateService
    {
        private bool _isUserAuthenticated = false;
        private int _userId = 0;
        private string _token = "";
        private List<Password> _userPasswords;
        private readonly PasswordApiClient _passwordApiClient;
        private readonly CookieStorageAccessor _cookieStorageAccessor;
        private readonly UserApiClient _userApiClient;

        public UserStateService(PasswordApiClient passwordApiClient, CookieStorageAccessor cookieStorageAccessor, UserApiClient userApiClient)
        {
            _passwordApiClient = passwordApiClient;
            _cookieStorageAccessor = cookieStorageAccessor;
            _userApiClient = userApiClient;
        }
        public void IsUserAuthenticated(bool value)
        {
            _isUserAuthenticated = value;
        }

        public async Task<bool> IsUserAuthenticated()
        {
            if (!_isUserAuthenticated)
            {
                //in case of a refresh the state of the class is reset but we might still have cookies saved
                var token = await _cookieStorageAccessor.GetValueAsync("token");
                var res = await checkTokenAuth(token);
                if (res.isAuthenticated)
                    _userId = int.Parse(res.id);
                return res.isAuthenticated;
            }
            return _isUserAuthenticated;
        }
            public void AuthenticateUser()
        {
            IsUserAuthenticated(true);
            _cookieStorageAccessor.SetValueAsync("token", _token);
        }

        public async Task DeauthenticateUser()
        {
            IsUserAuthenticated(false);
            await _cookieStorageAccessor.DisposeAsync();
        }

        public void setUserId(string userId)
        {
            //int.TryParse(userId, out int _userId);
            _userId = Int32.Parse(userId);
        }

        public int getUserId()
        {
            return _userId;
        }

        public async Task<List<Password>> getUserPasswords()
        {
            if (_userPasswords == null)
            {
                await setUserPasswords();
            }
            return _userPasswords;
        }

        public async Task setUserPasswords()
        {
            _userPasswords = await _passwordApiClient.GetPasswordsAsync(_userId);
        }

        public async Task<(bool isAuthenticated, string id)> checkTokenAuth(string token)
        {
            if (token == "")
                return (false, "");
            else
            { 
                var ret = await _userApiClient.AuthenticateAsync(token);
                return (ret.isAuthenticated, ret.id);
            }
        }

        public void setUserToken(string token)
        {
            _token = token;
        }
    }

}
