namespace LewisFam.Stocks.Models
{
    /// <remarks>
    /// "Greeks" is a term used in the options market to describe the different dimensions of risk involved in taking an options position. These variables are called Greeks
    /// because they are typically associated with Greek symbols. Each risk variable is a result of an imperfect assumption or relationship of the option with another
    /// underlying variable. Traders use different Greek values, such as delta, theta, and others, to assess options risk and manage option portfolios. <br/><br/> Greeks
    /// encompass many variables. These include delta, theta, gamma, vega, and rho, among others. Each one of these variables/Greeks has a number associated with it, and that
    /// number tells traders something about how the option moves or the risk associated with that option. The primary Greeks (Delta, Vega, Theta, Gamma, and Rho) are
    /// calculated each as a first partial derivative of the options pricing model (for instance, the Black-Scholes model). <br/><br/> The number or value associated with a
    /// Greek changes over time. Therefore, sophisticated options traders may calculate these values daily to assess any changes which may affect their positions or outlook,
    /// or to check if their portfolio needs to be rebalanced. Below are several of the main Greeks traders look at.
    /// </remarks>
    public interface IGreeks
    {
        /// <summary>
        /// Delta (Δ) represents the rate of change between the option's price and a $1 change in the underlying asset's price. In other words, the price sensitivity of the
        /// option relative to the underlying. Delta of a call option has a range between zero and one, while the delta of a put option has a range between zero and negative
        /// one. For example, assume an investor is long a call option with a delta of 0.50. Therefore, if the underlying stock increases by $1, the option's price would
        /// theoretically increase by 50 cents.
        /// </summary>
        double? Delta { get; }

        /// <summary>
        /// Gamma (Γ) represents the rate of change between an option's delta and the underlying asset's price. This is called second-order (second-derivative) price
        /// sensitivity. Gamma indicates the amount the delta would change given a $1 move in the underlying security. For example, assume an investor is long one call option
        /// on hypothetical stock XYZ. The call option has a delta of 0.50 and a gamma of 0.10. Therefore, if stock XYZ increases or decreases by $1, the call option's delta
        /// would increase or decrease by 0.10.
        /// </summary>
        double? Gamma { get; }
        double? Rho { get; }
        double? Theta { get; }
        double? Vega { get; }

        double? ImpVol { get; }
    }
}
