using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldASP_MVC.Models
{
    public class GuestResponse
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public bool? WillAttend { get; set; }
        public string Email { get; set; }
    }
}
