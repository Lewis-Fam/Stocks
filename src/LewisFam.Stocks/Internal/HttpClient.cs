﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LewisFam.Stocks
{
    internal static class HttpClient //: System.Net.Http.HttpClient
    {
        //public HttpClient() : base()
        //{
        //    _client = new System.Net.Http.HttpClient();
        //}

        //public HttpClient(IList<KeyValuePair<string, string>> customHeaders) : this()
        //{
        //    _headers = customHeaders ?? throw new ArgumentNullException(nameof(customHeaders));
        //    setCustomHeaders(); 
        //}

        public static async Task<T> GetJsonAsync<T>(this System.Net.Http.HttpClient _client, Uri uri) where T : new()
        {
            using var request = await _client.GetAsync(uri);
            var strg = await request.Content.ReadAsStringAsync();
            return JToken.Parse(strg).ToObject<T>();
        }

        //public async Task<string> ReadAsStringAsync(Uri uri)
        //{
        //    using var request = await _client.GetAsync(uri);
        //    return await request.Content.ReadAsStringAsync();
        //}

        //public async Task<Stream> ReadAsStreamAsync(Uri uri)
        //{
        //    using var request = await _client.GetAsync(uri);
        //    return await request.Content.ReadAsStreamAsync();
        //}

        //public async Task<byte[]> ReadAsByteArrayAsync(Uri uri)
        //{
        //    using var request = await _client.GetAsync(uri);
        //    return await request.Content.ReadAsByteArrayAsync();
        //}

        public static async Task<string> GetJsonAsync(this System.Net.Http.HttpClient _client, Uri uri, string selectToken = "", Formatting format = Formatting.None)
        {
            try
            {
                //await Task.CompletedTask;
                var strg = await _client.GetStringAsync(uri);
                var json = JToken.Parse(strg).SelectToken(selectToken);
                return json?.ToString(format);
            }
            catch (System.Net.Http.HttpRequestException)
            {
                throw;
            }
            finally
            {
                //_client?.Dispose();
            }
        }

        //protected override void Dispose(bool disposing)
        //{
        //    base.Dispose(disposing);

        //    if (disposing)
        //    {
        //        _client?.Dispose();
        //    }
        //}

        //private readonly System.Net.Http.HttpClient _client;

        //private readonly IList<KeyValuePair<string, string>> _headers;

        //private void setCustomHeaders()
        //{
        //    for (var i = 0; i < _headers.Count - 1; i++)
        //    {
        //        Debug.Assert(_client.DefaultRequestHeaders != null, "_client.DefaultRequestHeaders != null");
        //        _client?.DefaultRequestHeaders.Add(_headers[i].Key, _headers[i].Value);
        //    }
        //}

        //public void AddAuthToken(string accessToken)
        //{
        //    _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        //}
    }
}