using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProFit.Core.Entities
{
    public class Recruiter
    {
        public int Id { get; set; }
cc
        public string Password { get; set; }
        public List<Job> Jobs { get; set; }
    }
}
