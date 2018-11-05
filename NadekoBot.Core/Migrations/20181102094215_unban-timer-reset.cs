using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NadekoBot.Migrations
{
    public partial class unbantimerreset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // I have to remove everything as it has been piling up for a year.
            switch (migrationBuilder.ActiveProvider)
            {
                case "Npgsql.EntityFrameworkCore.PostgreSQL":
                     migrationBuilder.Sql(@"DELETE FROM ""UnbanTimer"";");
                    break;

                case "Microsoft.EntityFrameworkCore.SqlServer":
                     migrationBuilder.Sql(@"DELETE FROM UnbanTimer;");
                    break;
            }

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
