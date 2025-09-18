using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookstoreApplication.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Biography", "Birthday", "FullName" },
                values: new object[,]
                {
                    { 1, "Pisac iz Srbije", new DateTime(1998, 5, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Ana Radmanović" },
                    { 2, "Romantični pisac", new DateTime(1985, 8, 12, 0, 0, 0, 0, DateTimeKind.Utc), "Marko Jovanović" },
                    { 3, "Pisac naučne fantastike", new DateTime(1990, 3, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Jelena Petrović" },
                    { 4, "Poezija i proza", new DateTime(1975, 11, 2, 0, 0, 0, 0, DateTimeKind.Utc), "Nikola Stojanović" },
                    { 5, "Mladi pisac", new DateTime(2000, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Marija Ilić" }
                });

            migrationBuilder.InsertData(
                table: "Awards",
                columns: new[] { "Id", "Description", "Name", "YearEstablished" },
                values: new object[,]
                {
                    { 1, "Prva nagrada", "Nagrada 1", 2000 },
                    { 2, "Druga nagrada", "Nagrada 2", 2005 },
                    { 3, "Treća nagrada", "Nagrada 3", 2010 },
                    { 4, "Četvrta nagrada", "Nagrada 4", 2015 }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Address", "Name", "Website" },
                values: new object[,]
                {
                    { 1, "Beograd", "Laguna", "https://laguna.rs" },
                    { 2, "Beograd", "Vulkan", "https://vulkan.rs" },
                    { 3, "Beograd", "Dereta", "https://dereta.rs" }
                });

            migrationBuilder.InsertData(
                table: "AuthorAwardBridge",
                columns: new[] { "Id", "AuthorId", "AwardId", "YearAwarded" },
                values: new object[,]
                {
                    { 1, 1, 1, 2020 },
                    { 2, 1, 2, 2021 },
                    { 3, 2, 1, 2019 },
                    { 4, 2, 3, 2020 },
                    { 5, 3, 2, 2021 },
                    { 6, 3, 4, 2022 },
                    { 7, 4, 1, 2018 },
                    { 8, 4, 3, 2019 },
                    { 9, 5, 2, 2020 },
                    { 10, 5, 4, 2021 },
                    { 11, 1, 3, 2022 },
                    { 12, 2, 4, 2022 },
                    { 13, 3, 1, 2020 },
                    { 14, 4, 2, 2021 },
                    { 15, 5, 3, 2022 }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "ISBN", "PageCount", "PublishedDate", "PublisherId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "111111", 200, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Knjiga 1" },
                    { 2, 1, "222222", 150, new DateTime(2019, 5, 10, 0, 0, 0, 0, DateTimeKind.Utc), 2, "Knjiga 2" },
                    { 3, 2, "333333", 300, new DateTime(2018, 7, 20, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Knjiga 3" },
                    { 4, 2, "444444", 120, new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 2, "Knjiga 4" },
                    { 5, 3, "555555", 250, new DateTime(2017, 11, 30, 0, 0, 0, 0, DateTimeKind.Utc), 3, "Knjiga 5" },
                    { 6, 3, "666666", 180, new DateTime(2022, 6, 5, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Knjiga 6" },
                    { 7, 4, "777777", 220, new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, "Knjiga 7" },
                    { 8, 4, "888888", 260, new DateTime(2019, 8, 8, 0, 0, 0, 0, DateTimeKind.Utc), 3, "Knjiga 8" },
                    { 9, 5, "999999", 140, new DateTime(2021, 2, 20, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Knjiga 9" },
                    { 10, 5, "101010", 300, new DateTime(2022, 9, 10, 0, 0, 0, 0, DateTimeKind.Utc), 3, "Knjiga 10" },
                    { 11, 1, "111212", 210, new DateTime(2018, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Knjiga 11" },
                    { 12, 2, "121212", 190, new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Utc), 2, "Knjiga 12" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
