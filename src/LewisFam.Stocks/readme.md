# LewisFam.Stocks - Version 1.0.6
 
LewisFam.Stocks is a fast, free and simple stock and option prices API written in C#. This API can easily be intergrated into any .NET project.

## Features
- Fast and Free!
- Free real-time stock quotes from [Cnbc] & [Webull]
- Free real-time stock option prices from [Webull] (delayed 15 minutes.)
- .NET Cross-Platform

## Installation

LewisFam.Stocks is free and open source comman class libary using. 

```sh
Install-Package LewisFam.Stocks
```

```sh
dotnet add package LewisFam.Stocks
```

## Usage

### StocksUtil
```csharp
using LewisFam.Stocks;
```
```csharp
var stock = await StocksUtil.FindStockAsync("MSFT"); //find
```
```csharp
//Multiple quotes.
var stockList = new List<Stock>();
stockList.Add(stock);
//stockList.Add(someOtherStock);

var quotes = await StocksUtil.GetRealTimeMarketQuotesAsync(stockList);
////or extension method.
//quotes = await stockList.GetGetRealTimeMarketQuotesAsync();
```
```csharp
var quote = await StocksUtil.GetRealTimeMarketQuoteAsync(stock);
////or extension method.
//quote = await stock.GetRealTimeMarketQuoteAsync();
```

##### Stock Options
```csharp
var options = await StocksUtil.GetAllStockOptionsAsync(stock.TickerId);
////or extension method.
//options = await stock.GetAllStockOptionsAsync();
```

### Dependency Injection

#### Startup.cs
```csharp
using LewisFam.Stocks.ThirdParty.Cnbc;
using LewisFam.Stocks.ThirdParty.Services;
using LewisFam.Stocks.ThirdParty.Webull;
public class Startup { 

public void ConfigureServices(IServiceCollection services)
{       
    //..
    services.AddTransient<IWebullDataService, WebullDataService>();    
    services.AddTransient<ICnbcDataService, CnbcDataService>();    
    
    //services.AddControllersWithViews();                
    //services.AddRazorPages();
    //..
}
}
```

#### SampleStocksController.cs
```csharp
using LewisFam.Stocks.ThirdParty.Services;
using LewisFam.Stocks.ThirdParty.Webull;

public class SampleStockController : Controller
{
    private readonly IWebullDataService _webull;

    public SampleStockController(IWebullDataService webull)
    {
        _webull = webull;
    }

    public async Task<IActionResult> GetAllOptions(long tickerId)
    {
        var data = await _webulll.GetAllStockOptionsAsync(tickerId);
        if (data == null) return BadRequest(tickerId);
        return View(data);
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

Replaced

[//]: #    
   [CNbc]: <https://cnbc.com>
   [Webull]: <https://webull.com>
   [LewisFam.Common]: <https://github.com/Lewis-Fam/LewisFam.Common>
   [LewisFam.Stocks.Test]: <https://github.com/Lewis-Fam/Stocks/tree/main/src/LewisFam.Stocks.Tests>
   [public repository]: <https://github.com/Lewis-Fam>
