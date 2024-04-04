namespace PasswordManagerClient.Services
{
    public class PasswordGenerator
    {
        public string generateRandomPassword()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+";
            var random = new Random();
            string password = new string(Enumerable.Repeat(chars, 20)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            Console.WriteLine();
            return password;
        }
    }
}
