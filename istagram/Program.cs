using istagram.Admin;
using istagram.User;
using istagram.Post;
Admin admin1 = new("admin1", "admin1@gmail.com", "admin123");
Admin admin2 = new("admin2", "admin2@gmail.com", "admin123");
User user1 = new("user1", "surname1", 11, "user@gmail.com", "user123");
Post post1 = new("content1");
#region Mail&Password
List<string> admin_mails = new();
List<string> admin_passwords = new();
admin_mails.Add("admin1@gmail.com");
admin_mails.Add("admin2@gmail.com");
admin_passwords.Add("admin123");
admin_passwords.Add("admin456");
List<string> user_mails = new();
List<string> user_passwords = new();
user_mails.Add("user@gmail.com");
user_passwords.Add("user123");
#endregion
//------------------------------------

Menu();

void Menu()
{
    int select = 1;
    string[] menu = new string[3]
{
    "Admin",
    "User",
    "Exit"
};
    do
    {
        #region Menu
        Console.Clear();
        switch (select)
        {
            case 1:
                Console.ForegroundColor = ConsoleColor.Magenta;
                foreach (var item in menu)
                {
                    if (item == menu[0])
                    {
                        Console.WriteLine(item);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.WriteLine(item);
                    }
                }
                break;
            case 2:
                foreach (var item in menu)
                {
                    if (item == menu[1])
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(item);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.WriteLine(item);
                    }
                }
                break;
            case 3:
                foreach (var item in menu)
                {
                    if (item == menu[2])
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine(item);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.WriteLine(item);
                    }
                }
                break;
            default:
                break;
        }
        ConsoleKeyInfo info = Console.ReadKey(true);
        if (info.Key == ConsoleKey.UpArrow)
        {
            if (select != 1)
            {
                select--;
            }
            else
            {
                select = 3;
            }
        }
        else if (info.Key == ConsoleKey.DownArrow)
        {
            if (select != 3)
            {
                select++;
            }
            else
            {
                select = 1;
            }
        }
        #endregion

        else if (info.Key == ConsoleKey.Enter)
        {
            string mail;
            string password;
            if (select == 1) // login admin
            {
                Console.Clear();
                LoginAdmin(out mail, out password);
            }
            else if (select == 2) // login & register user
            {
                string[] userMenu = new string[2]
                {
                 "Login",
                 "Register",
                };
                int userSelect = 1;
                do
                {
                    #region UserMainMenu
                    Console.Clear();
                    switch (userSelect)
                    {
                        case 1:
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            foreach (var item in userMenu)
                            {
                                if (item == userMenu[0])
                                {
                                    Console.WriteLine(item);
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                else
                                {
                                    Console.WriteLine(item);
                                }
                            }
                            break;
                        case 2:

                            foreach (var item in userMenu)
                            {
                                if (item == userMenu[1])
                                {
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.WriteLine(item);
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                else
                                {
                                    Console.WriteLine(item);
                                }
                            }
                            break;
                        default:
                            break;
                    }
                    info = Console.ReadKey(true);
                    if (info.Key == ConsoleKey.UpArrow)
                    {
                        if (userSelect != 1)
                            userSelect--;
                        else
                            userSelect = 2;
                    }
                    else if (info.Key == ConsoleKey.DownArrow)
                    {
                        if (userSelect != 2)
                            userSelect++;
                        else
                            userSelect = 1;
                    }
                    #endregion
                    else if (info.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        if (userSelect == 1)
                            LoginUser(out mail, out password);
                        else if (userSelect == 2)
                            RegisterUser();
                    }

                } while (true);
            }
            else
                Environment.Exit(0);
        }
    } while (true);
}

