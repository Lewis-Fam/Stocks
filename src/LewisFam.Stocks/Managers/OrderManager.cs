using System.Collections.ObjectModel;
using LewisFam.Models;

namespace LewisFam.Stocks.Managers
{
    public sealed class OrderManager<TOrderItems> : BindableObject
    {
        public OrderManager()
        {
            OrderItems = new ObservableCollection<TOrderItems>();
        }

        public int OrderId { get; set; } 
        
        private ObservableCollection<TOrderItems> _items;
        
        public ObservableCollection<TOrderItems> OrderItems
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }
    }
}