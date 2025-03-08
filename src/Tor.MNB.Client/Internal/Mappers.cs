using Tor.MNB.Client.Extensions;
using Tor.MNB.Client.Internal.Models;
using Tor.MNB.Client.Models;

namespace Tor.MNB.Client.Internal
{
    internal class Mappers
    {
        internal static readonly Func<GetCurrenciesResponseModel, List<string>> Currencies = x =>
            x?.Currencies?.CurrencyCodes ?? [];

        internal static readonly Func<GetInfoResponseModel, InfoResult> Info = x =>
            x == null ? null : new InfoResult()
            {
                FirstDate = DateOnly.FromDateTime(x.FirstDate),
                LastDate = DateOnly.FromDateTime(x.LastDate),
                CurrencyCodes = x.Currencies?.CurrencyCodes ?? []
            };

        internal static readonly Func<GetCurrencyUnitsResponseModel, List<CurrencyUnitResult>> CurrencyUnits = x =>
            x?.UnitsCollection?.Items?.Select(x => new CurrencyUnitResult()
            {
                CurrencyCode = x.CurrencyCode,
                Unit = x.Unit.ToDecimal()
            }).ToList() ?? [];

        internal static readonly Func<GetDateIntervalResponseModel, DateIntervalResult> DateInterval = x =>
            x == null ? null : new DateIntervalResult()
            {
                StartDate = DateOnly.FromDateTime(x.DateInterval.StartDate),
                EndDate = DateOnly.FromDateTime(x.DateInterval.EndDate)
            };

        internal static readonly Func<GetExchangeRatesResponseModel, List<ExchangeRatesResult>> ExchangeRates = x =>
            x?.Day?.Select(x => new ExchangeRatesResult()
            {
                Date = DateOnly.FromDateTime(x.Date),
                Rates = x?.Rates?.Select(y => new ExchangeRateResult()
                {
                    CurrencyCode = y.CurrencyCode,
                    ExchangeRate = y.ExchangeRate.ToDecimal(),
                    Unit = y.Unit.ToDecimal()
                }).ToList() ?? []
            }).ToList() ?? [];

        internal static readonly Func<GetCurrentExchangeRatesResponseModel, ExchangeRatesResult> CurrentExchangeRates = x =>
            x?.Day == null ? null : new ExchangeRatesResult()
            {
                Date = DateOnly.FromDateTime(x.Day.Date),
                Rates = x.Day.Rates?.Select(y => new ExchangeRateResult()
                {
                    CurrencyCode = y.CurrencyCode,
                    ExchangeRate = y.ExchangeRate.ToDecimal(),
                    Unit = y.Unit.ToDecimal()
                }).ToList() ?? []
            };
    }
}
