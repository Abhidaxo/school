using Dapper;
using Microsoft.Extensions.Configuration;
using School_DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_BL.Services
{
    public class StudentDetailsService
    {
        private readonly string _ConnectionString;
        public StudentDetailsService(IConfiguration configuration) 
        {
            _ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public List<dynamic> getStudentDetails()
        {
            connect connection = new connect(_ConnectionString);
            string sql = "SELECT student.Roll_No,student_name,student_place,class_name,teacher_name,teacher_subject FROM student JOIN studentclass JOIN class JOIN teacherclass JOIN teacher WHERE student.Roll_No = studentclass.Roll_No AND class.class_Id = studentclass.Class_Id AND studentclass.Class_Id = teacherclass.Class_Id AND teacher.Teacher_Id = teacherclass.Teacher_Id;";
            List<dynamic> data =  connection._connection.Query<dynamic>(sql).ToList();
            return data;
        }
    }
}
