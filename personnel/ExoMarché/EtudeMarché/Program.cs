using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace EtudeMarché
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/Place du marché.xlsx";

            List<Product> products = new List<Product>();
            string[] values = new string[6];

            Application excel = new Application();

            Workbook wb;
            Worksheet ws;
            bool hasData = true;

            wb = excel.Workbooks.Open(filePath);
            ws = wb.Worksheets[2];

            for (int i = 2; true; i++)
            {
                for (int j = 1; j < 7; j++)
                {
                    Range cells = ws.Cells[i, j];
                    if (cells.Value == null)
                    {
                        hasData = false;
                        break;
                    }
                    values[j-1] = cells.Value.ToString();
                }
                if (!hasData)
                {
                    break;
                }
                Int32.TryParse(values[0], out int number);
                Int32.TryParse(values[3], out int number2);
                float.TryParse(values[5], out float number3);

                Product product = new Product
                {
                    id = i-1,
                    stand=number,
                    producteur = values[1],
                    produit = values[2],
                    quantite = number2,
                    unite = values[4],
                    prixUnite = number3
                };

                
                products.Add(product);               
            }

            // 1er étape
            /*int nbr = 0;
            foreach (Product product in products)
            {
                if(product.produit == "Pêches")
                {
                    nbr++;
                }
            }*/

            //linq
            int nbr = (from p in products
                       where p.produit == "Pêches"
                       select p).Count();

            
            // int nbr = products.Count(x => x.produit == "Pêches");
            Console.WriteLine($"Il y a {nbr} vendeur de pêches");


            // 2ème étape

            //linq
            IEnumerable < Product > list = from p in products
                                           where p.produit == "Pastèques"
                                           select p;
            int maxQuantity = list.Max(x => x.quantite);

            Product answer = (from p in list
                              where p.quantite == maxQuantity
                              select p).First();

            // Get the max quantity of watermelon
            /*int maxQuantity = products
                .Where(x => x.produit == "Pastèques")
                .Max(x => x.quantite);

            // Get the whole producer
            List<Product> maxProducer = products
                .Where(x => x.produit == "Pastèques" && x.quantite == maxQuantity).ToList();

            Product answer = maxProducer[0];*/


            Console.WriteLine($"C'est {answer.producteur} qui a le plus de pastèques (Stand {answer.stand}, {answer.quantite} pièces)");


            // Challenge
            /*IEnumerable<String> producteursPas = from p in products
                                        where p.produit == "Pastèques"
                                        select p.producteur;

            IEnumerable<Product> producteurPasMel = from p in producteursPas
                                                    join o in products on
                                                    p equals o.producteur
                                                    where o.produit == "Melon"
                                                    select o;*/

            Console.ReadKey();
        }

        public class Product
        {
            public int id {  get; set; }
            public int stand {  get; set; }
            public string producteur { get; set; }
            public string produit { get; set; }
            public int quantite {  get; set; }
            public string unite {  get; set; }
            public float prixUnite {  get; set; }
        }
    }
}
