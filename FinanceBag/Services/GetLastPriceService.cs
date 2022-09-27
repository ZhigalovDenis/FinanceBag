using System;

namespace FinanceBag.Services
{
    public class GetLastPriceService : IGetLastPriceService
    {
        private readonly HttpClient client = new HttpClient();
        string uri = "https://iss.moex.com/iss/engines/stock/markets/shares/securities/SBER/?iss.only=marketdata&marketdata.columns=SECID,BOARDID,LAST";
        public async Task GetLastPrice()
        {
            string responseBody = await client.GetStringAsync(uri);
        }
    }
}


