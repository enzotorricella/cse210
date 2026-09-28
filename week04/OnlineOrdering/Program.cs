using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Address domesticAddress = new Address("125 River Street", "Boise", "Idaho", "USA");
        Customer domesticCustomer = new Customer("Emily Johnson", domesticAddress);
        List<Product> domesticProducts = new List<Product>
        {
            new Product("Waterproof Backpack", "WB-104", 54.99m, 1),
            new Product("Insulated Water Bottle", "BW-220", 18.50m, 2),
            new Product("Dry Bag", "DB-315", 24.75m, 1)
        };
        Order domesticOrder = new Order(domesticProducts, domesticCustomer);

        Address internationalAddress = new Address(
            "Avenida del Libertador 1420", "Rosario", "Santa Fe", "Argentina");
        Customer internationalCustomer = new Customer("Santiago Perez", internationalAddress);
        List<Product> internationalProducts = new List<Product>
        {
            new Product("Climbing Helmet", "CH-410", 72.00m, 1),
            new Product("Safety Carabiner", "SC-118", 12.25m, 3)
        };
        Order internationalOrder = new Order(internationalProducts, internationalCustomer);

        List<Order> orders = new List<Order> { domesticOrder, internationalOrder };

        for (int i = 0; i < orders.Count; i++)
        {
            Console.WriteLine($"ORDER {i + 1}");
            Console.WriteLine("Packing Label:");
            Console.WriteLine(orders[i].GetPackingLabel());
            Console.WriteLine();
            Console.WriteLine("Shipping Label:");
            Console.WriteLine(orders[i].GetShippingLabel());
            Console.WriteLine();
            string total = orders[i].CalculateTotalCost().ToString("0.00", CultureInfo.InvariantCulture);
            Console.WriteLine($"Total Price: ${total}");
            Console.WriteLine(new string('-', 60));
        }
    }
}
