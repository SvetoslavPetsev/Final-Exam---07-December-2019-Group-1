using System;
using System.Collections.Generic;

namespace _01._Email_Validator
{
    class Program
    {
        static void Main()
        {
            string mail = Console.ReadLine();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Complete")
                {
                    break;
                }
                string[] cmdCollection = input.Split();
                string cmd = cmdCollection[0];
                if (cmd == "Make")
                {
                    string type = cmdCollection[1];
                    if (type == "Upper")
                    {
                        mail = mail.ToUpper();
                        Console.WriteLine(mail);
                    }
                    else if (type == "Lower")
                    {
                        mail = mail.ToLower();
                        Console.WriteLine(mail);
                    }
                }
                else if (cmd == "GetDomain")
                {
                    int count = int.Parse(cmdCollection[1]);
                    if (count < mail.Length)
                    {
                        string substring = mail.Substring(mail.Length - count, count);
                        Console.WriteLine(substring);
                    }
                }
                else if (cmd == "GetUsername")
                {
                    if (!mail.Contains('@'))
                    {
                        Console.WriteLine($"The email {mail} doesn't contain the @ symbol.");
                        continue;
                    }
                    int index = mail.IndexOf('@');
                    string userName = mail.Substring(0, index);
                    Console.WriteLine(userName);
                }
                else if (cmd == "Replace")
                {
                    char symbol = char.Parse(cmdCollection[1]);
                    mail = mail.Replace(symbol, '-');
                    Console.WriteLine(mail);
                }
                else if (cmd == "Encrypt")
                {
                    List<int> ascii = new List<int>();
                    foreach (char symbol in mail)
                    {
                        int numAscii = (int)symbol;
                        ascii.Add(numAscii);
                    }
                    Console.WriteLine(string.Join(" ", ascii));
                }
            }
        }
    }
}
