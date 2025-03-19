using AutoMapper;
using ProFit.Core.Entities;
using ProFit.API.PostModels;
using ProFit.API.PutModels;
using ProFit.Core.DTOs;


namespace ProFit.API.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Job, JobPostModel>().ReverseMap();
            CreateMap<CV, CVPostModel>().ReverseMap();
            CreateMap<User, LoginModel>().ReverseMap();
            CreateMap<User, RegisterModel>().ReverseMap();

            CreateMap<Job, JobPutModel>().ReverseMap();
            CreateMap<User, UserPutModel>().ReverseMap();

            CreateMap<Job, JobDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<CV, CvDTO>().ReverseMap();
        }
    }
}
