namespace istagram.Admin;
class Admin
{
    string _id;
    string _username;
    string _email;
    string _password;

    public Admin(string username, string email, string password)
    {
        _id = Guid.NewGuid().ToString();
        _username = username;
        _email = email;
        _password = password;
    }
}
