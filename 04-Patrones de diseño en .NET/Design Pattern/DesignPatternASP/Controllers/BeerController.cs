using DesignPatternASP.Models.ViewModels;
using DesignPatternASP.Strategies;
using DesignPatterns.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DesignPatternASP.Controllers
{
    public class BeerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public BeerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<BeerViewModel> beers = from d in _unitOfWork.Beers.GetAll()
                                               select new BeerViewModel
                                               {
                                                   Id = d.BeerId,
                                                   Name = d.Name,
                                                   Style = d.Style
                                               };

            return View("Index", beers);
        }

        public void GetBrandsData()
        {
            var brands = _unitOfWork.Brands.GetAll();
            ViewBag.Brands = new SelectList(brands, "BrandId", "Name");
        }

        public IActionResult Add(FormBeerViewModel beerVM)
        {
            var context = beerVM.BrandId == null ? new BeerContext(new BeerWithBrandStrategy()) : new BeerContext(new BeerStrategy());
            context.Add(beerVM, _unitOfWork);

            return RedirectToAction("Index");
        }
    }
}
