namespace PasswordManagerClient.Services
{
    public class UserStateService
    {
        private bool _isUserAuthenticated = false;
        private int _userId = 0;
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
    }

}
