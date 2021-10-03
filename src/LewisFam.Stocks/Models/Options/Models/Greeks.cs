
namespace LewisFam.Stocks.Models
{
    /// <inheritdoc cref="IGreeks"/>
    public class Greeks : IGreeks
    {
        /// <inheritdoc />
        public virtual double? Delta { get; set; }

        /// <inheritdoc />
        public virtual double? Gamma { get; set; }

        /// <summary>
        /// Rho (p) represents the rate of change between an option's value and a 1% change in the interest rate. This measures sensitivity to the interest rate. For example,
        /// assume a call option has a rho of 0.05 and a price of $1.25. If interest rates rise by 1%, the value of the call option would increase to $1.30, all else being
        /// equal. The opposite is true for put options. Rho is greatest for at-the-money options with long times until expiration.
        /// </summary>
        public virtual double? Rho { get; set; }

        /// <summary>
        /// Theta (Θ) represents the rate of change between the option price and time, or time sensitivity - sometimes known as an option's time decay. Theta indicates the
        /// amount an option's price would decrease as the time to expiration decreases, all else equal. For example, assume an investor is long an option with a theta of
        /// -0.50. The option's price would decrease by 50 cents every day that passes, all else being equal.
        /// </summary>
        public virtual double? Theta { get; set; }

        /// <summary>
        /// Vega (v) represents the rate of change between an option's value and the underlying asset's implied volatility. This is the option's sensitivity to volatility.
        /// Vega indicates the amount an option's price changes given a 1% change in implied volatility. For example, an option with a Vega of 0.10 indicates the option's
        /// value is expected to change by 10 cents if the implied volatility changes by 1%.
        /// </summary>
        public virtual double? Vega { get; set; }

        public virtual double? ImpVol { get; }
    }
}