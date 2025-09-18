#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        const string CUSTOMER = "Customer";
        const string ADDRESS = "Address";
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: CUSTOMER,
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: ADDRESS,
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    addressLine = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    country = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    state = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    zipCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    customerId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.id);
                    table.ForeignKey(
                        name: "FK_Address_Customer_customerId",
                        column: x => x.customerId,
                        principalTable: CUSTOMER,
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: CUSTOMER,
                columns: new[] { "id", "birthday", "email", "name", "phoneNumber" },
                values: new object[,]
                {
                    { 1L, new DateTime(2002, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alexfi2@gmail.com", "Alex Figueroa", "8090000000" },
                    { 2L, new DateTime(1995, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "gomcarla8@gmail.com", "Carla Gomez", "8091111111" },
                    { 3L, new DateTime(1999, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "lperez1999@gmail.com", "Luis Perez", "8092222222" }
                });

            migrationBuilder.InsertData(
                table: ADDRESS,
                columns: new[] { "id", "addressLine", "country", "customerId", "state", "zipCode" },
                values: new object[,]
                {
                    { 1L, "Bayona", "Dominican Republic", 1L, "Santo Domingo", "10903" },
                    { 2L, "Cliffside Park", "United States", 2L, "New Jersey", "07010" },
                    { 3L, "Las Caobas", "Dominican Republic", 1L, "Santo Domingo", "10905" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_customerId",
                table: ADDRESS,
                column: "customerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: ADDRESS);

            migrationBuilder.DropTable(
                name: CUSTOMER);
        }
    }
}
