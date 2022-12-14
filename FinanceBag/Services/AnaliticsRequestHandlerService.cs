using FinanceBag.Models;
using FinanceBag.ViewModel;

namespace FinanceBag.Services
{
    public class AnaliticsRequestHandlerService : IAnaliticsRequestHandlerService<AnaliticsViewModel, TypeOfActive>
    {
        private Dictionary<int, string> dictionaryDB = new Dictionary<int, string>();

        private List<string> Ticker = new List<string>();
        private List<string> ISIN = new List<string>();
        private List<string> TradingMode = new List<string>();
        private List<int> Count = new List<int>();
        private List<string> Type = new List<string>();
        private List<decimal> Sum = new List<decimal>();
        private List<decimal> Avg = new List<decimal>();

        /// <summary>
        /// Мотод обработки данных для виртуальной модели
        /// </summary>
        /// <param name="data0"></param>
        /// <param name="data1"></param>
        /// <returns></returns>
        public async Task<AnaliticsViewModel> ExToVM(IEnumerable<dynamic> data0, IEnumerable<TypeOfActive> data1)
        {
            return await Task.Run(() =>
            {
                foreach (var item in data1)
                {
                    dictionaryDB.Add(item.TypeOfActive_id, item.Type);
                }

                foreach (var item in data0)
                {
                    Type.Add(dictionaryDB[item.Type]);
                    Ticker.Add(item.Ticker);
                    ISIN.Add(item.ISIN);
                    Count.Add(item.Count);
                    Sum.Add(item.Sum);
                    Avg.Add(Math.Round(item.Avg, 2));
                    TradingMode.Add(item.TradingMode);
                }

                AnaliticsViewModel analiticsViewModel = new AnaliticsViewModel();

                analiticsViewModel.vM_Type = Type;
                analiticsViewModel.vM_Ticker = Ticker;
                analiticsViewModel.vM_ISIN = ISIN;
                analiticsViewModel.vM_Count = Count;
                analiticsViewModel.vM_Sum = Sum;
                analiticsViewModel.vM_Avg = Avg;
                analiticsViewModel.vM_TradingMode = TradingMode;

                return analiticsViewModel;
            });
        }
    }
}
