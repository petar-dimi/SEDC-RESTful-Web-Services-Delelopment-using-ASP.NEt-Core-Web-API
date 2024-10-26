namespace WebApplication1.Models
{
    public static class StaticDb
    {
        public static List<Beverage> Beverages { get; } = new List<Beverage>
        {
            new Beverage { Id = 1, Name = "Whiskey", Type = "Alcohol", QuantityInStock = 10, Price = 25.99M },
            new Beverage { Id = 2, Name = "Coca-Cola", Type = "Soft drink", QuantityInStock = 50, Price = 1.99M },
            new Beverage { Id = 3, Name = "Budweiser", Type = "Beer", QuantityInStock = 20, Price = 12.99M },
            new Beverage { Id = 4, Name = "Orange Juice", Type = "Soft drink", QuantityInStock = 30, Price = 3.49M }
        };

        public static List<User> Users { get; } = new List<User>();
    }
}
