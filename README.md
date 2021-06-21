# LewisFam.Stocks

LewisFam.Stocks is a free and simple stock and option prices API. The API can currently gets real-time pricing from CNBC.com and Webull.com.

## Features

- Get real time stock quotes from both [Cnbc] & [Webull]
- Stock option prices from [Webull]

## Usage

### Dependency Injection

#### Startup.cs
```csharp
using LewisFam.Stocks.ThirdParty.Services;
using LewisFam.Stocks.ThirdParty.Cnbc;
using LewisFam.Stocks.ThirdParty.Webull;

public void ConfigureServices(IServiceCollection services)
{            
    services.AddTransient<IWebullDataService, WebullDataService>();
    services.AddTransient<ICnbcDataService, CnbcDataService>();
    
    services.AddControllersWithViews();            
    services.AddRazorPages();
    //..
}

```

### StocksUtil
```csharp
var stock = await StocksUtil.FindStockAsync("MSFT");
var options = await StocksUtil.GetAllStockOptions
```

## Demo / Tests
[LewisFam.Stocks.Test]

## Tech

The LewisFam library uses a number of open source projects to work properly:

- [LewisFam.Common] - a free and open source common library.
- [Cnbc] - Real-Time stock quotes.
- [Webull] - Real-Time stock quotes and option prices.

And of course Dillinger itself is open source with a [public repository][dill]
 on GitHub.

## Installation

LewisFam.Stocks is a comman class libary using dotnet v and C#. 

```sh
dotnet add package LewisFam.Stocks --version 1.0.0
```

## Usage

## License

MIT

**Free Software, Hell Yeah!**

[//]: # (These are reference links used in the body of this note and get stripped out when the markdown processor does its job. There is no need to format nicely because it shouldn't be seen. Thanks SO - http://stackoverflow.com/questions/4823468/store-comments-in-markdown-syntax)
   
   [CNbc]: <https://cnbc.com>
   [Webull]: <https://webull.com>
   [LewisFam.Common]: <https://github.com/Lewis-Fam/LewisFam.Common>
   [LewisFam.Stocks.Test]: <https://github.com/Lewis-Fam/Stocks/tree/main/src/LewisFam.Stocks.Tests>

   [PlDb]: <https://github.com/joemccann/dillinger/tree/master/plugins/dropbox/README.md>
   [PlGh]: <https://github.com/joemccann/dillinger/tree/master/plugins/github/README.md>
   [PlGd]: <https://github.com/joemccann/dillinger/tree/master/plugins/googledrive/README.md>
   [PlOd]: <https://github.com/joemccann/dillinger/tree/master/plugins/onedrive/README.md>
   [PlMe]: <https://github.com/joemccann/dillinger/tree/master/plugins/medium/README.md>
   [PlGa]: <https://github.com/RahulHP/dillinger/blob/master/plugins/googleanalytics/README.md>
