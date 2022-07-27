using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboutMe = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    SubCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.SubCategoryID);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    IsNew = table.Column<bool>(type: "bit", nullable: false),
                    IsNegotiable = table.Column<bool>(type: "bit", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "SubCategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostImages",
                columns: table => new
                {
                    PostImageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostImages", x => x.PostImageID);
                    table.ForeignKey(
                        name: "FK_PostImages_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "c8fd8d85-25bc-4f12-baa6-6e7406f28278", "Admin", "ADMIN" },
                    { 2, "8e2ddfd5-3cf4-4001-a6e2-715911eb85a7", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Vehicles" },
                    { 2, "Properties" },
                    { 3, "Mobile Phones, Tablets, & Accessories" },
                    { 4, "Electronics & Home Appliances" },
                    { 5, "Home Furniture - Decor" },
                    { 6, "Fashion & Beauty" },
                    { 7, "Pets - Accessories" },
                    { 8, "Kids & Babies" },
                    { 9, "Books, Sports & Hobbies" },
                    { 10, "Jobs" },
                    { 11, "Business - Industrial - Agriculture" },
                    { 12, "Services" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "CityName" },
                values: new object[,]
                {
                    { 1, "Alexandria" },
                    { 2, "Aswan" },
                    { 3, "Asyut" },
                    { 4, "Beheira" },
                    { 5, "Beni Suef" },
                    { 6, "Cairo" },
                    { 7, "Dakahlia" },
                    { 8, "Damietta" },
                    { 9, "Faiyum" },
                    { 10, "Gharbia" },
                    { 11, "Giza" },
                    { 12, "Ismailia" },
                    { 13, "Kafr El Sheikh" },
                    { 14, "Luxor" },
                    { 15, "Matruh" },
                    { 16, "Minya" },
                    { 17, "Monufia" },
                    { 18, "New Valley" },
                    { 19, "North Sinai" },
                    { 20, "Port Said" },
                    { 21, "Qalyubia" },
                    { 22, "Qena" },
                    { 23, "Red Sea" },
                    { 24, "Sharqia" },
                    { 25, "Sohag" },
                    { 26, "South Sinai" },
                    { 27, "Suez" }
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "SubCategoryID", "CategoryID", "SubCategoryName" },
                values: new object[,]
                {
                    { 1, 1, "Cars for Sale" },
                    { 2, 1, "Tyres, Batteries, Oils, &Accessories" },
                    { 3, 1, "Car Spare Parts" },
                    { 4, 1, "Motorcycles & Accessories" },
                    { 5, 1, "Motorcycles & Accessories" },
                    { 6, 1, "Boats - Watercraft" },
                    { 7, 1, "Heavy Trucks, Buses & Other Vehicles" },
                    { 8, 2, "Apartments & Duplex for Sale" },
                    { 9, 2, "Apartments & Duplex for Rent" },
                    { 10, 2, "Villas For Sale" },
                    { 11, 2, "Villas For Rent" },
                    { 12, 2, "Vacation Homes for Sale" },
                    { 13, 2, "Commercial for Sale" },
                    { 14, 2, "Buildings & Lands" },
                    { 15, 3, "Mobile Phones" },
                    { 16, 3, "Tablets" },
                    { 17, 3, "Mobile & Tablet Accessories" },
                    { 18, 3, "Mobile Numbers" },
                    { 19, 4, "Electronics & Home Appliances" },
                    { 20, 4, "TV - Audio - Video" },
                    { 21, 4, "Computers - Accessories" },
                    { 22, 4, "Video games - Consoles" },
                    { 23, 4, "Cameras - Imaging" },
                    { 24, 4, "Home Appliance" },
                    { 25, 5, "Bathroom" },
                    { 26, 5, "Bedroom" },
                    { 27, 5, "Dining Room" },
                    { 28, 5, "Fabrics - Curtains - Carpets" },
                    { 29, 5, "Garden - Outdoor" },
                    { 30, 5, "Home Decoration" },
                    { 31, 5, "Kitchen - Kitchenware" },
                    { 32, 5, "Lighting Tools" },
                    { 33, 5, "Living Room" },
                    { 34, 5, "Multiple/Other Furniture" },
                    { 35, 6, "Women's Clothing" },
                    { 36, 6, "Men's Clothing" },
                    { 37, 6, "Women's Accessories - Cosmetics - Personal Care" },
                    { 38, 6, "Men's Accessories - Personal Care" },
                    { 39, 7, "Birds - Pigeons" },
                    { 40, 7, "Cats" },
                    { 41, 7, "Dogs" },
                    { 42, 7, "Other Pets & Animals" }
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "SubCategoryID", "CategoryID", "SubCategoryName" },
                values: new object[,]
                {
                    { 43, 7, "Accessories - Pet Care Products" },
                    { 44, 8, "Baby & Mom Healthcare" },
                    { 45, 8, "Baby Clothing" },
                    { 46, 8, "Baby Feeding Tools" },
                    { 47, 8, "Cribs - Strollers - Carriers" },
                    { 48, 8, "Toys" },
                    { 49, 8, "Other Baby Items" },
                    { 50, 9, "Antiques - Collectibles" },
                    { 51, 9, "Bicycles" },
                    { 52, 9, "Books" },
                    { 53, 9, "Board - Card Games" },
                    { 54, 9, "Movies - Music" },
                    { 55, 9, "Musical Instruments" },
                    { 56, 9, "Sports Equipment" },
                    { 57, 9, "Study Tools" },
                    { 58, 9, "Tickets - Vouchers" },
                    { 59, 9, "Luggage" },
                    { 60, 9, "Other Items" },
                    { 61, 10, "Accounting, Finance & Banking" },
                    { 62, 10, "Engineering" },
                    { 63, 10, "Designers" },
                    { 64, 10, "Customer Service & Call Center" },
                    { 65, 10, "Workers and Technicians" },
                    { 66, 10, "Management & Consulting" },
                    { 67, 10, "Drivers & Delivery" },
                    { 68, 10, "Education" },
                    { 69, 10, "HR" },
                    { 70, 10, "Tourism, Travel & Hospitality" },
                    { 71, 10, "IT - Telecom" },
                    { 72, 10, "Marketing and Public Relations" },
                    { 73, 10, "Medical, Healthcare, & Nursing" },
                    { 74, 10, "Sales" },
                    { 75, 10, "Secretarial" },
                    { 76, 10, "Guards and Security" },
                    { 77, 10, "Legal - Lawyers" },
                    { 78, 10, "Other Job" },
                    { 79, 11, "Agriculture" },
                    { 80, 11, "Construction" },
                    { 81, 11, "Industrial Equipment" },
                    { 82, 11, "Medical Equipment" },
                    { 83, 11, "Office Furniture & Equipment" },
                    { 84, 11, "Restaurants Equipment" }
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "SubCategoryID", "CategoryID", "SubCategoryName" },
                values: new object[,]
                {
                    { 85, 11, "Whole Business for Sale" },
                    { 86, 11, "Other Business, Industrial &" },
                    { 87, 11, "Agriculture" },
                    { 88, 12, "Business" },
                    { 89, 12, "Car" },
                    { 90, 12, "Events" },
                    { 91, 12, "Health & Beauty" },
                    { 92, 12, "Maintenance" },
                    { 93, 12, "Medical" },
                    { 94, 12, "Movers" },
                    { 95, 12, "Pets" },
                    { 96, 12, "Education" },
                    { 97, 12, "Other Service" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PostImages_PostId",
                table: "PostImages",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_LocationId",
                table: "Posts",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_SubCategoryId",
                table: "Posts",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserID",
                table: "Posts",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryID",
                table: "SubCategories",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "PostImages");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
