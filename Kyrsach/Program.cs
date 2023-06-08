namespace Kyrasch
{
    public class Program
    {
        public const string Users = "users.txt";
        public const string Toys = "toys.txt";

        public struct UsersInfo
        {
            public string infoOfUser;
        }

        public struct ToysInfo
        {
            public string name;
            public int? price;
            public string manufacturer;
            public int? quantity;
            public int? minAge;
        }

        public static void Exit()
        {
            Environment.Exit(0);
        }

        public static void DelUsers(UsersInfo usersInfo)
        {
            var arrayOfUsers = File.ReadAllLines(Users);

            var positionStr = "";
            var positionInt = 0;

            while (true)
            {
                System.Console.Write("Какую позицию вы хотите удалить: ");
                positionStr = Console.ReadLine();

                if (positionStr == null)
                {
                    System.Console.WriteLine("Повторите попытку");
                    continue;
                }

                int.TryParse(positionStr, out positionInt);

                if (positionInt > arrayOfUsers.Length || positionInt <= 0)
                {
                    System.Console.WriteLine("Такой позиции нету. Повторите попытку");
                    continue;
                }

                if (usersInfo.infoOfUser == arrayOfUsers[positionInt - 1])
                {
                    System.Console.WriteLine("Этот пользователь вы");
                    continue;
                }
                break;
            }

            for (int i = positionInt - 1; i < arrayOfUsers.Length - 1; i++)
            {
                arrayOfUsers[i] = arrayOfUsers[i + 1];
            }
            Array.Resize(ref arrayOfUsers, arrayOfUsers.Length - 1);

            File.WriteAllText(Users, "");

            for (var i = 0; i < arrayOfUsers.Length; i++)
            {
                File.AppendAllText(Users, arrayOfUsers[i] + "\n");
            }

            var count = 0;

            foreach (var el in arrayOfUsers)
            {
                count++;
                System.Console.WriteLine(count + ": " + el);
            }

        }

        public static void AddUsers()
        {
            UsersInfo usersInfo;

            var flagRole = "";
            var flagUser = "";
            var flagPassword = "";
            var flagFounderUser = true;

            var arrayOfUsers = File.ReadAllLines(Users);

            usersInfo.infoOfUser = "";
            string[] arrayTemp;

            while (flagFounderUser)
            {
                System.Console.Write("Введиет логин: ");
                flagUser = Console.ReadLine()! + " ";
                System.Console.Write("Введиет пароль: ");
                flagPassword = Console.ReadLine()! + " ";
                System.Console.Write("Введиет роль (1 или 0): ");

                flagRole = Console.ReadLine()!;
                if (!(flagRole == "1" || flagRole == "0" && flagUser != null && flagPassword != null && flagRole != null))
                {
                    System.Console.WriteLine("Повторите попытку");
                    continue;
                }

                usersInfo.infoOfUser = flagUser;
                usersInfo.infoOfUser += flagPassword;
                usersInfo.infoOfUser += flagRole;

                arrayTemp = usersInfo.infoOfUser.Split(" ");

                if (arrayTemp.Length != 3)
                {
                    System.Console.WriteLine("Повторите попытку (Не пишите пробел)");
                    continue;
                }

                for (int i = 0; i < arrayOfUsers.Length; i++)
                {
                    if (arrayOfUsers[i] == usersInfo.infoOfUser)
                    {
                        flagFounderUser = true;
                        break;
                    }
                    flagFounderUser = false;
                }
                if (flagFounderUser)
                {
                    System.Console.WriteLine("Такой пользователь уже есть");
                }
            }

            File.AppendAllText(Users, usersInfo.infoOfUser + "\n");

            arrayOfUsers = File.ReadAllLines(Users);

            var count = 0;

            foreach (var el in arrayOfUsers)
            {
                count++;
                System.Console.WriteLine(count + ": " + el);
            }
        }

        public static void ListUserAdmin(UsersInfo usersInfo)
        {
            var arrayOfUsers = File.ReadAllLines(Users);

            var count = 0;

            foreach (var el in arrayOfUsers)
            {
                count++;
                System.Console.WriteLine(count + ": " + el);
            }

            var move = "";

            var flag = true;

            while (flag)
            {
                System.Console.WriteLine("Удалить (1), добавить (2), назад(3): ");
                move = Console.ReadLine();

                switch (move)
                {
                    case "1": DelUsers(usersInfo); break;
                    case "2": AddUsers(); break;
                    case "3": MenuAdmin(usersInfo); break;
                    default: System.Console.WriteLine("Повторите попытку"); break;
                }
            }
        }

        public static void AddToysAdmin()
        {
            ToysInfo toysInfo;

            var flagBreak = false;

            while (true)
            {
                System.Console.Write("Введите название: ");
                toysInfo.name = Console.ReadLine()!;

                System.Console.Write("Введите изготовителя: ");
                toysInfo.manufacturer = Console.ReadLine()!;

                try
                {
                    System.Console.Write("Введите цену: ");
                    toysInfo.price = int.Parse(Console.ReadLine()!);

                    System.Console.Write("Введите количество: ");
                    toysInfo.quantity = int.Parse(Console.ReadLine()!);

                    System.Console.Write("Введите возростнуе огроничение: ");
                    toysInfo.minAge = int.Parse(Console.ReadLine()!);
                }
                catch (FormatException)
                {
                    System.Console.WriteLine("Повторите попытку");
                    continue;
                }
                finally
                {
                    flagBreak = true;
                }

                if (flagBreak)
                {
                    break;
                }
            }

            File.AppendAllText(Toys, toysInfo.name + "        " + toysInfo.manufacturer + "            " + toysInfo.price + "        " + toysInfo.quantity + "          " + toysInfo.minAge + "\n");

            var array = File.ReadAllLines(Toys);

            var count = 0;

            foreach (var el in array)
            {
                count++;
                System.Console.WriteLine((count) + ": " + el);
            }
        }

        public static void DelToysAdmin()
        {
            var arrayOfToys = File.ReadAllLines(Toys);

            var positionStr = "";
            var positionInt = 0;

            while (true)
            {
                System.Console.Write("Какую позицию вы хотите удалить: ");
                positionStr = Console.ReadLine();

                if (positionStr == null)
                {
                    System.Console.WriteLine("Повторите попытку");
                    continue;
                }

                int.TryParse(positionStr, out positionInt);

                if (positionInt > arrayOfToys.Length || positionInt <= 0)
                {
                    System.Console.WriteLine("Такой позиции нету. Повторите попытку");
                    continue;
                }

                break;
            }

            positionInt++;

            for (int i = positionInt - 1; i < arrayOfToys.Length - 1; i++)
            {
                arrayOfToys[i] = arrayOfToys[i + 1];
            }
            Array.Resize(ref arrayOfToys, arrayOfToys.Length - 1);

            File.WriteAllText(Toys, "");

            for (var i = 0; i < arrayOfToys.Length; i++)
            {
                File.AppendAllText(Toys, arrayOfToys[i] + "\n");
            }

            var count = 0;

            foreach (var el in arrayOfToys)
            {
                count++;
                if (count == 1) System.Console.WriteLine(el);
                else System.Console.Write((count - 1) + ": " + el);
            }
        }

        public static void SortQuantity(string[][] arrayOfToys)
        {
            var arrayTemp = "";

            for (var i = 0; i < arrayOfToys.Length; i++)
            {
                for (var j = 0; j < arrayOfToys.Length - 1; j++)
                {
                    if (int.Parse(arrayOfToys[j][3]) > int.Parse(arrayOfToys[j + 1][3]))
                    {
                        arrayTemp = arrayOfToys[j][3];
                        arrayOfToys[j][3] = arrayOfToys[j + 1][3];
                        arrayOfToys[j + 1][3] = arrayTemp;
                    }
                }
            }

            System.Console.WriteLine("название\tизготовитель\tцена\tколичестов\tминимальный возрост");

            var count = 0;
            var pintString = "";

            for (var i = 0; i < arrayOfToys.Length; i++)
            {
                count++;
                System.Console.Write(count + ": ");
                pintString = String.Join("\t", arrayOfToys[i]);
                System.Console.WriteLine(pintString);
            }
        }

        public static void SortMinAge(string[][] arrayOfToys)
        {
            var arrayTemp = "";

            for (var i = 0; i < arrayOfToys.Length; i++)
            {
                for (var j = 0; j < arrayOfToys.Length - 1; j++)
                {
                    if (int.Parse(arrayOfToys[j][4]) > int.Parse(arrayOfToys[j + 1][4]))
                    {
                        arrayTemp = arrayOfToys[j][4];
                        arrayOfToys[j][4] = arrayOfToys[j + 1][4];
                        arrayOfToys[j + 1][4] = arrayTemp;
                    }
                }
            }

            System.Console.WriteLine("название\tизготовитель\tцена\tколичестов\tминимальный возрост");

            var count = 0;
            var pintString = "";

            for (var i = 0; i < arrayOfToys.Length; i++)
            {
                count++;
                System.Console.Write(count + ": ");
                pintString = String.Join("\t", arrayOfToys[i]);
                System.Console.WriteLine(pintString);
            }
        }

        public static void SortPrice(string[][] arrayOfToys)
        {
            var arrayTemp = "";

            for (var i = 0; i < arrayOfToys.Length; i++)
            {
                for (var j = 0; j < arrayOfToys.Length - 1; j++)
                {
                    if (int.Parse(arrayOfToys[j][2]) > int.Parse(arrayOfToys[j + 1][2]))
                    {
                        arrayTemp = arrayOfToys[j][2];
                        arrayOfToys[j][2] = arrayOfToys[j + 1][2];
                        arrayOfToys[j + 1][2] = arrayTemp;
                    }
                }
            }

            System.Console.WriteLine("название\tизготовитель\tцена\tколичестов\tминимальный возрост");

            var count = 0;
            var pintString = "";

            for (var i = 0; i < arrayOfToys.Length; i++)
            {
                count++;
                System.Console.Write(count + ": ");
                pintString = String.Join("\t", arrayOfToys[i]);
                System.Console.WriteLine(pintString);
            }
        }

        public static void SortToys(UsersInfo usersInfo)
        {
            var arrayOfToys = File.ReadAllLines(Toys);

            var arrayOfToysTemp = new string[arrayOfToys.Length][];

            for (var i = 0; i < arrayOfToys.Length; i++)
            {
                arrayOfToysTemp[i] = arrayOfToys[i].Split(" ").Where(x => x != "").ToArray();
            }

            System.Console.WriteLine("Соритровать по цене(1), соритровать по количеству(2), сортировать по возросту(3), назад(4): ");
            var move = Console.ReadLine();

            switch (move)
            {
                case "1": SortPrice(arrayOfToysTemp); break;
                case "2": SortQuantity(arrayOfToysTemp); break;
                case "3": SortMinAge(arrayOfToysTemp); break;
                case "4": ListToysAdmin(usersInfo); break;
                default: System.Console.WriteLine("Повторите попытку"); break;
            }
        }

        public static void ListToysAdmin(UsersInfo usersInfo)
        {

            var move = "";

            var arrayOfToys = File.ReadAllLines(Toys);

            var count = 0;

            System.Console.WriteLine("название\tизготовитель\tцена\tколичестов\tминимальный возрост");

            var arrayOfToysTemp = new string[arrayOfToys.Length][];
            var pintString = "";

            for (var i = 0; i < arrayOfToys.Length; i++)
            {
                arrayOfToysTemp[i] = arrayOfToys[i].Split(" ").Where(x => x != "").ToArray();
            }

            for (var i = 0; i < arrayOfToys.Length; i++)
            {
                count++;
                System.Console.Write(count + ": ");
                pintString = String.Join("\t", arrayOfToysTemp[i]);

                for (var j = 0; j < 5; j++)
                {
                    System.Console.Write(arrayOfToysTemp[i][j] + "\t");
                }
                System.Console.WriteLine();
            }

            while (true)
            {
                System.Console.Write("Сортировать игрушки(1), добавить игрушку(2), удалить игрушку(3), назад(4): ");
                move = Console.ReadLine();

                switch (move)
                {
                    case "1": SortToys(usersInfo); break;
                    case "2": AddToysAdmin(); break;
                    case "3": DelToysAdmin(); break;
                    case "4": MenuAdmin(usersInfo); break;
                    default: System.Console.WriteLine("Повторите попытку"); break;
                }
            }
        }

        public static void MenuAdmin(UsersInfo usersInfo)
        {
            while (true)
            {
                var move = "";
                System.Console.Write("Списки пользователей(1), списки игрушек(2), выход из программы(3): ");
                move = Console.ReadLine();

                switch (move)
                {
                    case "1": ListUserAdmin(usersInfo); break;
                    case "2": ListToysAdmin(usersInfo); break;
                    case "3": Exit(); break;
                    default: System.Console.WriteLine("Повторите попытку"); break;
                }
            }
        }

        public static void StartStatus()
        {
            var fs = new FileStream(Toys, FileMode.OpenOrCreate);
            fs.Close();

            fs = new FileStream(Users, FileMode.OpenOrCreate);
            fs.Close();

            var arrayOfUsers = File.ReadAllLines(Users);

            var flag = true;

            for (int i = 0; i < arrayOfUsers.Length; i++)
            {
                if ("1" == arrayOfUsers[i].Split(" ")[2])
                {
                    flag = false;
                }
            }

            if (flag) File.AppendAllText(Users, "admin admin 1" + "\n");
        }

        public static void SortLim()
        {
            var x = 0;

            while (true)
            {
                System.Console.Write("Ведите возраст: ");
                var year = Console.ReadLine();

                if (year == "" || !(int.TryParse(year, out x)))
                {
                    System.Console.WriteLine("Повторите попытку");
                    continue;
                }

                break;
            }

            var arrayOfToys = File.ReadAllLines(Toys);

            var arrayOfToysTemp = new string[arrayOfToys.Length][];
            var pintString = "";

            for (var i = 0; i < arrayOfToys.Length; i++)
            {
                arrayOfToysTemp[i] = arrayOfToys[i].Split(" ").Where(x => x != "").ToArray();
            }

            var count = 0;

            for (int i = 0; i < arrayOfToys.Length; i++)
            {
                if (int.Parse(arrayOfToysTemp[i][4]) <= x)
                {
                    count++;
                    System.Console.Write(count + ": ");
                    pintString = String.Join("\t", arrayOfToys[i]);
                    System.Console.WriteLine(pintString);
                }
            }
        }

        public static void MenuUser(UsersInfo usersInfo)
        {
            var arrayOfToys = File.ReadAllLines(Toys);

            var count = 0;

            var pintString = "";

            for (var i = 0; i < arrayOfToys.Length; i++)
            {
                count++;
                System.Console.Write(count + ": ");
                pintString = String.Join("\t", arrayOfToys[i]);
                System.Console.Write(pintString + "\n");
            }

            while (true)
            {
                System.Console.Write("Сортировать массив(1), отобрать по минимальному возросту(2), выход(3): ");
                var move = Console.ReadLine();

                switch (move)
                {
                    case "1": SortToys(usersInfo); break;
                    case "2": SortLim(); break;
                    case "3": Exit(); break;
                    default: System.Console.WriteLine("Повторите попытку"); break;
                }
            }
        }

        public static void Login()
        {
            UsersInfo usersInfo;

            var flagRole = "";
            var flagUser = "";
            var flagPassword = "";
            var flagFounderUser = true;

            var arrayOfUsers = File.ReadAllLines(Users);

            usersInfo.infoOfUser = "";
            string[] arrayTemp;

            while (flagFounderUser)
            {
                System.Console.Write("Введиет логин: ");
                flagUser = Console.ReadLine()!;
                System.Console.Write("Введиет пароль: ");
                flagPassword = Console.ReadLine()!;
                System.Console.Write("Введиет роль (1 или 0): ");

                flagRole = Console.ReadLine()!;
                if (!(flagRole == "1" || flagRole == "0" && flagUser != null && flagPassword != null && flagRole != null))
                {
                    System.Console.WriteLine("Повторите попытку");
                    continue;
                }

                usersInfo.infoOfUser = flagUser + " ";
                usersInfo.infoOfUser += flagPassword + " ";
                usersInfo.infoOfUser += flagRole;

                arrayTemp = usersInfo.infoOfUser.Split(" ");

                if (arrayTemp.Length != 3)
                {
                    System.Console.WriteLine("Повторите попытку (Не пишите пробел)");
                    continue;
                }

                for (int i = 0; i < arrayOfUsers.Length; i++)
                {
                    if (arrayOfUsers[i] == usersInfo.infoOfUser)
                    {
                        flagFounderUser = false;
                        break;
                    }
                }
                if (flagFounderUser)
                {
                    System.Console.WriteLine("Такого пользователя нету");
                }
            }

            if (flagRole == "1")
            {
                MenuAdmin(usersInfo);
            }
            else if (flagRole == "0")
            {
                MenuUser(usersInfo);
            }
        }

        public static void Main(string[] args)
        {
            StartStatus();
            Login();
        }
    }
}