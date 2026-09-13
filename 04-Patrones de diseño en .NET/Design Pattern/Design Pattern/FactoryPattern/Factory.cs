using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Pattern.FactoryPattern
{
    public abstract class SaleFactory // Esta clase abstracta sera el Creator
    {
        public abstract ISale GetSale();
    }

    public class StoreSaleFactory : SaleFactory // Este es el concrete Creator
    {
        private decimal _extra;

        public StoreSaleFactory(decimal extra)
        {
            _extra = extra;
        }
        public override ISale GetSale()
        {
            return new StoreSale(_extra);
        }
        
    }

    public class InternetSaleFactory : SaleFactory // Este es el concrete Creator
    {
        private decimal _discount;

        public InternetSaleFactory(decimal discount)
        {
            _discount = discount;
        }
        public override ISale GetSale()
        {
            return new InternetSale(_discount);
        }

    }
    public class StoreSale : ISale // Este es el producto concreto que se esta creando (Concrete Product)
    {
        private decimal _extra;

        public StoreSale(decimal extra)
        {
            _extra = extra;
        }
        public void Sell(decimal total)
        {
            Console.WriteLine($"Venta en tienda {total}");
        }
    }

    public class InternetSale : ISale // En caso de que quiera que el producto se venda por el internet
    {
        private decimal _discount;
        public InternetSale(decimal discount)
        {
            _discount = discount;
        }
        public void Sell(decimal total)
        {
            Console.WriteLine($"La venta en internet tiene un total de {total - _discount}");
        }
    }
    public interface ISale // Esta interfaz es el producto
    {
        public void Sell(decimal total);
    }
}
