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

            // Use System.Linq for all the requirements.
            // IE. Don't use a for/foreach loop to manipulate the users list.

            // 1.Display to the console, the names of the users where the password
            // is "hello" and you can use a foreach here only.Hint: Where
            var user = users.Where(p => p.Password == "hello");
            foreach(var u in user)
            {
                Console.WriteLine(u.Name);
            }

            // 2.Delete any passwords that are the lower-cased version of their Name.
            // Do not just look for "steve".It has to be data - driven.Hint: Remove or RemoveAll

            var pass_is_lower_name = users.Where(p => p.Password == p.Name.ToLower());
            if(pass_is_lower_name != null)
            {
                users.Remove(pass_is_lower_name.First());
            }


            // 3. Delete the first User that has the password "hello". Hint: First or FirstOrDefault
            var pass_is_hello = users.Where(p => p.Password == "hello");
            users.Remove(pass_is_hello.First());


            // 4. Display to the console the remaining users with their Name and Password. Hint: ForEach
            Console.WriteLine("remaining users");
            foreach (var u in users)
            {
                Console.WriteLine(u.Name + " " + u.Password);
            }
        }
    }
}
