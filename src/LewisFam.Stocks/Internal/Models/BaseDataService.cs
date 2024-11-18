using System;
using System.Diagnostics;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;

namespace LewisFam.Stocks.Internal
{
    public abstract class BaseDataService : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseDataService"/> class.
        /// </summary>
        protected BaseDataService()
        {
            //Debug.WriteLine($"{nameof(BaseDataService)} created.");
        }

        protected BaseDataService(IHttpClientFactory clientFactory)
        {
            //Debug.WriteLine($"{nameof(BaseDataService)} IHttpClientFactory created.");
           // System.Net.Http.HttpClient c = clientFactory.CreateClient();
           //Client = (HttpClient)c;
           Client = clientFactory.CreateClient();
        }

        /// <summary>
        /// Gets the client.
        /// </summary>
        internal System.Net.Http.HttpClient Client { get; } // = new System.Net.Http.HttpClient();

        /// <summary>
        /// Gets or sets the uri.
        /// </summary>
        protected Uri Uri { get; set; }

        /// <inheritdoc cref="Dispose()"/>
        protected virtual void Dispose(bool disposing)
        {
            Debug.WriteLine($"{nameof(BaseDataService)}.{nameof(Dispose)}:{nameof(disposing)}={disposing}");
            if (disposing)
            {
                Client?.Dispose();
            }
        }

        ///<inheritdoc/>
        public void Dispose()
        {
            Debug.WriteLine($"{nameof(BaseDataService)}.{nameof(Dispose)}");
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}