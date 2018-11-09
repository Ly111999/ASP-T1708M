using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_netCore.Controllers.Models
{
    public class SClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Slot { get; set; }
        public int Status { get; set; }
        public List<Student> Students { get; set; }
    }
}
