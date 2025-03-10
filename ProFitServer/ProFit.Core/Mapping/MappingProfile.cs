﻿using AutoMapper;
using ProFit.Core.DTOs;
using ProFit.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProFit.Core.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Job, JobDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<CV, CvDTO>().ReverseMap();
        }
    }
}
