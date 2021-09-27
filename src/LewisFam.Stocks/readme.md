# LewisFam.Stocks - Version 1.0.1

LewisFam.Stocks is a free and simple stock and option prices API. The API can currently get real-time pricing from CNBC.com and Webull.com.

## Features

- Get real-time stock quotes from [Cnbc] & [Webull]
- Get real-time stock option prices from [Webull] (delayed 15 minutes.)
- Strongly-Typed Objects

## Installation

LewisFam.Stocks is free and open source comman class libary using. 

```sh
Install-Package LewisFam.Stocks --version 1.0.1
```

```sh
dotnet add package LewisFam.Stocks --version 1.0.1
```

## Usage

### StocksUtil
```csharp
var stock = await StocksUtil.FindStockAsync("MSFT"); //find
var quote = await StocksUtil.GetRealTimeMarketQuoteAsync(stock);
////or extension method.
//quote = await stock.GetRealTimeMarketQuoteAsync();

//Multiple quotes.
var stockList = new List<Stock>();
stockList.Add(stock);

var quotes = await StocksUtil.GetRealTimeMarketQuotesAsync(stockList);
//or extension method.
//quotes = await stockList.GetGetRealTimeMarketQuotesAsync();
```
##### Stock Options
```csharp
var options = await StocksUtil.GetAllStockOptions(stock.TickerId);
//or extension method.
options = await stock.GetAllStockOptionsAsync();
```

### Dependency Injection

#### Startup.cs
```csharp
using LewisFam.Stocks.ThirdParty.Cnbc;
using LewisFam.Stocks.ThirdParty.Services;
using LewisFam.Stocks.ThirdParty.Webull;

public void ConfigureServices(IServiceCollection services)
{       
    //..
    services.AddTransient<IWebullDataService, WebullDataService>();    
    services.AddTransient<ICnbcDataService, CnbcDataService>();    
    
    //services.AddControllersWithViews();                
    //services.AddRazorPages();
    //..
}
```

#### StocksController.cs
```csharp
using LewisFam.Stocks.ThirdParty.Services;
using LewisFam.Stocks.ThirdParty.Webull;

public class StocksController : Controller
{
    private readonly IWebullDataService _webull;

    public StocksController(IWebullDataService webull)
    {
        _webull = webull;
    }

    public async Task<IActionResult> GetAllOptions(long tickerId)
    {
        var data = await _wb.GetAllStockOptionsAsync(tickerId);
        if (data == null) return BadRequest(tickerId);
        return Ok(data);
    }
}
```

## Demo / Tests
[LewisFam.Stocks.Test]

## Tech

The LewisFam library uses a number of open source projects to work properly:

- [LewisFam.Common] - a free and open source common library.
- [Cnbc] - Real-Time stock quotes.
- [Webull] - Real-Time stock quotes and option prices.

And of course LewisFam.Stocks itself is open source with a [public repository] on GitHub.

## License
MIT

**Free Software, Yay!**

[//]: #    
   [CNbc]: <https://cnbc.com>
   [Webull]: <https://webull.com>
   [LewisFam.Common]: <https://github.com/Lewis-Fam/LewisFam.Common>
   [LewisFam.Stocks.Test]: <https://github.com/Lewis-Fam/Stocks/tree/main/src/LewisFam.Stocks.Tests>
   [public repository]: <https://github.com/Lewis-Fam>
