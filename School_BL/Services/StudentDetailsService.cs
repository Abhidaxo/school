﻿using Dapper;
using Microsoft.Extensions.Configuration;
using School_DAL.Database;
using School_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_BL.Services
{
    public class StudentDetailsService 
    {
        private string _ConnectionString;
        public StudentDetailsService(IConfiguration configuration) 
        {
            _ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }
     
        public List<dynamic> getStudentDetails()
        {
            GenricSqlRequest<dynamic> sqlReq = new GenricSqlRequest<dynamic>(_ConnectionString);
            string sql = "SELECT student.Roll_No,student_name,student_place,class_name,teacher_name,teacher_subject FROM student JOIN studentclass JOIN class JOIN teacherclass JOIN teacher WHERE student.Roll_No = studentclass.Roll_No AND class.class_Id = studentclass.Class_Id AND studentclass.Class_Id = teacherclass.Class_Id AND teacher.Teacher_Id = teacherclass.Teacher_Id;";
            return sqlReq.GetAllDatas(sql);
        }
    }
}
