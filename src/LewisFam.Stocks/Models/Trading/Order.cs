using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using LewisFam.Stocks.Models.Enums;
using LewisFam.Stocks.ThirdParty.Webull.Models;

namespace LewisFam.Stocks.Models.Trading
{
    public class DemoOrderCreator
    {
        public void NewOrder(Stock stock)
        {
            var order = new OptionOrder(stock);
            
        }
    }

    public enum Operation
    {
       Add,
       Update,
       Remove,
       Insert,
       Delete,       
       Replace,
    }

    public class OptionOrder
    {
        public OptionOrder(Stock stock)
        {
            Stock = stock;
            OrderItems = new HashSet<OrderItem>();
        }
        
        [Key]
        public int OrderId { get; set; }
        
        public Stock Stock { get; }

        public ICollection<OrderItem> OrderItems { get; }



        public void ManageOrderItem(Operation operation, OrderItem orderItem)
        {
            switch (operation)
            {
                case Operation.Add:
                    break;
                case Operation.Update:
                    break;
                case Operation.Remove:
                    break;
                case Operation.Insert:
                    break;
                case Operation.Delete:
                    break;
                case Operation.Replace:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(operation), operation, null);
            }
            OrderItems.Add(orderItem);
        }

        
    }

    public class OrderItem
    {
        [Key]
        public Guid OrderItemId { get; set; }
        public int Contracts { get; set; }
        public BuySell BuySell { get; set; }
        public IWebullOptionQuote Option { get; set; }

        public double OpenPrice { get; set; }
        public DateTimeOffset DateTimeOpened { get; set; }
        
        public double ClosePrice { get; set; }
        public DateTimeOffset DateTimeClosed { get; set; }
    }
}
