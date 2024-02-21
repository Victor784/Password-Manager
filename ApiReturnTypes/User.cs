namespace PasswordManagerClient.ApiReturnTypes
{
    public class User
    {
        public int id { get; set; }
        public string? email { get; set; }

        public string? password { get; set; }

        public string? name { get; set; }
        public string? surname { get; set; }

        public string? date_of_registration { get; set; } // stored as time since epoch 

        public bool? is_active { get; set; } = null;

        public bool? is_confirmed { get; set; } = null;
    }
}
