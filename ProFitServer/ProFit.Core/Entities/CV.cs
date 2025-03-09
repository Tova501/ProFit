using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProFit.Core.Entities
{
    public class CV
    {
        public int Id {  get; set; }
        public string Path { get; set; }
        public User User { get; set; }
        public Job Job { get; set; }
        public DateTime UploadedDate { get; set; }
        public int Score { get; set; }
    }
}
