using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace coreHotelRoomBookingAdminPortal.Migrations
{
    public partial class ForFeedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Appearance = table.Column<int>(nullable: false),
                    Eexpectation = table.Column<string>(nullable: true),
                    ImproveServices = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    HotelId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.FeedbackId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbacks");
        }
    }
}
