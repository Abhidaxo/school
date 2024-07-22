
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;

namespace School_DAL.Database
{
    public class Create_Migration
    {
        public MySqlConnection _con;
        public string _conString;
        public Create_Migration(string constr)
        {
            _conString = constr;
            _con = new MySqlConnection(_conString);
        }
        public void Start_Migration()
        {
            using (_con)
            {

                var serviceProvide = new ServiceCollection()
                    .AddFluentMigratorCore()
                    .ConfigureRunner(r => r
                        .AddMySql5()
                        .WithGlobalConnectionString(_conString)
                        .ScanIn(typeof(Create_Migration).Assembly).For.Migrations())
                    .BuildServiceProvider();

                using (var scope = serviceProvide.CreateScope())
                {
                    var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
                    runner.MigrateUp();
                }
                Console.WriteLine("Migrated");

            }
        }
    }
}
