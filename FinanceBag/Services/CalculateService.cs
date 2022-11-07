using FinanceBag.ViewModel;

namespace FinanceBag.Services
{
    public class CalculateService : ICalculateService<AnaliticsViewModel>
    {
        public async Task<AnaliticsViewModel> CalculateProfit(AnaliticsViewModel model)
        {
           return await Task.Run(() =>
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

                model.vM_TotalCosts = model.vM_Sum.Sum();
                model.vM_ProfitValue = Math.Round(model.vM_ProfitOfAllActive.Sum(),2);

                return  model;

            });
        }


    }
}
