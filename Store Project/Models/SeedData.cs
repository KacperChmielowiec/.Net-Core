namespace Store.Models
{
    public static class SeedData
    {
        static StoreDbContext context;

        public static void StorePopulateData(this IApplicationBuilder app)
        {
            
            
            context = app.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<StoreDbContext>();

            if (context.Database.GetPendingMigrations().Any()) context.Database.Migrate();
            if (!context.products.Any())
            {
                context.products.AddRange(
                     new Product
                     {
                         Name = "Black/Energy Drink",
                         Description = "The best food for you, buy and try !",
                         Category = "DrinkSugar",
                         Price = 5,
                         ImgProduct = ImgToBinaryData.FileToByteArray(@"img\black.jpg")
                     },
                     new Product
                     {
                         Name = "Water 2l",
                         Description = "The best food for you, buy and try !",
                         Category = "NoSugarDrink",
                         Price = 3,
                         ImgProduct = ImgToBinaryData.FileToByteArray(@"img\woda.jpg")
                     },
                     new Product
                     {
                         Name = "Lays",
                         Description = "The best food for you, buy and try !",
                         Category = "Snaks",
                         Price = 4.5M,
                         ImgProduct = ImgToBinaryData.FileToByteArray(@"img\lays.jpg")
                     },
                     new Product
                     {
                         Name = "7-UP",
                         Description = "The best food for you, buy and try !",
                         Category = "DrinkSugar",
                         Price = 3.33M,
                         ImgProduct = ImgToBinaryData.FileToByteArray(@"img\7up.jpg")
                     },
                     new Product
                     {
                         Name = "7-Days",
                         Description = "The best food for you, buy and try !",
                         Category = "Candy",
                         Price = 5,
                         ImgProduct = ImgToBinaryData.FileToByteArray(@"img\7days.jpg")
                     },
                      new Product
                      {
                          Name = "Coffe",
                          Description = "The best food for you, buy and try !",
                          Category = "NoSugarDrink",
                          Price = 12,
                          ImgProduct = ImgToBinaryData.FileToByteArray(@"img\coffe.jpg")
                      },
                     new Product
                     {
                         Name = "frozen fries",
                         Description = "The best food for you, buy and try !",
                         Category = "Snaks",
                         Price = 7,
                         ImgProduct = ImgToBinaryData.FileToByteArray(@"img\frytki.jpg"),

                     },
                     new Product
                     {
                         Name = "Kit-Kat",
                         Description = "The best food for you, buy and try !",
                         Category = "Candy",
                         Price = 2,
                         ImgProduct = ImgToBinaryData.FileToByteArray(@"img\kitkat.jpg")
                     },
                     new Product
                     {
                         Name = "Milk Chocolate",
                         Description = "The best food for you, buy and try !",
                         Category = "Candy",
                         Price = 6,
                         ImgProduct = ImgToBinaryData.FileToByteArray(@"img\milka.jpg")
                     },
                     new Product
                     {
                         Name = "Cheetos",
                         Description = "The best food for you, buy and try !",
                         Category = "Snaks",
                         Price = 3.5M,
                         ImgProduct = ImgToBinaryData.FileToByteArray(@"img\black.jpg")
                     }


                    ) ;
                context.SaveChanges();
            }
        }
    }
}
