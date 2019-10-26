using Microsoft.EntityFrameworkCore.Migrations;

namespace PierresSassyStore.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Flavors",
                columns: new[] { "FlavorId", "AvailableSeason", "Description", "Image_url", "IsAvailable", "IsSeasonal", "Name" },
                values: new object[,]
                {
                    { 1, null, "Has warm, floral notes", "https://www.wholesalesuppliesplus.com/Images/Products/647-Vanilla-Bean-Fragrance-Oil-240.jpg", false, false, "Vanilla" },
                    { 2, null, "Nice crispy texture with a savory, smokey taste", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQOHpEVqdeHn3khXoSmAylqR5Z_iHR9VV4d9SWtIYNbrfJprsmJzQ&s", false, false, "Bacon" },
                    { 3, null, "Rich silky smoothness", "https://cdn11.bigcommerce.com/s-ham8sjk/images/stencil/1280x1280/products/276/836/Cacao_Chocolate_Chocolate_Liquor__1551729718_104.172.159.225__96045.1551729753.jpg?c=2&imbypass=on", false, false, "Chocolate" },
                    { 4, null, "Crisp and sweet", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRaDJTRef4PzpZpiYnwZqGROIFGM1tRFwcFo6Qsz74k7MpeAlAhYw&s", false, false, "Apple" }
                });

            migrationBuilder.InsertData(
                table: "Treats",
                columns: new[] { "TreatId", "Description", "Image_url", "Name" },
                values: new object[,]
                {
                    { 1, "A decadent, creamy cake", "https://bakerbynature.com/wp-content/uploads/2018/05/extrathickandcreamycheesecake1234-1-of-1.jpg", "Cheesecake" },
                    { 2, "A tasty twist", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRAs9QjjltUw8XL4LO91DATFsNxnYh0_JA4KzOj0io3uOnTxiV9&s", "Pretzel" },
                    { 3, "Yummy goodness", "https://www.modernhoney.com/wp-content/uploads/2019/10/Double-Chocolate-Cookies-1.jpg", "Cookie" },
                    { 4, "Flaky deliciousness", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTcEhSt27f_MhJuD2c4Csjvs7d8iZFiMvOXDvowt76AmpzIDPvC2Q&s", "Tart" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Flavors",
                keyColumn: "FlavorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flavors",
                keyColumn: "FlavorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Flavors",
                keyColumn: "FlavorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Flavors",
                keyColumn: "FlavorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Treats",
                keyColumn: "TreatId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Treats",
                keyColumn: "TreatId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Treats",
                keyColumn: "TreatId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Treats",
                keyColumn: "TreatId",
                keyValue: 4);
        }
    }
}
