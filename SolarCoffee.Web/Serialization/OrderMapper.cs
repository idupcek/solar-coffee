﻿using SolarCoffee.Data.Models;
using SolarCoffee.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCoffee.Web.Serialization
{
    /// <summary>
    /// Handles mapping ORder data models to and from related View Models
    /// </summary>
    public static class OrderMapper
    {
        /// <summary>
        /// Map an InvoiceModel view model to a salesOrder
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public static SalesOrder SerializeInvoiceToOrder(InvoiceModel invoice)
        {
            var salesOrderItems = invoice.LineItems
                .Select(item => new SalesOrderItem
                {
                    Id = item.Id,
                    Quantity = item.Quantity,
                    Product = ProductMapper.SerializeProductModel(item.Product),

                }).ToList();

            return new SalesOrder
            {
                SalesOrderItems = salesOrderItems, 
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,


            };
        }

        /// <summary>
        /// Maps a colelction of SalesOrders (data) to OrderModels(view models)
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        public static List<OrderModel> SerializeOrdersToViewModels(IEnumerable<SalesOrder> orders)
        {
            return orders.Select(order => new OrderModel
            {
                Id = order.Id, 
                CreatedOn = order.CreatedOn, 
                UpdatedOn = order.UpdatedOn, 
                SalesOrderItems = SerializeSalesOrderItems(order.SalesOrderItems),
                Customer = CustomerMapper.SerializeCustomer(order.Customer), 
                IsPaid = order.IsPaid
                
            }).ToList();
        }

        /// <summary>
        /// Maps a collection of SalesOrderItems (data) to SalesOrderItemModels (view model)
        /// </summary>
        /// <param name="orderItems"></param>D:\VisualStudio Projects\Udemy\Wes Doyle - Fullstack\SolarCoffee\SolarCoffee.Web\Serialization\OrderMapper.cs
        /// <returns></returns>
        private static List<SalesOrderItemModel> SerializeSalesOrderItems(IEnumerable<SalesOrderItem> orderItems)
        {
            return orderItems.Select(item => new SalesOrderItemModel
            {
                Id = item.Id, 
                Quantity = item.Quantity, 
                Product = ProductMapper.SerializeProductModel(item.Product),

            }).ToList();
        }
    }
}
