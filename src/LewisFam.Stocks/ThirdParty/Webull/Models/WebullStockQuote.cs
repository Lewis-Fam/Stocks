using System;
using LewisFam.Stocks.Models;

namespace LewisFam.Stocks.ThirdParty.Webull.Models
{
    /// <summary>
    /// The webull stock quote.
    /// </summary>
    public class WebullStockQuote : StockQuote, IRealTimeStockQuote
    {
        private long _tickerId;
        private int _exchangeId;
        private int _type;
        private int[] _secType;
        private int _regionId;
        private string _regionCode;
        private int _currencyId;
        private string _name;
        private string _symbol;
        private string _disSymbol;
        private string _disExchangeCode;
        private string _exchangeCode;
        private int _listStatus;
        private string _template;
        private int _derivativeSupport;
        private DateTime _tradeTime;
        private string _status;
        private double _close;
        private double _change;
        private double _changeRatio;
        private double _pPrice;
        private double _pChange;
        private double _pChRatio;
        private double _marketValue;
        private long _volume;
        private double _turnoverRate;
        private string _timeZone;
        private string _tzName;
        private double _preClose;
        private double _open;
        private double _high;
        private double _low;
        private double _vibrateRatio;
        private long _avgVol10D;
        private long _avgVol3M;
        private double _negMarketValue;
        private double _pe;
        private double _forwardPe;
        private double _indicatedPe;
        private double _peTtm;
        private double _eps;
        private double _epsTtm;
        private double _pb;
        private long _totalShares;
        private long _outstandingShares;
        private double _fiftyTwoWkHigh;
        private double _fiftyTwoWkLow;
        private double _yield;
        private string _currencyCode;
        private int _lotSize;
        private string _latestEarningsDate;
        private double _ps;
        private double _bps;
        private string _estimateEarningsDate;
        private string _tradeStatus;
        private string _limitUp;
        private string _limitDown;

        public WebullStockQuote()
        {
        }

        public WebullStockQuote(string symbol)
        {
            Symbol = symbol;
        }

        public WebullStockQuote(string symbol, double high, double low, double open, double price)
        {
            Symbol = symbol;
            High = high;
            Low = low;
            Open = open;
            Price = price;
        }

        public long TickerId
        {
            get => _tickerId;
            set => SetProperty(ref _tickerId, value);
        }

        public int ExchangeId
        {
            get => _exchangeId;
            set => SetProperty(ref  _exchangeId, value);
        }

        public int Type
        {
            get => _type;
            set => SetProperty(ref _type, value);
        }

        public int[] SecType
        {
            get => _secType;
            set => SetProperty(ref _secType, value);
        }

        public int RegionId
        {
            get => _regionId;
            set => SetProperty(ref _regionId, value);
        }

        public string RegionCode
        {
            get => _regionCode;
            set => SetProperty(ref _regionCode, value);
        }

        public int CurrencyId
        {
            get => _currencyId;
            set => SetProperty(ref _currencyId, value);
        }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public sealed override string Symbol
        {
            get => _symbol;
            set => SetProperty(ref _symbol, value);
        }

        public string DisSymbol
        {
            get => _disSymbol;
            set => SetProperty(ref _disSymbol, value);
        }

        public string DisExchangeCode
        {
            get => _disExchangeCode;
            set => SetProperty(ref _disExchangeCode, value);
        }

        public string ExchangeCode
        {
            get => _exchangeCode;
            set => SetProperty(ref _exchangeCode, value);
        }

        public int ListStatus
        {
            get => _listStatus;
            set => SetProperty(ref _listStatus, value);
        }

        public string Template
        {
            get => _template;
            set => SetProperty(ref _template, value);
        }

        public int DerivativeSupport
        {
            get => _derivativeSupport;
            set => SetProperty(ref _derivativeSupport, value);
        }

        public DateTime TradeTime
        {
            get => _tradeTime;
            set => SetProperty(ref _tradeTime, value);
        }

        public string Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }

        public double Close
        {
            get => _close;
            set => SetProperty(ref _close, value);
        }

        public double Change
        {
            get => _change;
            set => SetProperty(ref _change, value);
        }

        public double ChangeRatio
        {
            get => _changeRatio;
            set => SetProperty(ref _changeRatio, value);
        }

        public double PPrice
        {
            get => _pPrice;
            set => SetProperty(ref _pPrice, value);
        }

