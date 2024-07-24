using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_DAL.Migrations
{
    [Migration(1000)]
    public class AdminTable : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Create.Table("Admin")
                .WithColumn("Admin_Id").AsString(100).PrimaryKey()
                .WithColumn("Password").AsString(100);

            Insert.IntoTable("Admin").Row(new { Admin_Id = new NonUnicodeString("admin"), password = new NonUnicodeString("pass") });
        }
    }
}
