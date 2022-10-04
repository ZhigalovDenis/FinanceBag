
using System.Xml.Linq;

namespace Test
{
    public class GetPriceApiMoexFromXmlProd
    {

        decimal Value = 0;
        string TradingMode = "TQBR";
        string Tiker = "GAZP";
        List<string> DataBase = new List<string> { "TQBR", "TQBR", "TQTF", "TQTF", "TQIF", 
                                                   "YNDX", "GAZP", "EQMX", "VTBR", "RU000A0JR2C1" };

        public async Task GetPrice()
        {
            using (var Client = new HttpClient())
            {
                for (int i = 0; i < 5; i++)
                {
                    string Uri = "https://iss.moex.com/iss/engines/stock/markets/shares/boards/" +
                        DataBase[i] +
                        "/securities/" +
                        DataBase[i+5] +
                        "?iss.meta=off&iss.only=marketdata&marketdata.columns=LAST";
                    string ResponseBody = await Client.GetStringAsync(Uri);
                    XDocument Doc = XDocument.Parse(ResponseBody);
                    string? HandleDoc = Doc.Element("document").Element("data")
                                                            .Element("rows")
                                                            .Element("row").Attribute("LAST").Value.ToString();
                    if (HandleDoc != "")
                    {
                        HandleDoc = HandleDoc.Replace('.', ',');
                        Value = Convert.ToDecimal(HandleDoc);
                        Console.WriteLine("Результат работы класса GetPriceApiMoexFromXmlProd = " + Value);
                    }
                    else
                    {
                        Console.WriteLine("Результат работы класса GetPriceApiMoexFromXmlProd = нет данных");
                    }
                }
            }                   
        }
    }
}
