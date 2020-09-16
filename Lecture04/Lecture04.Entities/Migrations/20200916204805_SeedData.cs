using Microsoft.EntityFrameworkCore.Migrations;

namespace Lecture04.Entities.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Metropolis" },
                    { 2, "Gotham City" },
                    { 3, "Atlantis" },
                    { 4, "Themyscira" },
                    { 5, "New York City" },
                    { 6, "Central City" }
                });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 16, "healing factor" },
                    { 17, "heat vision" },
                    { 18, "inexhaustible wealth" },
                    { 19, "instant weaponry" },
                    { 20, "intangibility" },
                    { 23, "magic weaponry" },
                    { 22, "invulnerability" },
                    { 15, "hard light constructs" },
                    { 24, "super speed" },
                    { 25, "super strength" },
                    { 26, "superhuman agility" },
                    { 21, "intelligence" },
                    { 14, "gymnastic ability" },
                    { 11, "flight" },
                    { 12, "force fields" },
                    { 27, "superhuman hearing" },
                    { 10, "exceptional swimming ability" },
                    { 9, "exceptional martial artist" },
                    { 8, "durability" },
                    { 7, "control over sea life" },
                    { 6, "combat strategy" },
                    { 5, "combat skill" },
                    { 4, "brilliant deductive skills" },
                    { 3, "alien technology" },
                    { 2, "advanced technology" },
                    { 1, "ability to breathe underwater" },
                    { 13, "freeze breath" },
                    { 28, "x-ray vision" }
                });

            migrationBuilder.InsertData(
                table: "Superheroes",
                columns: new[] { "Id", "AlterEgo", "CityId", "FirstAppearance", "Gender", "Name", "Occupation" },
                values: new object[,]
                {
                    { 1, "Aquaman", 1, 1941, 1, "Arthur Curry", "King of Atlantis" },
                    { 2, "Superman", 1, 1938, 1, "Clark Kent", "Reporter" },
                    { 3, "Batman", 2, 1939, 1, "Bruce Wayne", "CEO of Wayne Enterprises" },
                    { 7, "Catwoman", 2, 1940, 0, "Selina Kyle", "Thief" },
                    { 8, "Batwoman", 2, 1956, 0, "Kate Kane", "Thief" },
                    { 4, "Wonder Woman", 4, 1941, 0, "Diana", "Amazon Princess" },
                    { 5, "Green Lantern", 5, 1940, 1, "Hal Jordan", "Test pilot" },
                    { 9, "Supergirl", 5, 1959, 0, "Kara Zor-El", "Actress" },
                    { 6, "The Flash", 6, 1940, 1, "Barry Allen", "Forensic scientist" }
                });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[,]
                {
                    { 1, 25 },
                    { 4, 22 },
                    { 4, 11 },
                    { 4, 5 },
                    { 4, 6 },
                    { 4, 26 },
                    { 4, 16 },
                    { 4, 23 },
                    { 5, 15 },
                    { 5, 19 },
                    { 5, 12 },
                    { 5, 11 },
                    { 5, 8 },
                    { 5, 3 },
                    { 9, 25 },
                    { 9, 11 },
                    { 9, 22 },
                    { 9, 24 },
                    { 9, 17 },
                    { 9, 13 },
                    { 9, 28 },
                    { 9, 27 },
                    { 9, 16 },
                    { 6, 24 },
                    { 4, 25 },
                    { 8, 2 },
                    { 8, 21 },
                    { 8, 4 },
                    { 1, 8 },
                    { 1, 7 },
                    { 1, 10 },
                    { 1, 1 },
                    { 2, 25 },
                    { 2, 11 },
                    { 2, 22 },
                    { 2, 24 },
                    { 2, 17 },
                    { 2, 13 },
                    { 2, 28 },
                    { 6, 20 },
                    { 2, 27 },
                    { 3, 9 },
                    { 3, 6 },
                    { 3, 18 },
                    { 3, 4 },
                    { 3, 2 },
                    { 7, 9 },
                    { 7, 14 },
                    { 7, 5 },
                    { 8, 9 },
                    { 8, 6 },
                    { 8, 5 },
                    { 2, 16 },
                    { 6, 26 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 1, 25 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 2, 11 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 2, 13 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 2, 16 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 2, 17 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 2, 22 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 2, 24 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 2, 25 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 2, 27 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 2, 28 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 3, 9 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 3, 18 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 4, 11 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 4, 16 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 4, 22 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 4, 23 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 4, 25 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 4, 26 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 5, 8 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 5, 11 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 5, 12 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 5, 15 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 5, 19 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 6, 20 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 6, 24 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 6, 26 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 7, 5 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 7, 9 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 7, 14 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 8, 4 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 8, 5 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 8, 6 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 8, 9 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 8, 21 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 9, 11 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 9, 13 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 9, 16 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 9, 17 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 9, 22 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 9, 24 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 9, 25 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 9, 27 });

            migrationBuilder.DeleteData(
                table: "SuperheroPowers",
                keyColumns: new[] { "SuperheroId", "PowerId" },
                keyValues: new object[] { 9, 28 });

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Superheroes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Superheroes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Superheroes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Superheroes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Superheroes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Superheroes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Superheroes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Superheroes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Superheroes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
