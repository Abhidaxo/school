using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_DAL.Migrations
{
    [Migration(2001)]
    public class TeacherClassTable : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Create.Table("TeacherClass")
                 .WithColumn("TeacherClass_Id").AsInt64().PrimaryKey().Identity()
                 .WithColumn("Teacher_Id").AsInt64()
                 .WithColumn("Class_Id").AsInt64();


            Create.ForeignKey("FK_TeacherClass_Teacher_Teacher_Id")
                .FromTable("TeacherClass").ForeignColumn("Teacher_Id")
                .ToTable("Teacher").PrimaryColumn("Teacher_Id");

            Create.ForeignKey("FK_TeacherClass_Class_Class_Id")
                .FromTable("TeacherClass").ForeignColumn("Class_Id")
                .ToTable("Class").PrimaryColumn("Class_Id");
        }
    }
}
