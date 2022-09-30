using FinanceBag.ViewModel;
using Newtonsoft.Json.Linq;
using NuGet.Protocol;
using System;
using System.Xml;
using System.Xml.Linq;

namespace FinanceBag.Services
{
    public class GetLastPriceService : IGetLastPriceService<AnaliticsViewModel>
    {
        /// <summary>
        /// Метод получения последней цены акции
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<AnaliticsViewModel> GetLastPrice(AnaliticsViewModel model)
        {
            decimal Value = 0;
            List<decimal> CurrentPrice = new List<decimal>();  

            using (var Client = new HttpClient())
            {
                for (int i = 0; i < model.vM_Count.Count; i++)
                {
                    string Uri = "https://iss.moex.com/iss/engines/stock/markets/shares/boards/" +
                    model.vM_TradingMode[i].Trim('\t') +
                    "/securities/" +
                    model.vM_Ticker[i].Trim('\t') +
                    "?iss.meta=off&iss.only=marketdata&marketdata.columns=LAST";

                    string ResponseBody = await Client.GetStringAsync(Uri);
                    XDocument Doc = XDocument.Parse(ResponseBody);
                    string HandleDoc = Doc.Element("document").Element("data")
                                                            .Element("rows")
                                                            .Element("row").Attribute("LAST").Value.ToString();
                    if (HandleDoc != "")
                    {
                        CurrentPrice.Add(Convert.ToDecimal(HandleDoc));
                    }
                    else
                    {
                        CurrentPrice.Add(Value);
                    }
                    model.vM_CurrentPrice = CurrentPrice;
                }

                return model;
            }
        }
    }
}


