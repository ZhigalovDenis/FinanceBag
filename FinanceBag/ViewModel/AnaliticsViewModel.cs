
using FinanceBag.Models;

namespace FinanceBag.ViewModel
{
    public class AnaliticsViewModel
    {
        public List<string> vM_Type { get; set; }
        public List<string> vM_Ticker { get; set; }
        public List<string> vM_ISIN { get; set; }
        public List<int> Count { get; set; }
        public List<decimal> Sum { get; set; }
        public List<decimal> Avg { get; set; }
    }
}
