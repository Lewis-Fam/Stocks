using System.ComponentModel.DataAnnotations;
using LewisFam.Stocks.Models;

namespace LewisFam.Stocks.ThirdParty.Robinhood
{
    public interface IStockHolding : IStock
    {
        string Name { get; }
        string Symbol { get; }

        [DisplayFormat(DataFormatString = "0.000")]
        double Shares { get; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        double AverageCost { get; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        double Price { get; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        double TotalReturn { get; }
        
        [Display(Name = "TotalReturn%"), DisplayFormat(DataFormatString = "P")]
        double TotalReturnPercentage { get; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        double Equity { get; }
    }
}