using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using LewisFam.Stocks.Models;
using LewisFam.Stocks.Options.Models;
using LewisFam.Stocks.ThirdParty.Webull;

namespace LewisFam.Stocks.Monitor
{
    public class MarketMonitor
    {
        public event EventHandler OnMarketQuoteReceived;

        public event EventHandler<MarketAlertArgs> OnMarketAlert;

        //public event EventHandler<OptionAlertArgs> OnOptionAlert;

        public void Alert(EventArgs e)
        {
            switch (e)
            {
                //case OptionAlertArgs oargs:
                //    //OnOptionAlert?.Invoke(this, oargs);
                //    break;
                case MarketAlertArgs _sargs_:
                    OnMarketAlert?.Invoke(this, _sargs_);
                    break;
            }
        }

        public IEnumerable<Stock> StocksToMonitor { get; }

        public MarketMonitor(IEnumerable<Stock> stocks, IEnumerable<IOption> options)
        {
            StocksToMonitor = stocks;
            OptionsToMonitor = options;
        }

        public IEnumerable<IOption> OptionsToMonitor { get; }

        public bool IsRunning { get; private set; }

        public void Start(bool pooling, int interval)
        {
            if (pooling && !IsRunning)
            {
                IsRunning = true;
                _timer = new Timer(interval);
                _timer.Elapsed += TOnElapsed;
                _timer.Start();
            }
        }

        public void Stop()
        {
            IsRunning = false;
            _timer.Stop();

        }

        private Timer _timer;
        private void TOnElapsed(object sender, ElapsedEventArgs e)
        {
            UpdateStocks();
        }

        void UpdateStocks()
        {

        }

        async void UpdateOptions()
        {
            var derivedIds = OptionsToMonitor.Select(s => s.TickerId);
            using var wb = new WebullDataService();
            var quotes = await wb.GetRealTimeOptionQuotesAsync(derivedIds);
            Alert(new MarketAlertArgs("", quotes.FirstOrDefault()));
        }
    }

    public enum AlertType
    {
        Unknown,
        Price,
    }

    public class MarketAlertArgs : EventArgs
    {
        public MarketAlertArgs(string message, IStock stock)
        {
            Message = message;
            Stock = stock;
        }

        public MarketAlertArgs(string message, IOption option) : this(message, option.Stock)
        {
            Option = option;
        }

        private void FormatMessage()
        {
            FormattedMessage = $"{Message} - ";
        }

        public IOption Option { get; }
        public IStock Stock { get; }
        public string Message { get; }

        public string FormattedMessage { get; private set; }
    }

}
