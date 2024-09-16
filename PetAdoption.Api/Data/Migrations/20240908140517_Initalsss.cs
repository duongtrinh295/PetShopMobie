using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PetAdoption.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initalsss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: false),
                    Breed = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Views = table.Column<int>(type: "int", nullable: false),
                    AdoptionStatus = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Hash = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAdoptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PetId = table.Column<int>(type: "int", nullable: false),
                    AdoptedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAdoptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAdoptions_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAdoptions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFavorites",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavorites", x => new { x.UserId, x.PetId });
                    table.ForeignKey(
                        name: "FK_UserFavorites_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFavorites_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "AdoptionStatus", "Breed", "DateOfBirth", "Description", "Gender", "Image", "IsActive", "Name", "Price", "Views" },
                values: new object[,]
                {
                    { 1, 0, "Dog - Golden Retriever", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Buddy is a friendly and playful Golden Retriever, known for being great with kids.", 0, "wwwroot/images/pets/img_1.jpg", false, "Buddy", 300.0, 0 },
                    { 2, 0, "Cat - Persian", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mittens is a calm and affectionate Persian cat.", 0, "wwwroot/images/pets/img_2.jpg", false, "Mittens", 200.0, 0 },
                    { 3, 0, "Dog - Beagle", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charlie is an energetic Beagle who loves to explore.", 0, "wwwroot/images/pets/img_3.jpg", false, "Charlie", 250.0, 0 },
                    { 4, 0, "Cat - Siamese", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Whiskers is a vocal and curious Siamese cat.", 0, "wwwroot/images/pets/img_4.jpg", false, "Whiskers", 180.0, 0 },
                    { 5, 0, "Dog - Labrador Retriever", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Max is a loyal Labrador Retriever who loves to fetch.", 0, "wwwroot/images/pets/img_5.jpg", false, "Max", 350.0, 0 },
                    { 6, 0, "Dog - Poodle", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bella is an elegant Poodle who enjoys attention.", 0, "wwwroot/images/pets/img_6.jpg", false, "Bella", 300.0, 0 },
                    { 7, 0, "Cat - Ragdoll", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luna is a gentle Ragdoll cat who loves to cuddle.", 0, "wwwroot/images/pets/img_7.jpg", false, "Luna", 250.0, 0 },
                    { 8, 0, "Dog - Boxer", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rocky is a strong Boxer who loves to play.", 0, "wwwroot/images/pets/img_8.jpg", false, "Rocky", 320.0, 0 },
                    { 9, 0, "Cat - British Shorthair", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shadow is a quiet British Shorthair who enjoys solitude.", 0, "wwwroot/images/pets/img_9.jpg", false, "Shadow", 220.0, 0 },
                    { 10, 0, "Dog - Dachshund", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oscar is a curious Dachshund who loves to dig.", 0, "wwwroot/images/pets/img_10.jpg", false, "Oscar", 200.0, 0 },
                    { 11, 0, "Cat - Bengal", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cleo is an active Bengal cat who loves to climb.", 0, "wwwroot/images/pets/img_11.jpg", false, "Cleo", 300.0, 0 },
                    { 12, 0, "Dog - Shih Tzu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daisy is a sweet Shih Tzu who enjoys being pampered.", 0, "wwwroot/images/pets/img_12.jpg", false, "Daisy", 220.0, 0 },
                    { 13, 0, "Cat - Maine Coon", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Simba is a large Maine Coon with a gentle disposition.", 0, "wwwroot/images/pets/img_13.jpg", false, "Simba", 350.0, 0 },
                    { 14, 0, "Dog - Border Collie", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jack is an intelligent Border Collie who loves to work.", 0, "wwwroot/images/pets/img_14.jpg", false, "Jack", 320.0, 0 },
                    { 15, 0, "Cat - Scottish Fold", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nala is a playful Scottish Fold with a unique look.", 0, "wwwroot/images/pets/img_15.jpg", false, "Nala", 280.0, 0 },
                    { 16, 0, "Dog - German Shepherd", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zeus is a protective German Shepherd who is very loyal.", 0, "wwwroot/images/pets/img_16.jpg", false, "Zeus", 400.0, 0 },
                    { 17, 0, "Dog - Cocker Spaniel", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Milo is a friendly Cocker Spaniel with a lot of energy.", 0, "wwwroot/images/pets/img_17.jpg", false, "Milo", 280.0, 0 },
                    { 18, 0, "Cat - Exotic Shorthair", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mochi is a calm Exotic Shorthair who enjoys lounging.", 0, "wwwroot/images/pets/img_18.jpg", false, "Mochi", 250.0, 0 },
                    { 19, 0, "Dog - Pomeranian", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bailey is a lively Pomeranian who loves to be the center of attention.", 0, "wwwroot/images/pets/img_19.jpg", false, "Bailey", 300.0, 0 },
                    { 20, 0, "Cat - Abyssinian", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oliver is a curious Abyssinian who loves to explore.", 0, "wwwroot/images/pets/img_20.jpg", false, "Oliver", 240.0, 0 },
                    { 21, 0, "Dog - Redbone Coonhound", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rusty is an active Redbone Coonhound who loves to run.", 0, "wwwroot/images/pets/img_21.jpg", false, "Rusty", 270.0, 0 },
                    { 22, 0, "Cat - Sphynx", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zoe is a hairless Sphynx with a very affectionate personality.", 0, "wwwroot/images/pets/img_22.jpg", false, "Zoe", 320.0, 0 },
                    { 23, 0, "Dog - Australian Shepherd", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finn is an energetic Australian Shepherd who loves to herd.", 0, "wwwroot/images/pets/img_23.jpg", false, "Finn", 350.0, 0 },
                    { 24, 0, "Cat - Burmese", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lily is a vocal Burmese cat who enjoys human company.", 0, "wwwroot/images/pets/img_24.jpg", false, "Lily", 280.0, 0 },
                    { 25, 0, "Dog - Rottweiler", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rex is a strong Rottweiler who is very protective.", 0, "wwwroot/images/pets/img_25.jpg", false, "Rex", 380.0, 0 },
                    { 26, 0, "Cat - Norwegian Forest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chloe is a fluffy Norwegian Forest cat who loves the outdoors.", 0, "wwwroot/images/pets/img_26.jpg", false, "Chloe", 320.0, 0 },
                    { 27, 0, "Dog - Cavalier King Charles Spaniel", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ginger is a gentle Cavalier King Charles Spaniel who loves to cuddle.", 0, "wwwroot/images/pets/img_27.jpg", false, "Ginger", 330.0, 0 },
                    { 28, 0, "Dog - Shiba Inu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Toby is an independent Shiba Inu with a lot of personality.", 0, "wwwroot/images/pets/img_28.jpg", false, "Toby", 340.0, 0 },
                    { 29, 0, "Cat - Russian Blue", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sasha is a reserved Russian Blue who enjoys quiet environments.", 0, "wwwroot/images/pets/img_29.jpg", false, "Sasha", 300.0, 0 },
                    { 30, 0, "Dog - Bulldog", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bruno is a strong Bulldog with a gentle heart", 0, "wwwroot/images/pets/img_30.jpg", false, "Bruno", 350.0, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAdoptions_PetId",
                table: "UserAdoptions",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAdoptions_UserId",
                table: "UserAdoptions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavorites_PetId",
                table: "UserFavorites",
                column: "PetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAdoptions");

            migrationBuilder.DropTable(
                name: "UserFavorites");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
