using Tor.Mnb.Client.Internal;
using Tor.Mnb.Client.Models;

namespace Tor.Mnb.Client.Extensions
{
    public static class ExchangeRatesExtensions
    {
        public static decimal Convert(
            this ExchangeRatesResult rates,
            string sourceCurrencyCode,
            string destinationCurrencyCode,
            decimal quantity)
        {
            ArgumentNullException.ThrowIfNull(rates);
            ArgumentException.ThrowIfNullOrWhiteSpace(sourceCurrencyCode);
            ArgumentException.ThrowIfNullOrWhiteSpace(destinationCurrencyCode);

            if (sourceCurrencyCode.IgnoreCaseEquals(destinationCurrencyCode))
            {
                return quantity;
            }

            if (sourceCurrencyCode.IgnoreCaseEquals(rates.BaseCurrencyCode))
            {
                var rate = rates.Rates.SingleOrDefault(x => x.CurrencyCode.IgnoreCaseEquals(destinationCurrencyCode));

                return rate != null
                    ? 1 / (rate.ExchangeRate / rate.Unit) * quantity
                    : throw new Exception(Constants.Messages.DestinationCurrencyCodeNotFound);
            }

            if (destinationCurrencyCode.IgnoreCaseEquals(rates.BaseCurrencyCode))
            {
                var rate = rates.Rates.SingleOrDefault(x => x.CurrencyCode.IgnoreCaseEquals(sourceCurrencyCode));

                return rate != null
                    ? rate.ExchangeRate / rate.Unit * quantity
                    : throw new Exception(Constants.Messages.SourceCurrencyCodeNotFound);
            }

            var sourceRate = rates.Rates.SingleOrDefault(x => x.CurrencyCode.IgnoreCaseEquals(sourceCurrencyCode));
            var destinationRate = rates.Rates.SingleOrDefault(x => x.CurrencyCode.IgnoreCaseEquals(destinationCurrencyCode));

            return sourceRate == null
                ? throw new Exception(Constants.Messages.SourceCurrencyCodeNotFound)
                : destinationRate == null
                    ? throw new Exception(Constants.Messages.DestinationCurrencyCodeNotFound)
                    : 1 / (destinationRate.ExchangeRate / destinationRate.Unit / (sourceRate.ExchangeRate / sourceRate.Unit)) * quantity;
        }
    }
}
