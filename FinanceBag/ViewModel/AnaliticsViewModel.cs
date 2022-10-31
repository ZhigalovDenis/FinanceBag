
using FinanceBag.Models;

namespace FinanceBag.ViewModel
{
    public class AnaliticsViewModel
    {
        public List<string> vM_Type { get; set; }
        public List<string> vM_Ticker { get; set; }
        public List<string> vM_ISIN { get; set; }
        public List<string> vM_TradingMode { get; set; }
        public List<int> vM_Count { get; set; }
        public List<decimal> vM_Sum { get; set; }
        public List<decimal> vM_Avg { get; set; }
        public List<decimal> vM_CurrentPrice { get; set; }
        public List<decimal> vM_ProfitOfActive { get; set; }
        public List<decimal> vM_ProfitOfAllActive { get; set; }
        public decimal vM_TotalCosts { get; set; }
        public decimal vM_ProfitValue { get; set; }
        public decimal vM_ProfitValue1 { get; set; }
    }
}
