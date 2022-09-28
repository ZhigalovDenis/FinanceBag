
using System.Xml.Linq;

namespace Test
{
    public class GetPriceApiMoexFromXml
    {
        decimal Value = 0;

        public async Task GetPrice()
        {
            using (var Client = new HttpClient())
            {
                string Uri = "https://iss.moex.com/iss/engines/stock/markets/shares/securities/YNDX/?iss.only=marketdata&marketdata.columns=SECID,BOARDID,LAST";
                string ResponseBody = await Client.GetStringAsync(Uri);
                XDocument Doc = XDocument.Parse(ResponseBody);
                var HandleDoc = Doc.Element("document").Element("data")
                                                        .Element("rows")
                                                        .Elements("row").Select(x => new
                                                         {
                                                             BoardID = x.Attribute("BOARDID").Value,
                                                             Last = x?.Attribute("LAST").Value
                                                         }).Where(x => x.BoardID == "TQBR").Select(x => x.Last).ToArray();
                string GetStr = HandleDoc[0];
                if (GetStr != "")
                {
                    GetStr = GetStr.Replace('.', ',');
                    Value = Convert.ToDecimal(GetStr);
                    Console.WriteLine("Результат работы класса GetPriceApiMoexFromXml = " + Value);
                }
                else
                {
                    Console.WriteLine("Результат работы класса GetPriceApiMoexFromXml = нет данных");
                }
            }
        }
    }
}
