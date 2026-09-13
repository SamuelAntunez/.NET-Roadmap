using DesignPatterns.Repository;

namespace DesignPatternASP.Strategies
{
    public interface IBeerStrategy
    {
        public void Add(FormBeerViewModel beerVM, IUnitOfWork unitOfWork);
    }
}
