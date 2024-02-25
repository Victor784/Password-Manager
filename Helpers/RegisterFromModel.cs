using PasswordManagerClient.ApiReturnTypes;

namespace PasswordManagerClient.Helpers
{
    public enum RegisterFormEnum
    {
        name,
        surname,
        email,
        password
    }

    public class RegisterFormStatus
    {
        public bool nameIsOK { get; set; } = false;
        public bool surnameIsOK { get; set; } = false;

        public bool emailIsOK { get; set; } = false;

        public bool passwordIsOK { get; set; } = false;

        public bool getStatus() 
        {
            return nameIsOK && surnameIsOK && emailIsOK && passwordIsOK;
        }

    }

}
