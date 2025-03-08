# Tor.MNB.Client

[![](https://img.shields.io/nuget/dt/Tor.Mnb.Client)](#) [![](https://img.shields.io/nuget/v/Tor.Mnb.Client)](https://www.nuget.org/packages/Tor.Mnb.Client)

A C# client library for [MNB - Magyar Nemzeti Bank](https://www.mnb.hu/sajtoszoba/sajtokozlemenyek/2015-evi-sajtokozlemenyek/tajekoztatas-az-arfolyam-webservice-mukodeserol) API with dependency injection support.

## Installation

```text
Install-Package Tor.Mnb.Client
```

## Usage

> **_NOTE:_**  The base currency is always HUF (Hungarian Forint), but you don't have to hard code this, you can get this information from the **IMnbClient.BaseCurrencyCode** property.

### Registering to .NET Core service collection

You have to register the **MnbClient** with the dependencies in the Program.cs file.

```text
services.AddMnb();
```

### IMnbClient usage

You can get the **IMnbClient** via dependency injection:

```text
public class MyService
{
    public MyService(IMnbClient client)
    {
    }   
}
```

#### IMnbClient.GetCurrenciesAsync method

No method parameters.

Response: A string list with the available currency codes

#### IMnbClient.GetInfoAsync method

No method parameters.

Response:

| Property      | Description                 |
| ------------- | ----------------------------|
| FirstDate     | First available date        |
| LastDate      | Last available date         |
| CurrencyCodes | Available currency codes    |

#### IMnbClient.GetCurrencyUnitsAsync method

Method parameters:

| Parameter                 | Description                                              | Optional / Required |
| --------------------------|----------------------------------------------------------|---------------------|
| currencyCodes             | The requested three letter currency codes                | Required            |

Response: a list of the following opject

| Property               | Description                     |
| ---------------------- | --------------------------------|
| CurrencyCode           | Three letter currency code      |
| Unit                   | The unit of the currency        |

#### IMnbClient.GetDateIntervalAsync method

No method parameters.

Response:

| Property      | Description                 |
| ------------- | ----------------------------|
| StartDate     | First available date        |
| EndDate       | Last available date         |

#### IMnbClient.GetExchangeRatesAsync method

Method parameters:

| Parameter                 | Description                                              | Optional / Required |
| --------------------------|----------------------------------------------------------|---------------------|
| startDate                 | The start date                                           | Required            |
| endDate                   | The end date                                             | Required            |
| currencyCodes             | The requested three letter currency codes                | Required            |

Response: a list of the following opject

| Property               | Description                     |
| ---------------------- | --------------------------------|
| Date                   | Date of the rates               |
| Rates -> CurrencyCode  | The three letter currency code  |
| Rates -> Unit          | Unit                            |
| Rates -> ExchangeRate  | Exchange rate                   |

#### IMnbClient.GetCurrentExchangeRatesAsync method

No method parameters.

Response: 

| Property               | Description                     |
| ---------------------- | --------------------------------|
| Date                   | Date of the rates               |
| Rates -> CurrencyCode  | The three letter currency code  |
| Rates -> Unit          | Unit                            |
| Rates -> ExchangeRate  | Exchange rate                   |
