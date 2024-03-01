using PasswordManagerClient.ApiReturnTypes;
using PasswordManagerClient.Services;

namespace PasswordManagerClient.Services
{
    public class UserStateService
    {
        private bool _isUserAuthenticated = false;
        private int _userId = 0;
        private List<Password> _userPasswords;
        private readonly PasswordApiClient _passwordApiClient;

        public UserStateService(PasswordApiClient passwordApiClient)
        {
            _passwordApiClient = passwordApiClient;
        }
        public bool IsUserAuthenticated
        {
            get { return _isUserAuthenticated; }
            private set { _isUserAuthenticated = value; }
        }
        public void AuthenticateUser()
        {
            IsUserAuthenticated = true;
        }

        public void DeauthenticateUser()
        {
            IsUserAuthenticated = false;
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
    }

}
