﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProFit.Core.DTOs
{
    public class RoleDTO
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
    }
}
