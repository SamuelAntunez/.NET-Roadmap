using DesignPatterns.Models.Models;
using DesignPatterns.Repository;

namespace DesignPatternASP.Strategies
{
    public class BeerStrategy : IBeerStrategy
    {
        public void Add(FormBeerViewModel beerVM, IUnitOfWork unitOfWork)
        {
            var beer = new Beer()
            {
                Name = beerVM.Name,
                Style = beerVM.Style,
                BrandId = (Guid)beerVM.BrandId
            };
            unitOfWork.Beers.Add(beer);
            unitOfWork.Save();
        }
    }
}
