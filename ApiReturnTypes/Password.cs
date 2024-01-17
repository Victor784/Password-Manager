using System.Net.Sockets;

namespace PasswordManagerClient.ApiReturnTypes
{
    public class Password
    {
        public string id { get; set; }
        public string  user_id { get; set; }
        public string associated_email { get; set; }
        public string associated_website { get; set; }
        public string password_value { get; set; }
        public long time_of_creation { get; set; }
        public long time_of_last_update { get; set; }
        public long? expiration_date { get; set; }

        public Password() { }

        public Password(string id, string user_id, string associated_website , string associated_email, string password_value, int time_of_creation, int time_of_last_update, int expiration_date = 0) 
        {
            this.id = id;
            this.user_id = user_id;  
            this.associated_website = associated_website;
            this.associated_email = associated_email;
            this.password_value = password_value;
            this.time_of_creation = time_of_creation;
            this.time_of_last_update = time_of_last_update;
            this.expiration_date = expiration_date;
        }

        public Password(string user_id, string associated_website , string associated_email, string password_value, int time_of_creation, int time_of_last_update, int expiration_date = 0)
        {
            this.id = "0";
            this.user_id = user_id;
            this.associated_website = associated_website;
            this.associated_email = associated_email;
            this.password_value = password_value;
            this.time_of_creation = time_of_creation;
            this.time_of_last_update = time_of_last_update;
            this.expiration_date = expiration_date;
        }
    }
}
