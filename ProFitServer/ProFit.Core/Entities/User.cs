using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProFit.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Company { get; set; }
        public List<Job> Jobs { get; set; }
        public List<CV> CVs { get; set; }
    }
}
