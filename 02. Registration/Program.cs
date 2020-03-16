using System;
using System.Text.RegularExpressions;

namespace _02._Registration
{
    class Program
    {
        static void Main()
        {
            int numberInput = int.Parse(Console.ReadLine());
            int countReg = 0;
            for (int i = 0; i < numberInput; i++)
            {
                string text = Console.ReadLine();

                Regex pattern = new Regex(@"^(U\$)(?<username>[A-Z][a-z]{2,})(U\$)(P\@\$)(?<password>[A-Za-z]{5,}[0-9]+)(P\@\$)$");
                Match mailMatch = pattern.Match(text);

                if (mailMatch.Success)
                {
                    string userName = mailMatch.Groups["username"].Value;
                    string passWord = mailMatch.Groups["password"].Value;
                    Console.WriteLine("Registration was successful");
                    Console.WriteLine($"Username: {userName}, Password: {passWord}");
                    countReg++;
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }
            Console.WriteLine($"Successful registrations: {countReg}");
        }
    }
}
