namespace BackOfficeManager.Entities
{
    public class User
    {
        public User(string login, string password) 
        {
            Login = login;
            Password= password;
        }
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; } //TODO need secure string for password
    }
}