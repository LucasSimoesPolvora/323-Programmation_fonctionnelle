using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2Marche
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var i18n = new Dictionary<string, string>()
            {
                { "Pommes","Apples"},
                { "Poires","Pears"},
                { "Pastèques","Watermelons"},
                { "Melons","Melons"},
                { "Noix","Nuts"},
                { "Raisin","Grapes"},
                { "Pruneaux","Plums"},
                { "Myrtilles","Blueberries"},
                { "Groseilles","Berries"},
                { "Tomates","Tomatoes"},
                { "Courges","Pumpkins"},
                { "Pêches","Peaches"},
                { "Haricots","Beans"}
            };



            List<Product> products = new List<Product>
            {
                new Product { Location = 11, Producer = "Beaud", ProductName = "Courges", Quantity = 16, Unit = "pièce", PricePerUnit = 8.70 },
                new Product { Location = 11, Producer = "Beaud", ProductName = "Tomates", Quantity = 18, Unit = "kg", PricePerUnit = 5.30 },
                new Product { Location = 11, Producer = "Beaud", ProductName = "Pommes", Quantity = 8, Unit = "kg", PricePerUnit = 7.30 },
                new Product { Location = 11, Producer = "Beaud", ProductName = "Poires", Quantity = 13, Unit = "kg", PricePerUnit = 9.20 },
                new Product { Location = 12, Producer = "Corbaz", ProductName = "Pastèques", Quantity = 15, Unit = "pièce", PricePerUnit = 7.40 },
                new Product { Location = 12, Producer = "Corbaz", ProductName = "Melons", Quantity = 12, Unit = "kg", PricePerUnit = 1.60 },
                new Product { Location = 12, Producer = "Corbaz", ProductName = "Noix", Quantity = 11, Unit = "sac", PricePerUnit = 7.50 },
                new Product { Location = 12, Producer = "Corbaz", ProductName = "Raisin", Quantity = 16, Unit = "kg", PricePerUnit = 4.50 },
                new Product { Location = 12, Producer = "Corbaz", ProductName = "Pruneaux", Quantity = 20, Unit = "kg", PricePerUnit = 3.30 },
                new Product { Location = 13, Producer = "Amaudruz", ProductName = "Myrtilles", Quantity = 18, Unit = "kg", PricePerUnit = 5.70 },
                new Product { Location = 13, Producer = "Amaudruz", ProductName = "Groseilles", Quantity = 19, Unit = "kg", PricePerUnit = 8.00 },
                new Product { Location = 13, Producer = "Amaudruz", ProductName = "Pêches", Quantity = 12, Unit = "kg", PricePerUnit = 5.50 },
                new Product { Location = 13, Producer = "Amaudruz", ProductName = "Haricots", Quantity = 13, Unit = "kg", PricePerUnit = 5.20 },
                new Product { Location = 13, Producer = "Amaudruz", ProductName = "Courges", Quantity = 7, Unit = "pièce", PricePerUnit = 9.60 },
                new Product { Location = 14, Producer = "Bühlmann", ProductName = "Tomates", Quantity = 12, Unit = "kg", PricePerUnit = 7.70 },
                new Product { Location = 14, Producer = "Bühlmann", ProductName = "Pommes", Quantity = 17, Unit = "kg", PricePerUnit = 1.90 },
                new Product { Location = 14, Producer = "Bühlmann", ProductName = "Poires", Quantity = 7, Unit = "kg", PricePerUnit = 3.00 },
                new Product { Location = 14, Producer = "Bühlmann", ProductName = "Pastèques", Quantity = 11, Unit = "pièce", PricePerUnit = 6.90 },
                new Product { Location = 14, Producer = "Bühlmann", ProductName = "Melons", Quantity = 7, Unit = "kg", PricePerUnit = 4.70 },
                new Product { Location = 15, Producer = "Crizzi", ProductName = "Noix", Quantity = 10, Unit = "sac", PricePerUnit = 1.60 },
                new Product { Location = 15, Producer = "Crizzi", ProductName = "Raisin", Quantity = 17, Unit = "kg", PricePerUnit = 7.80 },
                new Product { Location = 15, Producer = "Crizzi", ProductName = "Pruneaux", Quantity = 18, Unit = "kg", PricePerUnit = 9.00 },
                new Product { Location = 15, Producer = "Crizzi", ProductName = "Myrtilles", Quantity = 12, Unit = "kg", PricePerUnit = 3.00 },
                new Product { Location = 15, Producer = "Crizzi", ProductName = "Groseilles", Quantity = 12, Unit = "kg", PricePerUnit = 3.50 },
            };

            var ca = products.Select(p => (producer: p.Producer.Substring(0, 3) + "..." + p.Producer.Last(), productName: i18n[p.ProductName], ca: p.Quantity * p.PricePerUnit)).ToList();
            List<string> csv = new List<string>();
            ca.ForEach(x =>
            {
                string result = x.producer + " | " + x.productName + " | " + x.ca;
                csv.Add(result);
            });

            string filePath = "data.csv"; 
            using (StreamWriter writer = new StreamWriter(filePath)) 
            {
                csv.ForEach(x => writer.WriteLine(x));
            }

            int reduce1 = products.Where(p => p.ProductName == "Groseilles").Sum(p=> p.Quantity);
            Console.WriteLine($"Nombre de groseilles: {reduce1}");

            var reduce2 = products.GroupBy(
                product => product.Producer,
                product => product.Quantity * product.PricePerUnit,
                (key, pro) => new
                {
                    producer = key,
                    ca = pro.Sum()
                }).ToList();

            reduce2.ForEach(x => Console.WriteLine(x.producer + " | " + x.ca));
        }
    }

    public class Product
    {
        public int Location { get; set; }
        public string Producer { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public double PricePerUnit { get; set; }
    }
}
