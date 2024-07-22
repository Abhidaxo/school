﻿using FluentMigrator;
using School_DAL.Model;

namespace School_BL.Database
{
    [Migration(202407221157)]
    public class AddTable : Migration
    {
        public override void Up()
        {
            Create.Table("Student")
                .WithColumn("Roll_No").AsInt64().PrimaryKey().Identity()
                .WithColumn("Student_Name").AsString(100)
                .WithColumn("Student_place").AsString(100);

            Create.Table("Teacher")
               .WithColumn("Teacher_Id").AsInt64().PrimaryKey().Identity()
               .WithColumn("Teacher_Name").AsString(100)
               .WithColumn("Teacher_Subject").AsString(100);
             

            Create.Table("Class")
                .WithColumn("class_Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Class_name").AsString(100);

            Create.Table("StudentClass")
                .WithColumn("StudentClass_Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Roll_No").AsInt64()
                .WithColumn("Class_Id").AsInt64();

            Create.Table("TeacherClass")
                .WithColumn("TeacherClass_Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Teacher_Id").AsInt64()
                .WithColumn("Class_Id").AsInt64();

            Create.Table("Admin")
                .WithColumn("Admin_Id").AsString(100).PrimaryKey()
                .WithColumn("Password").AsString(100);

            Insert.IntoTable("Admin").Row(new { Admin_Id = new NonUnicodeString("admin"), password = new NonUnicodeString("pass") });


            Create.ForeignKey("FK_TeacherClass_Teacher_Teacher_Id")
                .FromTable("TeacherClass").ForeignColumn("Teacher_Id")
                .ToTable("Teacher").PrimaryColumn("Teacher_Id");

            Create.ForeignKey("FK_TeacherClass_Class_Class_Id")
                .FromTable("TeacherClass").ForeignColumn("Class_Id")
                .ToTable("Class").PrimaryColumn("Class_Id");

            Create.ForeignKey("FK_StudentClass_Student_Roll_No")
                .FromTable("StudentClass").ForeignColumn("Roll_No")
                .ToTable("Student").PrimaryColumn("Roll_No");

            Create.ForeignKey("FK_StudentClass_Class_Class_Id")
                .FromTable("StudentClass").ForeignColumn("Class_Id")
                .ToTable("Class").PrimaryColumn("Class_Id");

        }

        public override void Down()
        {
            Delete.Table("Student");
            Delete.Table("Teacher");
            Delete.Table("Class");
            Delete.Table("StudentClass");
            Delete.Table("TeacherClass");
            Delete.Table("Admin");



           // Delete foreign keys first
            Delete.ForeignKey("FK_TeacherClass_Teacher_Teacher_Id").OnTable("TeacherClass");
            Delete.ForeignKey("FK_TeacherClass_Class_Class_Id").OnTable("TeacherClass");
            Delete.ForeignKey("FK_StudentClass_Student_Roll_No").OnTable("StudentClass");
            Delete.ForeignKey("FK_StudentClass_Class_Class_Id").OnTable("StudentClass");

        }
    }
   
}
