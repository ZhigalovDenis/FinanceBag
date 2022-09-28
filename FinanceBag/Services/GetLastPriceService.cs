using NuGet.Protocol;
using System;

namespace FinanceBag.Services
{
    public class GetLastPriceService : IGetLastPriceService
    {
        int i = 0;
        private readonly HttpClient client = new HttpClient();
        string uri = "https://iss.moex.com/iss/engines/stock/markets/shares/securities/SBER/?iss.only=marketdata&marketdata.columns=SECID,BOARDID,LAST";
        public async Task GetLastPrice()
        {
            int position = 0;   
            string responseBody = await client.GetStringAsync(uri);
           position = responseBody.IndexOf("TQBR");
           i++;
        }
    }
}


