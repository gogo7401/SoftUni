using System;

namespace _04._Password_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine(); 
            bool isLength = GetLength(password);                        // It should contain 6 – 10 characters (inclusive)
            bool isOnlyLettersDigits = GetOnlyLettersDigits(password);  // It should contain only letters and digits
            bool isTwoDigits = GetTwoDigits(password);                  // It should contain at least 2 digits 

            if (isLength && isOnlyLettersDigits && isTwoDigits)
            {
                Console.WriteLine("Password is valid");
            }
            else
            {
                if (!isLength)
                {
                    Console.WriteLine("Password must be between 6 and 10 characters");
                }
                if (!isOnlyLettersDigits)
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                }
                if (!isTwoDigits)
                {
                    Console.WriteLine("Password must have at least 2 digits");
                }

            }

        }

        private static bool GetTwoDigits(string password)
        {
            bool result = false;
            int digitCount = 0;
            string lettersDigits = "";
            for (int i = 48; i <= 57; i++)  // 0..9
            {
                lettersDigits += (char)i;
            }
            foreach (char c in password)
            {
                if (lettersDigits.IndexOf(c) >= 0)
                {
                    digitCount++;
                }
            }
            if (digitCount >= 2)
            {
                result = true;  
            }

            return result;
        }

        private static bool GetOnlyLettersDigits(string password)
        {
            bool result = true;
            string lettersDigits = "";
            for (int i = 48; i <= 57; i++)  // 0..9
            {
                lettersDigits += (char)i;
            }
            for (int i = 65; i <= 90; i++) // A..Z
            {
                lettersDigits += (char)i;
            }
            for (int i = 97; i <= 122; i++) // a..z
            {
                lettersDigits += (char)i;
            }
            foreach (char c in password)
            {
                if (lettersDigits.IndexOf(c) < 0)
                {
                    result = false;
                }
            }

            return result;
        }

        private static bool GetLength(string password)
        {
            bool result = false;
            if (password.Length >= 6 && password.Length <= 10)
            {
                result = true;
            }

            return result;
        }
    }
}
