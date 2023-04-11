using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_m_countries",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_countries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_leave_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_leave_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_cities",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    country_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_cities", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_m_cities_tb_m_countries_country_id",
                        column: x => x.country_id,
                        principalTable: "tb_m_countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_addresses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    postal_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_addresses", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_m_addresses_tb_m_cities_city_id",
                        column: x => x.city_id,
                        principalTable: "tb_m_cities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<int>(name: "Address Id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_m_departments_tb_m_addresses_Address Id",
                        column: x => x.AddressId,
                        principalTable: "tb_m_addresses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_employees",
                columns: table => new
                {
                    nik = table.Column<string>(type: "nchar(5)", maxLength: 5, nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    hiring_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    department_id = table.Column<int>(type: "int", nullable: false),
                    position_id = table.Column<int>(type: "int", nullable: false),
                    address_id = table.Column<int>(type: "int", nullable: false),
                    manager_id = table.Column<string>(type: "nchar(5)", nullable: true),
                    DepartmentsId = table.Column<int>(type: "int", nullable: true),
                    AddressesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_employees", x => x.nik);
                    table.ForeignKey(
                        name: "FK_tb_m_employees_tb_m_addresses_AddressesId",
                        column: x => x.AddressesId,
                        principalTable: "tb_m_addresses",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_tb_m_employees_tb_m_departments_DepartmentsId",
                        column: x => x.DepartmentsId,
                        principalTable: "tb_m_departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tb_m_employees_tb_m_employees_manager_id",
                        column: x => x.manager_id,
                        principalTable: "tb_m_employees",
                        principalColumn: "nik");
                });

            migrationBuilder.CreateTable(
                name: "tb_m_accounts",
                columns: table => new
                {
                    employee_nik = table.Column<string>(type: "nchar(5)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_accounts", x => x.employee_nik);
                    table.ForeignKey(
                        name: "FK_tb_m_accounts_tb_m_employees_employee_nik",
                        column: x => x.employee_nik,
                        principalTable: "tb_m_employees",
                        principalColumn: "nik",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_positions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeesNIK = table.Column<string>(type: "nchar(5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_positions", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_m_positions_tb_m_employees_EmployeesNIK",
                        column: x => x.EmployeesNIK,
                        principalTable: "tb_m_employees",
                        principalColumn: "nik");
                });

            migrationBuilder.CreateTable(
                name: "tb_tr_account_roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    account_nik = table.Column<string>(type: "nchar(5)", nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tr_account_roles", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_tr_account_roles_tb_m_accounts_account_nik",
                        column: x => x.account_nik,
                        principalTable: "tb_m_accounts",
                        principalColumn: "employee_nik",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_tr_account_roles_tb_m_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "tb_m_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_tr_leave_requests",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    descriptions = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    leave_day = table.Column<int>(type: "int", nullable: false),
                    leave_given = table.Column<int>(type: "int", nullable: false),
                    employee_nik = table.Column<string>(type: "nchar(5)", nullable: false),
                    position_id = table.Column<int>(type: "int", nullable: false),
                    leave_type_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tr_leave_requests", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_tr_leave_requests_tb_m_employees_employee_nik",
                        column: x => x.employee_nik,
                        principalTable: "tb_m_employees",
                        principalColumn: "nik",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_tr_leave_requests_tb_m_leave_type_leave_type_id",
                        column: x => x.leave_type_id,
                        principalTable: "tb_m_leave_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_tr_leave_requests_tb_m_positions_position_id",
                        column: x => x.position_id,
                        principalTable: "tb_m_positions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tb_m_roles",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_addresses_city_id",
                table: "tb_m_addresses",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_cities_country_id",
                table: "tb_m_cities",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_departments_Address Id",
                table: "tb_m_departments",
                column: "Address Id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_employees_AddressesId",
                table: "tb_m_employees",
                column: "AddressesId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_employees_DepartmentsId",
                table: "tb_m_employees",
                column: "DepartmentsId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_employees_email_phone_number",
                table: "tb_m_employees",
                columns: new[] { "email", "phone_number" },
                unique: true,
                filter: "[phone_number] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_employees_manager_id",
                table: "tb_m_employees",
                column: "manager_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_positions_EmployeesNIK",
                table: "tb_m_positions",
                column: "EmployeesNIK");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_account_roles_account_nik",
                table: "tb_tr_account_roles",
                column: "account_nik");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_account_roles_role_id",
                table: "tb_tr_account_roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_leave_requests_employee_nik",
                table: "tb_tr_leave_requests",
                column: "employee_nik");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_leave_requests_leave_type_id",
                table: "tb_tr_leave_requests",
                column: "leave_type_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_leave_requests_position_id",
                table: "tb_tr_leave_requests",
                column: "position_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_tr_account_roles");

            migrationBuilder.DropTable(
                name: "tb_tr_leave_requests");

            migrationBuilder.DropTable(
                name: "tb_m_accounts");

            migrationBuilder.DropTable(
                name: "tb_m_roles");

            migrationBuilder.DropTable(
                name: "tb_m_leave_type");

            migrationBuilder.DropTable(
                name: "tb_m_positions");

            migrationBuilder.DropTable(
                name: "tb_m_employees");

            migrationBuilder.DropTable(
                name: "tb_m_departments");

            migrationBuilder.DropTable(
                name: "tb_m_addresses");

            migrationBuilder.DropTable(
                name: "tb_m_cities");

            migrationBuilder.DropTable(
                name: "tb_m_countries");
        }
    }
}
