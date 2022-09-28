
namespace Test
{
    public class GetPriceApiMoexFromString
    {
        private List<string> ListOfString = new List<string>();
        private readonly char[] CharsToRemove = { '<', ' ', '"', '/', '>', '='};
        decimal Value = 0;

        public async Task GetPrice()
        {
            using (var Client = new HttpClient())
            {
                string Uri = "https://iss.moex.com/iss/engines/stock/markets/shares/securities/YNDX/?iss.only=marketdata&marketdata.columns=SECID,BOARDID,LAST";
                string ResponseBody = await Client.GetStringAsync(Uri);
                ListOfString = ResponseBody.Split('\n').ToList();
                int PosOfStr = ListOfString.FindIndex(x => x.Contains("TQBR"));
                string GetStr = ListOfString[PosOfStr];
                foreach (var c in CharsToRemove)
                {

                    GetStr = GetStr.Replace(c, ';');
                    GetStr = GetStr.Replace(";", "");
                }
                int StartIndex = GetStr.IndexOf("LAST") + 4;
                GetStr = GetStr.Substring(StartIndex, GetStr.Length - StartIndex);
                if(GetStr != "")
                {
                    GetStr = GetStr.Replace('.', ',');
                    Value = Convert.ToDecimal(GetStr);
                    Console.WriteLine("Результат работы класса GetPriceApiMoexFromString = " + Value);
                }
                else
                {
                    Console.WriteLine("Результат работы класса GetPriceApiMoexFromString = нет данных");
                }          
            }
        }
    }
}
