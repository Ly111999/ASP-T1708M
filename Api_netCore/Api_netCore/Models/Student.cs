using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_netCore.Controllers.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int ClassId { get; set; }
        public int Status { get; set; }
        public SClass SClass { get; set; }

    }
}
