namespace PasswordManagerClient.Services
{
    public class AuthenticationService
    {
        private bool _isUserAuthenticated = false;

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
    }

}
