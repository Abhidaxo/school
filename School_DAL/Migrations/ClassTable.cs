using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_DAL.Migrations
{
    [Migration(1001)]
    public class ClassTable : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Create.Table("Class")
               .WithColumn("class_Id").AsInt64().PrimaryKey().Identity()
               .WithColumn("Class_name").AsString(100);
        }
    }
}
