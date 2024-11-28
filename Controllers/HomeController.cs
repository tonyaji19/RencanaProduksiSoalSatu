using Microsoft.AspNetCore.Mvc;
using RencanaProduksiSoalSatu.Models;

namespace RencanaProduksiSoalSatu.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var plan = new ProductionPlan
            {
                Monday = 0,
                Tuesday = 0,
                Wednesday = 0,
                Thursday = 0,
                Friday = 0,
                ProduksiTerhitung = false
            };
            return View(plan);
        }

        [HttpPost]
        public IActionResult Index(ProductionPlan plan)
        {
            if (ModelState.IsValid)
            {
                var newPlan = BalanceProduction(plan);

                return View(newPlan);
            }

            return View(plan);
        }

        public ProductionPlan BalanceProduction(ProductionPlan plan)
        {
            var total = plan.Monday + plan.Tuesday + plan.Wednesday + plan.Thursday + plan.Friday;
            var average = total / 5;
            var remainder = total % 5;

            var days = new[] { plan.Monday, plan.Tuesday, plan.Wednesday, plan.Thursday, plan.Friday };
            var maxDays = days.OrderByDescending(x => x).Take(remainder).ToList();

            days = days.Select(day => maxDays.Contains(day) ? average + 1 : average).ToArray();

            return new ProductionPlan
            {
                Monday = days[0],
                Tuesday = days[1],
                Wednesday = days[2],
                Thursday = days[3],
                Friday = days[4],
                ProduksiTerhitung = true
            };
        }
    }
}
