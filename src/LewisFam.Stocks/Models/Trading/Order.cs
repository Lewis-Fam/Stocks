using System.ComponentModel.DataAnnotations;

namespace LewisFam.Stocks.Models.Trading
{
    public class DemoOrderCreator
    {
        public void NewOrder(Stock stock)
        {
            var order = new OptionOrder(stock);
            
        }
    }

    public enum OperationType
    {
        Select,
        Add,
        Insert,
        Update,
        Replace,
        Delete,
        Remove,
        Save,
    }

}
