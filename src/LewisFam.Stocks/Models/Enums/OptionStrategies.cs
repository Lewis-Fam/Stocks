namespace LewisFam.Stocks.Models.Enums
{
    /// <summary>The option strategy.</summary>
    public enum OptionStrategy
    {
        /// <summary>
        /// Call options are financial contracts that give the option buyer the right, but not the obligation, to buy a stock, bond, commodity or other asset or instrument at
        /// a specified price within a specific time period. The stock, bond, or commodity is called the underlying asset. A call buyer profits when the underlying asset
        /// increases in price.
        /// </summary>
        Call,

        /// <summary>
        /// A put option is a contract giving the owner the right, but not the obligation, to sell or sell short a specified amount of an underlying security at a
        /// pre-determined price within a specified time frame. This pre-determined price that buyer of the put option can sell at is called the strike price.
        /// </summary>
        Put,

        /// <summary>
        /// A debit spread involves buying an option with a higher premium and simultaneously selling an option with a lower premium, where the premium paid for the long
        /// option of the spread is more than the premium received from the written option. <br/><br/> Unlike a credit spread, a debit spread results in a premium debited, or
        /// paid, from the trader's or investor's account when the position is opened. Debit spreads are primarily used to offset the costs associated with owning long options
        /// positions. <br/><br/> For example, a trader buys one May put option with a strike price of $20 for $5 and simultaneously sells one May put option with a strike
        /// price of $10 for $1. Therefore, he paid $4, or $400 for the trade. If the trade is out of the money, his max loss is reduced to $400, as opposed to $500 if he only
        /// bought the put option.
        /// </summary>
        DebitSpread,

        /// <summary>
        /// A credit spread involves selling, or writing, a high-premium option and simultaneously buying a lower premium option. The premium received from the written option
        /// is greater than the premium paid for the long option, resulting in a premium credited into the trader or investor's account when the position is opened. When
        /// traders or investors use a credit spread strategy, the maximum profit they receive is the net premium. The credit spread results in a profit when the options'
        /// spreads narrow. <br/><br/> For example, a trader implements a credit spread strategy by writing one March call option with a strike price of $30 for $3 and
        /// simultaneously buying one March call option at $40 for $1. Since the usual multiplier on an equity option is 100, the net premium received is $200 for the trade.
        /// Furthermore, the trader will profit if the spread strategy narrows. <br/><br/> A bearish trader expects stock prices to decrease, and, therefore, buys call options
        /// (long call) at a certain strike price and sells (short call) the same number of call options within the same class and with the same expiration at a lower strike
        /// price.In contrast, bullish traders expect stock prices to rise, and therefore, buy call options at a certain strike price and sell the same number of call options
        /// within the same class and with the same expiration at a higher strike price.
        /// </summary>
        CreditSpread,

        /// <summary>
        /// A straddle is a neutral options strategy that involves simultaneously buying both a put option and a call option for the underlying security with the same strike
        /// price and the same expiration date. <br/><br/> A trader will profit from a long straddle when the price of the security rises or falls from the strike price by an
        /// amount more than the total cost of the premium paid. Profit potential is virtually unlimited, so long as the price of the underlying security moves very sharply.
        /// <br/><br/> Understanding Straddles <br/> More broadly, straddle strategies in finance refer to two separate transactions which both involve the same underlying
        /// security, with the two component transactions offsetting one another. Investors tend to employ a straddle when they anticipate a significant move in a stock's
        /// price but are unsure about whether the price will move up or down. A straddle can give a trader two significant clues about what the options market thinks about a
        /// stock. First is the volatility the market is expecting from the security. Second is the expected trading range of the stock by the expiration date. <br/><br/>
        /// Putting Together a Straddle <br/> To determine the cost of creating a straddle one must add the price of the put and the call together. For example, if a trader
        /// believes that a stock may rise or fall from its current price of $55 following earnings on March 1, they could create a straddle. The trader would look to purchase
        /// one put and one call at the $55 strike with an expiration date of March 15. To determine the cost of creating the straddle, the trader would add the price of one
        /// March 15 $55 call and one March 15 $55 put. If both the calls and the puts trade for $2.50 each, the total outlay or premium paid would be $5.00 for the two
        /// contracts. <br/><br/> The premium paid suggests that the stock would need to rise or fall by 9% from the $55 strike price to earn a profit by March 15. The amount
        /// the stock is expected to rise-or-fall is a measure of the future expected volatility of the stock. To determine how much the stock needs to rise or fall, divide
        /// the premium paid by the strike price, which is $5 / $55, or 9%. <br/><br/> Discovering the Predicted Trading Range <br/> Option prices imply a predicted trading
        /// range. To determine the expected trading range of a stock, one could add or subtract the price of the straddle to or from the price of the stock. In this case, the
        /// $5 premium could be added to $55 to predict a trading range of $50 to $60. If the stock traded within the zone of $50 to $60, the trader would lose some of their
        /// money but not necessarily all of it. At the time of expiration, it is only possible to earn a profit if the stock rises or falls outside of the $50 to $60 zone.
        /// <br/><br/> Earning a Profit <br/> If the stock fell to $48, the calls would be worth $0, while the puts would be worth $7 at expiration. That would deliver a
        /// profit of $2 to the trader. However, if the stock went to $57, the calls would be worth $2, and the puts would be worth zero, giving the trader a loss of $3. The
        /// worst-case scenario is when the stock price stays at or near the strike price. <br/><br/> Real World Example <br/> On Oct. 18, 2018, the options market was
        /// implying that AMD’s stock could rise or fall 20% from the $26 strike price for expiration on Nov. 16, because it cost $5.10 to buy one put and call. It placed the
        /// stock in a trading range of $20.90 to $31.15. A week later, the company reported results and shares plunged from $22.70 to $19.27 on Oct. 25.1﻿ In this case, the
        /// trader would have earned a profit because the stock fell outside of the range, exceeding the premium cost of buying the puts and calls. <br/>
        /// </summary>
        Straddle,

        /// <summary>
        /// A strangle is an options strategy where the investor holds a position in both a call and a put option with different strike prices, but with the same expiration
        /// date and underlying asset. A strangle is a good strategy if you think the underlying security will experience a large price movement in the near future but are
        /// unsure of the direction. However, it is profitable mainly if the asset does swing sharply in price. <br/><br/>
        ///
        /// A strangle is similar to a straddle, but uses options at different strike prices, while a straddle uses a call and put at the same strike price. <br/><br/>
        ///
        /// Strangles come in two forms: <br/>
        /// 1. In a long strangle the more common strategy the investor simultaneously buys an out-of-the-money call and an out-of-the-money put option. The call option's
        /// strike price is higher than the underlying asset's current market price, while the put has a strike price that is lower than the asset's market price. This
        /// strategy has large profit potential since the call option has theoretically unlimited upside if the underlying asset rises in price, while the put option can
        /// profit if the underlying asset falls. The risk on the trade is limited to the premium paid for the two options. <br/><br/>
        ///
        /// 2. An investor doing a short strangle simultaneously sells an out-of-the-money put and an out-of-the-money call. This approach is a neutral strategy with limited
        /// profit potential. A short strangle profits when the price of the underlying stock trades in a narrow range between the break even points. The maximum profit is
        /// equivalent to the net premium received for writing the two options, less trading costs. <br/><br/>
        ///
        /// Real World Example of a Strangle <br/> Let's say that Starbucks(SBUX) is currently trading at US$50 per share. To employ the strangle option strategy, a trader
        /// enters into two option positions, one call and one put. The call has a strike of $52, and the premium is $3, for a total cost of $300 ($3 x 100 shares). The put
        /// option has a strike price of $48, and the premium is $2.85, for a total cost of $285 ($2.85 x 100 shares). Both options have the same expiration date. <br/><br/>
        ///
        /// If the price of the stock stays between $48 and $52 over the life of the option, the loss to the trader will be $585, which is the total cost of the two option
        /// contracts ($300 + $285). However, let's say Starbucks' stock experiences some volatility. If the price of the shares ends up at $40, the call option will expire
        /// worthlessly, and the loss will be $300 for that option. However, the put option has gained value and produces a profit of $715 ($1,000 less the initial option cost
        /// of $285) for that option. Therefore, the total gain to the trader is $415 ($715 profit - $300 loss). <br/><br/>
        ///
        /// If the price rises to $55, the put option expires worthless and incurs a loss of $285. The call option brings in a profit of $200 ($500 value - $300 cost). When
        /// the loss from the put option is factored in, the trade incurs a loss of $85 ($200 profit - $285) because the price move wasn't large enough to compensate for the
        /// cost of the options. The operative concept is the move being big enough. If Starbucks had risen $10 in price, to $60 per share, the total gain would have again
        /// been $415 ($1000 value - $300 for call option premium - $285 for an expired put option).
        /// </summary>
        /// <remarks>
        /// A Strangle vs. a Straddle <br/> Strangles and straddles are similar options strategies that allow investors to profit from large moves to the upside or downside.
        /// However, a long straddle involves simultaneously buying at the money call and put options where the strike price is identical to the underlying asset's market
        /// price rather than out-of-the-money options. A short straddle is similar to a short strangle, with limited profit potential that is equivalent to the premium
        /// collected from writing the at the money call and put options. <br/><br/> With the straddle, the investor profits when the price of the security rises or falls from
        /// the strike price just by an amount more than the total cost of the premium. So it doesn't require as large a price jump. Buying a strangle is generally less
        /// expensive than a straddle but it carries greater risk because the underlying asset needs to make a bigger move to generate a profit.
        /// </remarks>
        Strangle,

        /// <summary>
        /// A condor spread is a non-directional options strategy that limits both gains and losses while seeking to profit from either low or high volatility. There are two
        /// types of condor spreads. A long condor seeks to profit from low volatility and little to no movement in the underlying asset. A short condor seeks to profit from
        /// high volatility and a sizable move in the underlying asset in either direction. <br/><br/> Understanding Condor Spreads <br/> The purpose of a condor strategy is
        /// to reduce risk, but that comes with reduced profit potential and the costs associated with trading several options legs. Condor spreads are similar to butterfly
        /// spreads because they profit from the same conditions in the underlying asset. The major difference is the maximum profit zone, or sweet spot, for a condor is much
        /// wider than that for a butterfly, although the trade-off is a lower profit potential. Both strategies use four options, either all calls or all puts. <br/><br/> As
        /// a combination strategy, a condor involves multiple options, with identical expiration dates, purchased and/or sold at the same time. For example, a long condor
        /// using calls is the same as running both an in-the-money long call, or bull call spread, and an out-of-the-money short call, or bear call spread.Unlike a long
        /// butterfly spread, the two sub-strategies have four strike prices, instead of three.Maximum profit is achieved when the short call spread expires worthless, while
        /// the underlying asset closes at or above the higher strike price in the long call spread.
        /// </summary>
        CondorSpread,

        /// <summary>
        /// An iron condor is an options strategy created with four options consisting of two puts (one long and one short) and two calls (one long and one short), and four
        /// strike prices, all with the same expiration date. The goal is to profit from low volatility in the underlying asset. In other words, the iron condor earns the
        /// maximum profit when the underlying asset closes between the middle strike prices at expiration. <br/><br/> The iron condor has a similar payoff as a regular condor
        /// spread, but uses both calls and puts instead of only calls or only puts. Both the condor and the iron condor are extensions of the butterfly spread and iron
        /// butterfly, respectively. <br/><br/> Understanding the Iron Condor <br/> The strategy has limited upside and downside risk because the high and low strike options,
        /// the wings, protect against significant moves in either direction. Because of this limited risk, its profit potential is also limited. The commission can be a
        /// notable factor here, as there are four options involved. <br/><br/> For this strategy, the trader ideally would like all of the options to expire worthlessly,
        /// which is only possible if the underlying asset closes between the middle two strike prices at expiration. There will likely be a fee to close the trade if it is
        /// successful. If it is not successful, the loss is still limited.
        /// </summary>
        /// <remarks>
        /// The construction of the strategy is as follows: <br/>
        /// 1. Buy one out of the money (OTM) put with a strike price below the current price of the underlying asset. The out of the money put option will protect against a
        /// significant downside move to the underlying asset. <br/><br/>
        /// 2. Sell one OTM or at the money (ATM) put with a strike price closer to the current price of the underlying asset. <br/><br/>
        /// 3. Sell one OTM or ATM call with a strike price above the current price of the underlying asset. <br/><br/>
        /// 4. Buy one OTM call with a strike price further above the current price of the underlying asset. The out of the money call option will protect against a
        /// substantial upside move. <br/><br/> The options that are further out of the money, called the wings, are both long positions. Because both of these options are
        /// further out of the money, their premiums are lower than the two written options, so there is a net credit to the account when placing the trade. <br/><br/> By
        /// selecting different strike prices, it is possible to make the strategy lean bullish or bearish. For example, if both the middle strike prices are above the current
        /// price of the underlying asset, the trader hopes for a small rise in its price by expiration. It still has limited reward and limited risk.
        /// </remarks>
        IronCondor,

        /// <summary>
        /// A butterfly spread is an options strategy combining bull and bear spreads, with a fixed risk and capped profit. These spreads, involving either four calls or four
        /// puts are intended as a market-neutral strategy and pay off the most if the underlying does not move prior to option expiration. <br/><br/> Understanding
        /// Butterflies <br/> Butterfly spreads use four option contracts with the same expiration but three different strike prices. A higher strike price, an at-the-money
        /// strike price, and a lower strike price. The options with the higher and lower strike prices are the same distance from the at-the-money options. If the
        /// at-the-money options have a strike price of $60, the upper and lower options should have strike prices equal dollar amounts above and below $60. At $55 and $65,
        /// for example, as these strikes are both $5 away from $60. <br/><br/> Puts or calls can be used for a butterfly spread. Combining the options in various ways will
        /// create different types of butterfly spreads, each designed to either profit from volatility or low volatility.
        /// </summary>
        ButterflySpread,

        /// <summary>
        /// The iron butterfly spread is created by buying an out-of-the-money put option with a lower strike price, writing an at-the-money put option, writing an
        /// at-the-money call option, and buying an out-of-the-money call option with a higher strike price. The result is a trade with a net credit that's best suited for
        /// lower volatility scenarios. The maximum profit occurs if the underlying stays at the middle strike price. <br/><br/> The maximum profit is the premiums received.
        /// The maximum loss is the strike price of the bought call minus the strike price of the written call, less the premiums received.
        /// </summary>
        IronButterfly,

        /// <summary>
        /// The reverse iron butterfly spread is created by writing an out-of-the-money put at a lower strike price, buying an at-the-money put, buying an at-the-money call,
        /// and writing an out-of-the-money call at a higher strike price. This creates a net debit trade that's best suited for high-volatility scenarios. Maximum profit
        /// occurs when the price of the underlying moves above or below the upper or lower strike prices. <br/><br/> The strategy's risk is limited to the premium paid to
        /// attain the position. The maximum profit is the strike price of the written call minus the strike of the bought call, less the premiums paid.
        /// </summary>
        ReverseIronButterfly
    }
}

//<br/>