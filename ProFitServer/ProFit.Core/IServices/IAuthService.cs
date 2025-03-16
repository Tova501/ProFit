﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProFit.Core.IServices
{
    public interface IAuthService
    {
        public string GenerateJwtToken(string userName, string[] roles);
    }
}
