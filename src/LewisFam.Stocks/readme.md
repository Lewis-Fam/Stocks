# LewisFam.Stocks
 
LewisFam.Stocks is a fast, free and simple stock and option prices API written in C#. This API can easily be intergrated into any .NET project.

## Features
- Fast and Free!
- Free real-time stock quotes from [Cnbc] & [Webull]
- Free real-time stock option prices from [Webull]
- .NET Cross-Platform & Modularity

## Installation

- Install via NuGet: https://www.nuget.org/packages/LewisFam.Stocks

```sh
Install-Package LewisFam.Stocks
```

```sh
dotnet add package LewisFam.Stocks
```

- Install via Repository Clone: [https://github.com/Lewis-Fam/Stocks.git](https://github.com/Lewis-Fam/Stocks.git)

## Simple Usage
- [Console](###console)
- [Dependency injection](###dependency-injection-mvc) asp.net core

### Console
```csharp
using LewisFam.Stocks;
```
```csharp
public class Program 
{
    private static async Task Main(string[] args)
    {
        var stock = await StocksUtil.FindStockAsync("MSFT");
        var quote = await StocksUtil.GetRealTimeMarketQuoteAsync(stock);

        //Multiple quotes.
        var stockList = new List<Stock>();
        stockList.Add(stock);
        //stockList.Add(someOtherStock);

        var quotes = await StocksUtil.GetRealTimeMarketQuotesAsync(stockList);
        
        var options = await StocksUtil.GetAllStockOptionsAsync(stock);
    }
}
```

### Dependency Injection MVC

.NET CORE ASP MVC example

#### Startup.cs
```csharp
using LewisFam.Stocks.ThirdParty.Cnbc;
using LewisFam.Stocks.ThirdParty.Services;
using LewisFam.Stocks.ThirdParty.Webull;

public class Startup 
{
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

#### SampleStockController.cs
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
[Test link](#features)

## Tech & Requirements

The LewisFam library uses a number of open source projects to work properly:

- .NET
- Web access
- [LewisFam.Common] - a free and open source common library.
- [Cnbc] - Real-Time stock quotes.
- [Webull] - Real-Time stock quotes and option prices.

And of course LewisFam.Stocks itself is open source with a [public repository] on GitHub.

## License
MIT

**Free Software, Yay!**

## Version
v1.0.7

[//]: #    
   [CNbc]: <https://cnbc.com>
   [Webull]: <https://webull.com>
   [LewisFam.Common]: <https://github.com/Lewis-Fam/LewisFam.Common>
   [LewisFam.Stocks]: <https://github.com/Lewis-Fam/Stocks>
   [LewisFam.Stocks.Test]: <https://github.com/Lewis-Fam/Stocks/tree/main/src/LewisFam.StocksTests>
   [public repository]: <https://github.com/Lewis-Fam/Stocks>
