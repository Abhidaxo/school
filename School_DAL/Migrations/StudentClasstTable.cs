using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_DAL.Migrations
{
    [Migration(2000)]
    public class StudentClasstTable : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Create.Table("StudentClass")
               .WithColumn("StudentClass_Id").AsInt32().PrimaryKey().Identity()
               .WithColumn("Roll_No").AsInt64()
               .WithColumn("Class_Id").AsInt64();


            Create.ForeignKey("FK_StudentClass_Student_Roll_No")
                .FromTable("StudentClass").ForeignColumn("Roll_No")
                .ToTable("Student").PrimaryColumn("Roll_No");

            Create.ForeignKey("FK_StudentClass_Class_Class_Id")
                .FromTable("StudentClass").ForeignColumn("Class_Id")
                .ToTable("Class").PrimaryColumn("Class_Id");
        }
    }
}
