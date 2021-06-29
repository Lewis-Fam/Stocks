
//using HttpClient = LewisFam.Stocks.Internal.HttpClient;

namespace LewisFam.Stocks.ThirdParty.Robinhood.Api
{
    //internal class Http : HttpClient
    //{
    //    protected string BaseUrl { get; set; }

    //    static Http() { }

    //    private Http()
    //    {
    //        Timeout = TimeSpan.FromSeconds(15);
    //        MaxResponseContentBufferSize = 256000;
    //    }

    //    //public Http(string baseUrl = null) : base()
    //    //{
    //    //    BaseUrl = baseUrl;
    //    //}

    //    public static Http Current { get; } = new Http();

        
    //    public async Task<IEnumerable<T>> GetItems<T>(string url)
    //    {
            
    //        try
    //        {
    //            var uri = new Uri(url);

    //            var response = await GetAsync(uri).ConfigureAwait(false);

    //            if (!response.IsSuccessStatusCode) throw new HttpResponseException(response);

    //            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

    //            return JsonConvert.DeserializeObject<List<T>>(content);

    //        }
    //        catch (HttpRequestException e)
    //        {
    //            // TODO: Handle the System.Net.Http.HttpRequestException
    //            return null;
    //        }

    //        catch (HttpResponseException e)
    //        {
    //            // TODO: Handle the System.Net.Http.HttpRequestException
    //            return null;
    //        }
    //    }

    //    public async Task<T> GetItem<T>(string url)
    //    {
    //        var uri = new Uri(url);
    //        var response = await GetAsync(uri);
    //        if (response.IsSuccessStatusCode)
    //        {
    //            var content = await response.Content.ReadAsStringAsync();
    //            var item = JsonConvert.DeserializeObject<T>(content);
    //            return item;
    //        }
    //        throw new Exception(response.ReasonPhrase);
    //    }

    //    public async Task Post<T>(T item, string url)
    //    {
    //        var uri = new Uri(string.Format(url));
    //        var json = JsonConvert.SerializeObject(item);
    //        var content = new StringContent(json, Encoding.UTF8, "application/json");
    //        HttpResponseMessage response = null;
    //        response = await PostAsync(uri, content).ConfigureAwait(false);

    //        if (response.IsSuccessStatusCode)
    //        {
    //            return;
    //        }

    //        throw new Exception(response.ReasonPhrase);
    //    }

    //class Credentials
    //{
    //    public Credentials(string username, string password, string mfa_Code)
    //    {
    //        Username = username ?? throw new ArgumentNullException(nameof(username));
    //        Password = password ?? throw new ArgumentNullException(nameof(password));
    //        Mfa_Code = mfa_Code ?? throw new ArgumentNullException(nameof(mfa_Code));
    //    }

    //    protected string Username { get; }
    //    public string Password { get; }
    //    public string Mfa_Code { get; }

    //}

    //internal class Login : HttpClient
    //{
    //    //public string GetToken(string url, Credentials credentials)
    //    //{
    //    //    var c = new HttpClient();
    //    //    var json = JsonConvert.SerializeObject(credentials);
    //    //    var content = new StringContent(json, Encoding.UTF8, "application/json");
    //    //    HttpResponseMessage response = null;
    //    //    c.PostAsync(url, content);
    //    //    //c.PostAsync(url, new StringContent())
    //    //    if (response.IsSuccessStatusCode)
    //    //    {
    //    //        return response.Content.ToString();
    //    //    }

    //    //    throw new Exception(response.ReasonPhrase);
    //    //}

    //    public async Task Post<T>(T item, string url)
    //    {
    //        var uri = new Uri(string.Format(url));
    //        var json = JsonConvert.SerializeObject(item);
    //        var content = new StringContent(json, Encoding.UTF8, "application/json");
    //        HttpResponseMessage response = null;
    //        response = await PostAsync(uri, content).ConfigureAwait(false);

    //        if (response.IsSuccessStatusCode)
    //        {
    //            return;
    //        }

    //        throw new Exception(response.ReasonPhrase);
    //    }
    //}
    //}
}
