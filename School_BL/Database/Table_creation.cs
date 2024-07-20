using FluentMigrator;

namespace School_BL.Database
{
    [Migration(20240719421)]
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
               .WithColumn("Teacher_Subject").AsString(100)
               .WithColumn("password").AsString(100);

            Create.Table("Class")
                .WithColumn("class_Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Class_name").AsString(100);

            //Create.Table("StudentClass")
            //    .WithColumn("student_class_Id").AsInt32().ForeignKey(CL).Identity()
            //    .WithColumn("Roll_No").AsInt64()
            //    .WithColumn("Class").AsInt64();

            //Create.Table("teacherClass")
            //    .WithColumn("Teacher_class_Id").AsInt64().

        }

        public override void Down()
        {
            Delete.Table("Student");
            Delete.Table("Teacher");
            Delete.Table("Class");

        }
    }
   
}
