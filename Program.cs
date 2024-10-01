using System.Text.Encodings.Web;
using System.Text.Json;
using Westcoast_EShop.Models;

namespace Westcoast_EShop;

public class Program
{
  static void Main()
  {
    var orders = new List<SalesOrder>();
    // Beställning 1...
    var order = new SalesOrder();

    order.OrderDate = DateTime.Now;
    order.OrderId = 1;
    order.Customer = new Customer
    {
      CustomerId = 100,
      CreatedAt = DateTime.Now,
      LastBuy = DateTime.Now,
      FirstName = "Anneli",
      LastName = "Oskarsson",
      AddressLine = "Storgatan 8",
      PostalCode = "123 45",
      City = "Storstaden"
    };

    // Skapa orderrad 1...
    var orderItem = new OrderItem();
    var product = new Product();
    product.ItemNumber = "1-5679X";
    product.ProductId = 1;
    product.Name = "Sliptrissor";
    product.Price = 40;

    orderItem.Discount = (decimal)0.10;
    orderItem.Quantity = 10;
    orderItem.Product = product;
    orderItem.LineSum = orderItem.Quantity * (orderItem.Product.Price - (orderItem.Discount * orderItem.Product.Price));

    // Lägg till orderraden till SalesOrder OrderItems...
    order.OrderItems = new List<OrderItem>();
    order.OrderItems.Add(orderItem);

    // Skapa orderrad 2...
    orderItem = new OrderItem();
    product = new Product();
    product.ItemNumber = "1-5665X";
    product.ProductId = 2;
    product.Name = "Slipmaskin";
    product.Price = 3995;

    orderItem.Discount = (decimal)0.20;
    orderItem.Quantity = 1;
    orderItem.Product = product;
    orderItem.LineSum = orderItem.Quantity * (orderItem.Product.Price - (orderItem.Discount * orderItem.Product.Price));

    // Lägg till orderraden till SalesOrder OrderItems...
    order.OrderItems.Add(orderItem);

    // Lägg till beställning till listan av beställning
    // orders = List<SalesOrder>
    orders.Add(order);

    // Beställning 2...
    order = new SalesOrder();

    order.OrderDate = DateTime.Now;
    order.OrderId = 2;
    order.Customer = new Customer
    {
      CustomerId = 100,
      CreatedAt = DateTime.Now,
      LastBuy = DateTime.Now,
      FirstName = "Annika",
      LastName = "Eriksson",
      AddressLine = "Vikenvägen 1",
      PostalCode = "123 45",
      City = "Lillstaden"
    };

    // Skapa orderrad 1...
    orderItem = new OrderItem();
    product = new Product();
    product.ItemNumber = "1-5645X";
    product.ProductId = 3;
    product.Name = "Diskborstar";
    product.Price = 2;

    orderItem.Discount = (decimal)0.15;
    orderItem.Quantity = 100;
    orderItem.Product = product;
    orderItem.LineSum = orderItem.Quantity * (orderItem.Product.Price - (orderItem.Discount * orderItem.Product.Price));

    // Lägg till orderraden till SalesOrder OrderItems...
    order.OrderItems = new List<OrderItem>();
    order.OrderItems.Add(orderItem);

    // Skapa orderrad 2...
    orderItem = new OrderItem();
    product = new Product();
    product.ItemNumber = "1-561115X";
    product.ProductId = 4;
    product.Name = "Stålull";
    product.Price = 12.50M;

    orderItem.Discount = (decimal)0.25;
    orderItem.Quantity = 200;
    orderItem.Product = product;
    orderItem.LineSum = orderItem.Quantity * (orderItem.Product.Price - (orderItem.Discount * orderItem.Product.Price));

    // Lägg till orderraden till SalesOrder OrderItems...
    order.OrderItems.Add(orderItem);

    orders.Add(order);

    /* HÄR SKRIVER VI NER ALLT TILL ETT JSON DOKUMENT */
    var options = new JsonSerializerOptions
    {
      PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
      Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
      WriteIndented = true
    };
    var json = JsonSerializer.Serialize(orders, options);

    var path = string.Concat(Environment.CurrentDirectory, "/Data/orders.json");
    File.WriteAllText(path, json);
  }
}