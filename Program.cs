namespace BankSystemDevelopment
{
    internal class Program
    {
        private static List<User> users = new List<User>();
        private static List<Account> accounts = new List<Account>();
        private static User currentUser;
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the Bank System!");

            bool exit = true;
            while (exit)
            {
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");
               
               
                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Register();
                            break;

                        case 2:
                            Login();

                            break;

                        case 3:
                            Console.WriteLine("Goodbye");
                            exit = false;

                            break;

                            default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }
            }
        }
        static void Register()
        {
            Console.WriteLine("Registration");
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your email: ");
            string email = Console.ReadLine();
            if (users.Exists(u => u.Email == email))
            {
                Console.WriteLine("Email already registered. Please use a different email.");
                return;
            }


            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            string encryptedPassword = password;
            User newUser = new User { Name = name, Email = email, Password = encryptedPassword };
            users.Add(newUser);
            Console.WriteLine("Registration successful.");
        }

        static void Login()
        {
            Console.WriteLine("Login user");
            Console.Write("Enter your email: ");
            string email = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            User user = users.Find(u => u.Email == email);
            if (user != null && user.Password == password)
            {
                currentUser = user;
                Console.WriteLine($"Welcome, {user.Name}");
                ShowAccountMenu();
            }
            else
            {
                Console.WriteLine("Invalid email or password. Please try again.");
            }
        }

            static void ShowAccountMenu()
            {
            Console.WriteLine();
            while(currentUser != null)
            {
                Console.WriteLine("1. Create Bank Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Transfer Money");
                Console.WriteLine("5. Account Information");
                Console.WriteLine("6. Logout");
                Console.Write("Enter your choice: ");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            CreateBankAccount();
                            break;

                        case 2:
                            Deposit();

                            break;

                        case 3:
                            Withdraw();

                            break;

                        case 4:
                            TransferMoney();
                           break;

                        case 5:
                            AccountInformation();
                            break;

                            case 6:
                            currentUser = null;
                            Console.WriteLine("Logout");
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }
            }

         }
        static void CreateBankAccount()
        {
            Console.WriteLine("Enter the name of the account holder");
            string name = Console.ReadLine();
            string number = uniqueAccountNumber();
            Console.Write("Enter initial balance: ");


        }
        static string uniqueAccountNumber()
        {
            Random random = new Random();
            return random.Next(1, 999999999).ToString();
        }

        static void Deposit()
        {
            Console.Write("Enter the  account number: ");
            string accountNumber = Console.ReadLine();

        }

        static void Withdraw() 
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();
        }
        static void TransferMoney()
        {
            Console.Write("Enter account number: ");
            string sendMoney = Console.ReadLine();
        }
        static void AccountInformation()
        {
        
        }





    }

}