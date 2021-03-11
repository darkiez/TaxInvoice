using System;
using System.Collections;
using System.Collections.Generic;

class Program : CalculatesInvoice
{
    static void Main(string[] args)
    {
        List<Product> products = new List<Product>();

        products.Add(new Product { name = "Books", amount = 12.49, quantity = 1, isTaxEmempt = true, isImported = false });
        products.Add(new Product { name = "Music CD", amount = 14.99, quantity = 1, isTaxEmempt = false, isImported = false });
        products.Add(new Product { name = "Chocolate bar", amount = 0.85, quantity = 1, isTaxEmempt = true, isImported = false });
        products.Add(new Product { name = "Imported box of chocolates", amount = 10.00, quantity = 1, isTaxEmempt = true, isImported = true });
        products.Add(new Product { name = "Imported bottle of perfume", amount = 47.50, quantity = 1, isTaxEmempt = false, isImported = true });
        products.Add(new Product { name = "Imported bottle of perfume", amount = 27.99, quantity = 1, isTaxEmempt = false, isImported = true });
        products.Add(new Product { name = "Bottle of perfume", amount = 18.99, quantity = 1, isTaxEmempt = false, isImported = false });
        products.Add(new Product { name = "Packet of paracetamol", amount = 9.75, quantity = 1, isTaxEmempt = true, isImported = false });
        products.Add(new Product { name = "Imported box of chocolates", amount = 11.25, quantity = 1, isTaxEmempt = false, isImported = true });

        CalculatesInvoice p = new CalculatesInvoice();
        p.CalculateInvoice(products, 1);
        p.CalculateInvoice(products, 2);

        Console.ReadLine();
    }
}

internal class CalculatesInvoice
{
    public class Product
    {
        public string name { get; set; }
        public double amount { get; set; }
        public int quantity { get; set; }
        public bool isTaxEmempt { get; set; }
        public bool isImported { get; set; }
    }

    public void CalculateInvoice(List<Product> product, int outPutNumber)
    {
        double taxes = 0.0;
        double total = 0.0;

        Console.WriteLine("Output: " + outPutNumber);

        // Product call = new Product();

        foreach (var item in product)
        {
            Product call = item;

            var TotalPriceForItem = call.amount * call.quantity;
            total = total + TotalPriceForItem;

            var ProductTax = 0.0;

            if (!call.isTaxEmempt)
            {
                ProductTax = (0.1 * TotalPriceForItem);
            }
            if (call.isImported)
            {
                ProductTax = ProductTax + (0.05 * TotalPriceForItem);
            }

            taxes = taxes + ProductTax;
            call.amount = call.amount + ProductTax;

            Console.WriteLine(call.quantity + " --- " + call.name + " : " + call.amount);
            //Console.ReadLine();
        }

        Console.WriteLine("\n" + "Sales taxes : " + taxes);
        Console.WriteLine("Total : " + total + taxes);
    }
}