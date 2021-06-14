using System;
using System.Diagnostics;

namespace LewisFam.Stocks.Internal.Models
{
    public abstract class BaseDataService : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseDataService"/> class.
        /// </summary>
        protected BaseDataService()
        {
            Debug.WriteLine($"{nameof(BaseDataService)}");
        }

        /// <summary>
        /// Gets the client.
        /// </summary>
        internal HttpClient Client { get; } = new HttpClient();

        /// <summary>
        /// Gets or sets the uri.
        /// </summary>
        protected Uri Uri { get; set; }

        /// <inheritdoc cref="Dispose()"/>
        protected virtual void Dispose(bool disposing)
        {
            Debug.WriteLine($"BaseDataService : Dispose : {disposing}");
            if (disposing)
            {
                Client?.Dispose();
            }
        }

        ///<inheritdoc/>
        public void Dispose()
        {
            Debug.WriteLine("BaseDataService : Dispose");
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}