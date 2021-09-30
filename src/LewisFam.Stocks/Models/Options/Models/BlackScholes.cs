using System;
using LewisFam.Stocks.Models.Enums;

namespace LewisFam.Stocks.Options.Models
{

    /// <summary>Summary description for BlackSholes.</summary>
    public class BlackScholes
    {
        public static double Compute(OptionStrategy CallPutFlag, double spotPrice, double strikePrice,
            double time, double rate, double impVol)
        {
            //double d1;// = 0.0;
            //double d2; // = 0.0;
            double dBlackScholes = 0.0;

            var d1 = (Math.Log(spotPrice / strikePrice) + (rate + impVol * impVol / 2.0) * time) / (impVol * Math.Sqrt(time));
            var d2 = d1 - impVol * Math.Sqrt(time);
            if (CallPutFlag == OptionStrategy.Call)
            {
                dBlackScholes = spotPrice * CND(d1) - strikePrice * Math.Exp(-rate * time) * CND(d2);
            }
            else if (CallPutFlag == OptionStrategy.Put)
            {
                dBlackScholes = strikePrice * Math.Exp(-rate * time) * CND(-d2) - spotPrice * CND(-d1);
            }
            return dBlackScholes;
        }


        public static double Compute(string callPutSlide, double spotPrice, double strikePrice,
            double time, double rate, double impVol)
        {
            //double d1;// = 0.0;
            //double d2; // = 0.0;
            double dBlackScholes = 0.0;

            var d1 = (Math.Log(spotPrice / strikePrice) + (rate + impVol * impVol / 2.0) * time) / (impVol * Math.Sqrt(time));
            var d2 = d1 - impVol * Math.Sqrt(time);
            if (callPutSlide == "call" || callPutSlide == "CALL")
            {
                dBlackScholes = spotPrice * CND(d1) - strikePrice * Math.Exp(-rate * time) * CND(d2);
            }
            else if (callPutSlide == "put" || callPutSlide == "PUT")
            {
                dBlackScholes = strikePrice * Math.Exp(-rate * time) * CND(-d2) - spotPrice * CND(-d1);
            }
            return dBlackScholes;
        }

        //public static double BlackScholesRange(OptionType CallPutFlag,
        //    double spotPrice,
        //    double strikePrice,
        //    double time,
        //    double rate,
        //    double impVol)
        //{

        //}

        private static double CND(double x)
        {
            const double a1 = 0.31938153;
            const double a2 = -0.356563782;
            const double a3 = 1.781477937;
            const double a4 = -1.821255978;
            const double a5 = 1.330274429;
            var L = Math.Abs(x);
            var K = 1.0 / (1.0 + 0.2316419 * L);
            var dCND = 1.0 - 1.0 / Math.Sqrt(2 * Convert.ToDouble(Math.PI.ToString())) *
                Math.Exp(-L * L / 2.0) * (a1 * K + a2 * K * K + a3 * Math.Pow(K, 3.0) +
                                          a4 * Math.Pow(K, 4.0) + a5 * Math.Pow(K, 5.0));

            if (x < 0)
            {
                return 1.0 - dCND;
            }
            else
            {
                return dCND;
            }
        }
    }


}