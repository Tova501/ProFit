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
            CreateMap<User, UserPostModel>().ReverseMap();
            CreateMap<CV, CVPostModel>().ReverseMap();

            CreateMap<Job, JobPutModel>().ReverseMap();
            CreateMap<User, UserPutModel>().ReverseMap();

            CreateMap<Job, JobDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<CV, CvDTO>().ReverseMap();
        }
    }
}
