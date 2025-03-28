﻿using Microsoft.AspNetCore.Components;
using Tor.Mnb.Client.Models;

namespace Tor.Mnb.Client.BlazorDemo.Components.Pages
{
    public partial class CurrencyUnits
    {
        [Inject]
        private IMnbClient MnbClient { get; set; }

        private string currencyCodes { get; set; }

        private List<CurrencyUnitResult> items = [];
        private bool hasData = false;

        private async Task LoadData()
        {
            this.items = await MnbClient.GetCurrencyUnitsAsync(this.currencyCodes?.Split(',')?.ToList() ?? []);
            this.hasData = this.items?.Count > 0;
        }
    }
}
