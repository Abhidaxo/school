
using School_DAL.Model;

namespace School_BL.GeniricInterface
{
    public interface IStudent : IGenericRepositoryService<Student> { }
    
   
    public interface IStudentClass :  IGenericRepositoryService<StudentClass> { }

    public interface ITeacher : IGenericRepositoryService<Teacher> { }

    public interface ITeacherClass : IGenericRepositoryService<TeacherClass> { }

    public interface IClass : IGenericRepositoryService<Class> { }

}
