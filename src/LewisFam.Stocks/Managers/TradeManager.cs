using System.Collections.ObjectModel;
using LewisFam.Models;

namespace LewisFam.Stocks.Managers
{

    public class TradeManager<TTradeItems> : BindableObject
    {
        public TradeManager()
        {
            TradeItems = new ObservableCollection<TTradeItems>();
        }

        public object TradeId { get; set; } 
        
        private ObservableCollection<TTradeItems> _items;
        public ObservableCollection<TTradeItems> TradeItems
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

    }
}
