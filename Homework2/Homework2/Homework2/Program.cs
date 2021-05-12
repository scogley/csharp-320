using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });


            // 1.Display to the console, the names of the users where the password is "hello" and you can use a foreach here only.Hint: Where
            var user = users.Where(p => p.Password == "hello");
            foreach(var u in user)
            {
                Console.WriteLine(u.Name);
            }

            // 2.Delete any passwords that are the lower-cased version of their Name.
            // Do not just look for "steve".It has to be data - driven.Hint: Remove or RemoveAll

            // 3. Delete the first User that has the password "hello". Hint: First or FirstOrDefault

            // 4. Display to the console the remaining users with their Name and Password. Hint: ForEach

        }
    }
}
