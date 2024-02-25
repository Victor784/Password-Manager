using System.Text.RegularExpressions;

namespace PasswordManagerClient.Services
{
    //TODO: Improvement : function that recieves value + the regex that it needs to match
    public class FieldInputChecker
    {
        public bool nameIsOk(ref string inputValue)
        {
            if(inputValue == null) 
            {
                return false;
            }
            else
            {
                string pattern = @"^[A-Z][a-z]+$";
                Regex regex = new Regex(pattern);
                return regex.IsMatch(inputValue);
            }
            
        }

        public bool surnameIsOk(ref string inputValue)
        {
            if (inputValue == null)
            {
                return false;
            }
            else 
            {
                string pattern = @"^[A-Z][a-z]+(?:-|\s)*(?:[A-Z][a-z]*)*$";
                Regex regex = new Regex(pattern);
                return regex.IsMatch(inputValue);
            }

        }

        public bool emailIsOk(ref string inputValue)
        {
            if (inputValue == null)
            {
                return false;
            }
            else
            {
                string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                Regex regex = new Regex(pattern);
                return regex.IsMatch(inputValue);
            }

        }

        public bool passwordIsOk(ref string inputValue)
        {
            if (inputValue == null)
            {
                return false;
            }
            else
            {
                //TODO : uncomment this once testing is done
                //string pattern = @"^(?=.*[A-Z])(?=.*[!@#$%^&*()-+=])(?=.*\d).{10,}$";
                //Regex regex = new Regex(pattern);
                //return regex.IsMatch(inputValue);
                return true;
            }

        }
    }
}
