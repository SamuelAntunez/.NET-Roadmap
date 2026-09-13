using Microsoft.AspNetCore.Mvc;
using Tools.Earn;

namespace DesignPatternASP.Controllers
{
    public class ProductDetailController : Controller
    {
        private EarnFactory _localEarnFactory;

        public ProductDetailController(LocalEarnFactory localEarnFactory)
        {
            _localEarnFactory = localEarnFactory;
        }
        public IActionResult Index(decimal total)
        {
            // Factories
            ForeignEarnFactory foreignEarnFactory = new ForeignEarnFactory(0.20m, 10);

             // Products
            var localEarn = _localEarnFactory.GetEarn();
            var foreignEarn = foreignEarnFactory.GetEarn();

            //total
            ViewBag.totalLocal = total + localEarn.Earn(400);
            ViewBag.totalForeign = total + foreignEarn.Earn(400);



            return View();

        }
    }
}
