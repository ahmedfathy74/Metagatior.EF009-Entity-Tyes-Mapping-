using EF006.UsingDependencyInjection.Data;
using EF009.BasicSetup.Entities;
using Microsoft.EntityFrameworkCore;

var context = new AppDbcontext();

//foreach (var item in context.Products)
//{
//    Console.WriteLine(item.Name);
//}

// retreive data from entity

//var ItemInOrder1 = context.OrderDetails.Where(x => x.OrderId == 1);

// retrieve data from entity not mapped in source code but i retrieve data by using related entity (Eager Loading)

//var orderDetails = context
//    .Orders
//    .Include(x => x.OrderDetails)
//    .FirstOrDefault(x => x.Id ==1).OrderDetails;

//Console.WriteLine($"Items Count In Order 1 = {orderDetails.Count()}");

// Retreive Data from View

//foreach (var item in context.OrderWithDetail)
//{
//    Console.WriteLine(item);
//}

// retreive Data from function her returned type is Table Value
// 

var order1BillDetails = new AppDbcontext().Set<OrderBill>().FromSqlInterpolated($"SELECT * FROM GetOrderBill({1})").ToList();

foreach (var Item in order1BillDetails)
{
    Console.WriteLine(Item);
}