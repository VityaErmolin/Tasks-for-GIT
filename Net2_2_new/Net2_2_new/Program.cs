using System;

namespace Net2_2_new
{
    public class Program
    {
        private static void Main()
        {
            var read = new XmlReader();
            var configs = read.XmlRead();
            Console.WriteLine(read.ToString());
            Console.WriteLine(new string('-', 50));

            var users = configs.GetUsers();

            foreach (var user in users)
            {
                if (user.GetIncorrectLogins() != null)
                {
                    Console.WriteLine(user.GetIncorrectLogins());
                }
            }
            
            Console.WriteLine(new string('-', 50));

            Console.WriteLine(read.ToString());

            JsonWriter js = new JsonWriter();
            js.Write(configs);



            Console.WriteLine();

            Console.ReadLine();
        }
    }
}