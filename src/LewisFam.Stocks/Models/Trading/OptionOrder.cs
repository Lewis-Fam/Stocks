using System;
using System.Collections.Generic;
using System.Linq;
using LewisFam.Models;

namespace LewisFam.Stocks.Models.Trading
{
    public class OptionOrder : BindableObject
    {
        public OptionOrder(Stock stock)
        {
            Stock = stock;
            OrderItems = new HashSet<OrderItem>();
        }
        
        //[Key]
        public int OrderId { get; set; }
        
        public Stock Stock { get; }

        public ICollection<OrderItem> OrderItems { get; }

        public OrderItem ItemExsists(Guid id)
        {
            return OrderItems.First(i => i.Id == id);
        }

        public void ManageOrderItem(OperationType operation, OrderItem orderItem, Guid? id = null)
        {
            
            if (id != null)
            {
                var i = ItemExsists(id.Value);

                switch (operation)
                {
                    case OperationType.Add:
                    case OperationType.Insert:
                        if (i == null)
                            OrderItems.Add(orderItem);
                        break;
                    case OperationType.Update:
                    case OperationType.Replace:
                        if (i != null)
                        {
                            OrderItems.Remove(i);
                            OrderItems.Add(orderItem);
                        }
                        break;
                    case OperationType.Delete:
                    case OperationType.Remove:
                        if (i != null) 
                            OrderItems.Remove(i);
                        break;
                    case OperationType.Select:
                        throw new NotImplementedException($"{nameof(operation)} 'Select' is not implemented");
                    default:
                        throw new ArgumentOutOfRangeException(nameof(operation), operation, null);
                }
            }
        }
    }
}