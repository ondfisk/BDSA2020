using Microsoft.EntityFrameworkCore.Migrations;

namespace Lecture10.Entities.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Powers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Powers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Superheroes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    AlterEgo = table.Column<string>(maxLength: 50, nullable: false),
                    Occupation = table.Column<string>(maxLength: 50, nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    Gender = table.Column<string>(nullable: false),
                    FirstAppearance = table.Column<int>(nullable: true),
                    PortraitUrl = table.Column<string>(maxLength: 250, nullable: true),
                    BackgroundUrl = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Superheroes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Superheroes_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "SuperheroPowers",
                columns: table => new
                {
                    SuperheroId = table.Column<int>(nullable: false),
                    PowerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperheroPowers", x => new { x.SuperheroId, x.PowerId });
                    table.ForeignKey(
                        name: "FK_SuperheroPowers_Powers_PowerId",
                        column: x => x.PowerId,
                        principalTable: "Powers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SuperheroPowers_Superheroes_SuperheroId",
                        column: x => x.SuperheroId,
                        principalTable: "Superheroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Metropolis" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Gotham City" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Atlantis" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Themyscira" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "New York City" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "Central City" });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 16, "healing factor" });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 17, "heat vision" });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 18, "inexhaustible wealth" });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 19, "instant weaponry" });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 20, "intangibility" });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 23, "magic weaponry" });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 22, "invulnerability" });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 15, "hard light constructs" });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 24, "super speed" });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 25, "super strength" });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 26, "superhuman agility" });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 21, "intelligence" });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 14, "gymnastic ability" });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 11, "flight" });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 12, "force fields" });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 27, "superhuman hearing" });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 10, "exceptional swimming ability" });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 9, "exceptional martial artist" });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 8, "durability" });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 7, "control over sea life" });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "combat strategy" });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "combat skill" });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "brilliant deductive skills" });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "alien technology" });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "advanced technology" });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "ability to breathe underwater" });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 13, "freeze breath" });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 28, "x-ray vision" });

            migrationBuilder.InsertData(
                table: "Superheroes",
                columns: new[] { "Id", "AlterEgo", "BackgroundUrl", "CityId", "FirstAppearance", "Gender", "Name", "Occupation", "PortraitUrl" },
                values: new object[] { 1, "Aquaman", "https://ondfisk.blob.core.windows.net/superheroes/aquaman-background.jpg", 1, 1941, "Male", "Arthur Curry", "King of Atlantis", "https://ondfisk.blob.core.windows.net/superheroes/aquaman-portrait.jpg" });

            migrationBuilder.InsertData(
                table: "Superheroes",
                columns: new[] { "Id", "AlterEgo", "BackgroundUrl", "CityId", "FirstAppearance", "Gender", "Name", "Occupation", "PortraitUrl" },
                values: new object[] { 2, "Superman", "https://ondfisk.blob.core.windows.net/superheroes/superman-background.jpg", 1, 1938, "Male", "Clark Kent", "Reporter", "https://ondfisk.blob.core.windows.net/superheroes/superman-portrait.jpg" });

            migrationBuilder.InsertData(
                table: "Superheroes",
                columns: new[] { "Id", "AlterEgo", "BackgroundUrl", "CityId", "FirstAppearance", "Gender", "Name", "Occupation", "PortraitUrl" },
                values: new object[] { 3, "Batman", "https://ondfisk.blob.core.windows.net/superheroes/batman-background.jpg", 2, 1939, "Male", "Bruce Wayne", "CEO of Wayne Enterprises", "https://ondfisk.blob.core.windows.net/superheroes/batman-portrait.jpg" });

            migrationBuilder.InsertData(
                table: "Superheroes",
                columns: new[] { "Id", "AlterEgo", "BackgroundUrl", "CityId", "FirstAppearance", "Gender", "Name", "Occupation", "PortraitUrl" },
                values: new object[] { 7, "Catwoman", "https://ondfisk.blob.core.windows.net/superheroes/catwoman-background.jpg", 2, 1940, "Female", "Selina Kyle", "Thief", "https://ondfisk.blob.core.windows.net/superheroes/catwoman-portrait.jpg" });

            migrationBuilder.InsertData(
                table: "Superheroes",
                columns: new[] { "Id", "AlterEgo", "BackgroundUrl", "CityId", "FirstAppearance", "Gender", "Name", "Occupation", "PortraitUrl" },
                values: new object[] { 8, "Batwoman", "https://ondfisk.blob.core.windows.net/superheroes/batwoman-background.jpg", 2, 1956, "Female", "Kate Kane", "Thief", "https://ondfisk.blob.core.windows.net/superheroes/batwoman-portrait.jpg" });

            migrationBuilder.InsertData(
                table: "Superheroes",
                columns: new[] { "Id", "AlterEgo", "BackgroundUrl", "CityId", "FirstAppearance", "Gender", "Name", "Occupation", "PortraitUrl" },
                values: new object[] { 4, "Wonder Woman", "https://ondfisk.blob.core.windows.net/superheroes/wonder-woman-background.jpg", 4, 1941, "Female", "Diana", "Amazon Princess", "https://ondfisk.blob.core.windows.net/superheroes/wonder-woman-portrait.jpg" });

            migrationBuilder.InsertData(
                table: "Superheroes",
                columns: new[] { "Id", "AlterEgo", "BackgroundUrl", "CityId", "FirstAppearance", "Gender", "Name", "Occupation", "PortraitUrl" },
                values: new object[] { 5, "Green Lantern", "https://ondfisk.blob.core.windows.net/superheroes/green-lantern-background.jpg", 5, 1940, "Male", "Hal Jordan", "Test pilot", "https://ondfisk.blob.core.windows.net/superheroes/green-lantern-portrait.jpg" });

            migrationBuilder.InsertData(
                table: "Superheroes",
                columns: new[] { "Id", "AlterEgo", "BackgroundUrl", "CityId", "FirstAppearance", "Gender", "Name", "Occupation", "PortraitUrl" },
                values: new object[] { 9, "Supergirl", "https://ondfisk.blob.core.windows.net/superheroes/supergirl-background.jpg", 5, 1959, "Female", "Kara Zor-El", "Actress", "https://ondfisk.blob.core.windows.net/superheroes/supergirl-portrait.jpg" });

            migrationBuilder.InsertData(
                table: "Superheroes",
                columns: new[] { "Id", "AlterEgo", "BackgroundUrl", "CityId", "FirstAppearance", "Gender", "Name", "Occupation", "PortraitUrl" },
                values: new object[] { 6, "The Flash", "https://ondfisk.blob.core.windows.net/superheroes/the-flash-background.jpg", 6, 1940, "Male", "Barry Allen", "Forensic scientist", "https://ondfisk.blob.core.windows.net/superheroes/the-flash-portrait.jpg" });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 1, 25 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 4, 22 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 4, 11 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 4, 5 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 4, 6 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 4, 26 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 4, 16 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 4, 23 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 5, 15 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 5, 19 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 5, 12 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 5, 11 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 5, 8 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 5, 3 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 9, 25 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 9, 11 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 9, 22 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 9, 24 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 9, 17 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 9, 13 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 9, 28 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 9, 27 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 9, 16 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 6, 24 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 4, 25 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 8, 2 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 8, 21 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 8, 4 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 1, 8 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 1, 7 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 1, 10 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 2, 25 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 2, 11 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 2, 22 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 2, 24 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 2, 17 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 2, 13 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 2, 28 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 6, 20 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 2, 27 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 3, 9 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 3, 6 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 3, 18 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 3, 4 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 3, 2 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 7, 9 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 7, 14 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 7, 5 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 8, 9 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 8, 6 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 8, 5 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 2, 16 });

            migrationBuilder.InsertData(
                table: "SuperheroPowers",
                columns: new[] { "SuperheroId", "PowerId" },
                values: new object[] { 6, 26 });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Name",
                table: "Cities",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Powers_Name",
                table: "Powers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Superheroes_CityId",
                table: "Superheroes",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_SuperheroPowers_PowerId",
                table: "SuperheroPowers",
                column: "PowerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SuperheroPowers");

            migrationBuilder.DropTable(
                name: "Powers");

            migrationBuilder.DropTable(
                name: "Superheroes");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
