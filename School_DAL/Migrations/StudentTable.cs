using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_DAL.Migrations
{
    [Migration(1003)]
    public class StudentTable : Migration
    {
       
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Create.Table("Student")
                .WithColumn("Roll_No").AsInt64().PrimaryKey().Identity()
                .WithColumn("Student_Name").AsString(100)
                .WithColumn("Student_place").AsString(100);
        }
    }
}
