using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Inbox_Manager
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, List<string>> userMails = new Dictionary<string, List<string>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Statistics")
                {
                    break;
                }

                string[] inputCollection = input.Split("->");
                string cmd = inputCollection[0];
                string username = inputCollection[1];
                
                if (cmd == "Add")
                {
                    if (!userMails.ContainsKey(username))
                    {
                        userMails.Add(username, new List<string>());
                    }
                    else
                    {
                        Console.WriteLine($"{username} is already registered");
                    }
                }
                else if (cmd == "Send")
                {
                    string email = inputCollection[2];
                    if (userMails.ContainsKey(username))
                    {
                        userMails[username].Add(email);
                    }
                }
                else if (cmd == "Delete")
                {
                    if (userMails.ContainsKey(username))
                    {
                        userMails.Remove(username);
                    }
                    else
                    {
                        Console.WriteLine($"{username} not found!");
                    }
                }
            }
            Console.WriteLine($"Users count: {userMails.Keys.Count}");
            foreach (var user in userMails.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine(user.Key);
                foreach (string text in user.Value)
                {
                    Console.WriteLine($" - {text}");
                }
            }
        }
    }
}
