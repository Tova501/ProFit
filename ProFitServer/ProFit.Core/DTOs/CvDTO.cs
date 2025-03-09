using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProFit.Core.DTOs
{
    public class CvDTO
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int UserId { get; set; }
        public int JobId { get; set; }
        public DateTime UploadedDate { get; set; }
        public int Score { get; set; }
    }
}
