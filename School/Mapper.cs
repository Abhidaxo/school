using AutoMapper;
using School.ViewModel;
using School_DAL.Model;

namespace School
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Student, StudentViewModel>();
        }

    }
}
