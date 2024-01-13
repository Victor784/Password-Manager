using System.Net.Sockets;

namespace PasswordManagerClient.ApiReturnTypes
{
    public class Password
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public long time_of_creation { get; set; }
        public long time_of_last_update { get; set; }
        public long? expiration_date { get; set; }

        public Password() { }

        public Password(int u_id, string emailNew, string pass, long t_of_creation, long t_of_last_update, long t_exp_date) 
        {
            id = 0;
            user_id = u_id;
            email = emailNew;       
            password = pass;
            time_of_creation = t_of_creation;
            time_of_last_update = t_of_last_update;
            expiration_date = t_exp_date;
        }
    }
}
