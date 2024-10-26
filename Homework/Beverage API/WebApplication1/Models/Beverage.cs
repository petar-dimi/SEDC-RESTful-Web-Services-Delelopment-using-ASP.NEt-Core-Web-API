namespace WebApplication1.Models
{
    
        public class Beverage
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Type { get; set; } // Alcohol, Soft drink, Beer
            public int QuantityInStock { get; set; }
            public decimal Price { get; set; }
        }
   
}