        public double PChange
        {
            get => _pChange;
            set => SetProperty(ref _pChange, value);
        }

        public double PChRatio
        {
            get => _pChRatio;
            set => SetProperty(ref _pChRatio, value);
        }

        public double MarketValue
        {
            get => _marketValue;
            set => SetProperty(ref _marketValue, value);
        }

        public long Volume
        {
            get => _volume;
            set => SetProperty(ref _volume, value);
        }

        public double TurnoverRate
        {
            get => _turnoverRate;
            set => SetProperty(ref _turnoverRate, value);
        }

        public string TimeZone
        {
            get => _timeZone;
            set => SetProperty(ref _timeZone, value);
        }

        public string TzName
        {
            get => _tzName;
            set => SetProperty(ref _tzName, value);
        }

        public double PreClose
        {
            get => _preClose;
            set => SetProperty(ref _preClose, value);
        }

        public double Open
        {
            get => _open;
            set => SetProperty(ref _open, value);
        }

        public double High
        {
            get => _high;
            set => SetProperty(ref _high, value);
        }

        public double Low
        {
            get => _low;
            set => SetProperty(ref _low, value);
        }

        public double VibrateRatio
        {
            get => _vibrateRatio;
            set => SetProperty(ref _vibrateRatio, value);
        }

        public long AvgVol10D
        {
            get => _avgVol10D;
            set => SetProperty(ref _avgVol10D, value);
        }

        public long AvgVol3M
        {
            get => _avgVol3M;
            set => SetProperty(ref _avgVol3M, value);
        }

        public double NegMarketValue
        {
            get => _negMarketValue;
            set => SetProperty(ref _negMarketValue, value);
        }

        public double Pe
        {
            get => _pe;
            set => SetProperty(ref _pe, value);
        }

        public double ForwardPe
        {
            get => _forwardPe;
            set => SetProperty(ref _forwardPe, value);
        }

        public double IndicatedPe
        {
            get => _indicatedPe;
            set => SetProperty(ref _indicatedPe, value);
        }

        public double PeTtm
        {
            get => _peTtm;
            set => SetProperty(ref _peTtm, value);
        }

        public double Eps
        {
            get => _eps;
            set => SetProperty(ref _eps, value);
        }

        public double EpsTtm
        {
            get => _epsTtm;
            set => SetProperty(ref _epsTtm, value);
        }

        public double Pb
        {
            get => _pb;
            set => SetProperty(ref _pb, value);
        }

        public long TotalShares
        {
            get => _totalShares;
            set => SetProperty(ref _totalShares, value);
        }

        public long OutstandingShares
        {
            get => _outstandingShares;
            set => SetProperty(ref _outstandingShares, value);
        }

        public double FiftyTwoWkHigh
        {
            get => _fiftyTwoWkHigh;
            set => SetProperty(ref _fiftyTwoWkHigh, value);
        }

        public double FiftyTwoWkLow
        {
            get => _fiftyTwoWkLow;
            set => SetProperty(ref _fiftyTwoWkLow, value);
        }

        public double Yield
        {
            get => _yield;
            set => SetProperty(ref _yield, value);
        }

        public string CurrencyCode
        {
            get => _currencyCode;
            set => SetProperty(ref _currencyCode, value);
        }

        public int LotSize
        {
            get => _lotSize;
            set => SetProperty(ref _lotSize, value);
        }

        public string LatestEarningsDate
        {
            get => _latestEarningsDate;
            set => SetProperty(ref _latestEarningsDate, value);
        }

        public double Ps
        {
            get => _ps;
            set => SetProperty(ref _ps, value);
        }

        public double Bps
        {
            get => _bps;
            set => SetProperty(ref _bps, value);
        }

        public string EstimateEarningsDate
        {
            get => _estimateEarningsDate;
            set => SetProperty(ref _estimateEarningsDate, value);
        }

        public string TradeStatus
        {
            get => _tradeStatus;
            set => SetProperty(ref _tradeStatus, value);
        }

        public string LimitUp
        {
            get => _limitUp;
            set => SetProperty(ref _limitUp, value);
        }

        public string LimitDown
        {
            get => _limitDown;
            set => SetProperty(ref _limitDown, value);
        }

        private double _price;
        public virtual double Price
        {
            get { return _price; }
            set { SetProperty(ref _price, value); }
        }
    }
}