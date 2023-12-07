using System;

namespace _05._Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string passwordInput = "";
            string password = "";
            int wrongCount = 0;

            while (true)
            {
                passwordInput = Console.ReadLine();
                password = "";
                wrongCount++;
                for (int i = passwordInput.Length-1; i >= 0; i--)
                {
                    password += passwordInput[i];
                }
               //Console.WriteLine(password);
                if (password == username)
                {
                    Console.WriteLine($"User {username} logged in.");
                    break;
                }
                else if (wrongCount == 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    //wrongCount = 0;
                    break;
                }
                else { Console.WriteLine("Incorrect password. Try again."); }

            }
        }
    }
}
