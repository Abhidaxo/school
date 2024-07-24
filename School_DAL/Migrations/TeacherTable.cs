using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_DAL.Migrations
{
    [Migration(1009)]
    public class TeacherTable : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {

            Create.Table("Teacher")
               .WithColumn("Teacher_Id").AsInt64().PrimaryKey().Identity()
               .WithColumn("Teacher_Name").AsString(100)
               .WithColumn("Teacher_Subject").AsString(100);
        }
    }
}
