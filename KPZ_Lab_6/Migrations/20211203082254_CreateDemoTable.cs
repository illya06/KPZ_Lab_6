using Microsoft.EntityFrameworkCore.Migrations;

namespace KPZ_Lab_6.Migrations
{
    public partial class CreateDemoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    dept_no = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false),
                    dept_name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    location = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEP_Department", x => x.dept_no);
                });

            migrationBuilder.CreateTable(
                name: "MirarionDemos",
                columns: table => new
                {
                    MigrationNum = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MigrationDemoName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MirarionDemos", x => x.MigrationNum);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    project_no = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false),
                    project_name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    budget = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Project__BC79D7FB7EA6F4C7", x => x.project_no);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    emp_no = table.Column<int>(type: "int", nullable: false),
                    emp_fname = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    emp_lname = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    dept_no = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__129850FA0C0A47DE", x => x.emp_no);
                    table.ForeignKey(
                        name: "FK__Employee__dept_n__267ABA7A",
                        column: x => x.dept_no,
                        principalTable: "Department",
                        principalColumn: "dept_no",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_dept_no",
                table: "Employee",
                column: "dept_no");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "MirarionDemos");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
