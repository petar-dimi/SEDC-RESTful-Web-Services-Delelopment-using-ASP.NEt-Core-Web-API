namespace Homework_02.Models
{
    public static class StaticDb
    {
        public static List<Beverage> Beverages { get; } = new List<Beverage>
        {
            new Beverage { Brand = "Coca-Cola", Type = "Soda" },
            new Beverage { Brand = "Pepsi", Type = "Soda" },
            new Beverage { Brand = "Orange Juice", Type = "Juice" },
            new Beverage { Brand = "Water", Type = "Water" }
        };
    }
}
