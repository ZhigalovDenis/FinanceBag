using FinanceBag.ViewModel;

namespace FinanceBag.Services
{
    public class CalculateService : ICalculateService<AnaliticsViewModel>
    {
        public async Task<AnaliticsViewModel> CalculateProfit(AnaliticsViewModel model)
        {
            List<decimal> ProfitOfActive = new List<decimal>();
            List<decimal> ProfitOfAllActive = new List<decimal>();

            for (int i = 0; i < model.vM_Count.Count; i++)
            {
                decimal profitOfActive =   model.vM_CurrentPrice[i] - model.vM_Avg[i];
                decimal profitOfAllActive = (model.vM_Count[i] * model.vM_CurrentPrice[i]) - model.vM_Sum[i];
                ProfitOfActive.Add(profitOfActive);
                ProfitOfAllActive.Add(profitOfAllActive);
            }
            model.vM_ProfitOfActive = ProfitOfActive;
            model.vM_ProfitOfAllActive =  ProfitOfAllActive;

            return  model;  
        }
    }
}
