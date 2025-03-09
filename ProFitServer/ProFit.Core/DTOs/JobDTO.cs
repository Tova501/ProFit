using ProFit.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProFit.Core.DTOs
{
    public class JobDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Requirments { get; set; }
        public User User { get; set; }
        public DateTime Created { get; set; }
    }
}