void LoginAdmin(out string mail, out string password)
{
    Console.Write("Enter your mail:");
    mail = Console.ReadLine();
    Console.Write("Enter your password:");
    password = Console.ReadLine();
    foreach (var item in admin_mails)
    {
        if (item == mail)
        {
            int i = admin_mails.IndexOf(item);
            if (admin_passwords[i] == password)
            {
                AdminInner();
                return;
            }
        }
    }
    throw (new KeyNotFoundException(mail));
}
void LoginUser(out string mail, out string password)
{
    Console.Write("Enter your mail:");
    mail = Console.ReadLine();
    Console.Write("Enter your password:");
    password = Console.ReadLine();
    foreach (var item in user_mails)
    {
        if (item == mail)
        {
            int i = user_mails.IndexOf(item);
            if (user_passwords[i] == password)
            {
                UserInner();
                return;
            }
        }
    }
    throw (new KeyNotFoundException(mail));
}
void RegisterUser()
{
    Console.WriteLine("Register");
    Console.WriteLine("----------------");
    Console.Write("Enter name:");
    string name = Console.ReadLine();
    Console.Write("Enter surname:");
    string surname = Console.ReadLine();
    #region Age
    bool tryparse;
    string age_str;
    do
    {
        int age;
        Console.Write("Enter age:");
        age_str = Console.ReadLine();
        tryparse = Int32.TryParse(age_str, out age);
    } while (!tryparse);
    #endregion
    Console.Write("Enter email:");
    string email = Console.ReadLine();
    Console.Write("Enter password:");
    string password = Console.ReadLine();

    User user = new(name, surname, Int32.Parse(age_str), email, password);
    user_mails.Add(email);
    user_passwords.Add(password);
    Menu();
}

void AdminInner() 
{
    int select = 1;
    string[] adminInner = new string[4]
{
    "Add Post",
    "All Users",
    "Delete Post",
    "Exit"
};
    do
    {
        Console.Clear();
        switch (select)
        {
            case 1:
                Console.ForegroundColor = ConsoleColor.Magenta;
                foreach (var item in adminInner)
                {
                    if (item == adminInner[0])
                    {
                        Console.WriteLine(item);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.WriteLine(item);
                    }
                }
                break;
            case 2:
                foreach (var item in adminInner)
                {
                    if (item == adminInner[1])
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(item);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.WriteLine(item);
                    }
                }
                break;
            case 3:
                foreach (var item in adminInner)
                {
                    if (item == adminInner[2])
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine(item);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.WriteLine(item);
                    }
                }
                break;
            case 4:
                foreach (var item in adminInner)
                {
                    if (item == adminInner[3])
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine(item);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.WriteLine(item);
                    }
                }
                break;
            default:
                break;
        }
        ConsoleKeyInfo info = Console.ReadKey(true);
        if (info.Key == ConsoleKey.UpArrow)
        {
            if (select != 1)
                select--;
            else
                select = 4;
        }
        else if (info.Key == ConsoleKey.DownArrow)
        {
            if (select != 4)
                select++;
            else
                select = 1;
        }
        else if (info.Key == ConsoleKey.Enter)
        {
            if (select == 1)
                AddPost();
            else if (select == 2)
                AllUsers();
            else if (select == 3)
                DeletePost();
            else
                Menu();
        }
    } while (true);
}
void AddPost()
{
    Console.Write("Enter content:");
    string content = Console.ReadLine();
    Post new_post = new(content);
    AdminInner();
}
void AllUsers()
{
    Console.Clear();
    User.ShowUsers();
    Console.WriteLine("Press ESC to exit...");
    ConsoleKeyInfo info = Console.ReadKey(true);
    AdminInner();
}
void DeletePost()
{
    Post.ShowPosts();
    Console.Write("Enter Id for Delete Post:");
    string id = Console.ReadLine();
    Post.DeletePost(id);
    AdminInner();
}
void UserInner() 
{
    Post.ShowPosts();
    Console.Write("Enter Post Id for like:");
    string id = Console.ReadLine();
    Post.LikePost(id);
    Console.Clear();

    Post.ShowPosts();
    Console.WriteLine("Press ENTER to continue or\n Press ESC to exit...");
    ConsoleKeyInfo info = Console.ReadKey(true);
    if (info.Key == ConsoleKey.Enter)
    {
        Console.Clear();
        UserInner();
    }
    else if (info.Key == ConsoleKey.Escape)
    {
        Menu();
    }
}
