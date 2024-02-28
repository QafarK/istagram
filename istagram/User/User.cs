namespace istagram.User;
class User
{
    //User=>id,name,surname,age,email,password
    string _id;
    string _name;
    string _surname;
    int _age;
    string _email;
    string _password;
    static List<string> _users = new();

    public User(string name, string surname, int age, string email, string password)
    {
        _id = Guid.NewGuid().ToString();
        _name = name;
        _surname = surname;
        _age = age;
        _email = email;
        _password = password;
        _users.Add(_id + "\n" + _name + "\n" + _surname + "\n" + _age.ToString() + "\n" + _email + "\n" + _password + "\n");
    }
    public static void ShowUsers()
    {
        foreach (var item in _users)
        {
            Console.WriteLine(item);
            Console.WriteLine();
        }
    }
}
