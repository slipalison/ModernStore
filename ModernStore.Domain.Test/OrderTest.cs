using ModernStore.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ModernStore.Domain.Test
{
    public class OrderTest
    {
        private readonly List<Product> _listProduct;
        private readonly User _user;
        private readonly Custumer _custumer;
        private readonly Order _order;

        public OrderTest()
        {
            _user = new User("slipalison", "slipalison");
            _custumer = new Custumer("Alison", "Amorim", _user, "alison@alison.com");
            _listProduct = new List<Product> {
                new Product("Mouse", 1000.00M, 20, "rog_spatha.jpg"),
                new Product("MousePad", 400.00M, 100, "rog_sheath.jpg"),
                new Product("teclado", 1000.00M, 50, "corsair_k90.jpg"),
            };
            _order = new Order(_custumer, 10.90M, 10.90M);
        }

        [Fact, Trait("Order", "New Order")]
        public void GivenAnOutOfStockProductShouldReturnAnError()
        {
            _order.AddItem(new OrderItem(_listProduct.FirstOrDefault(x => x.Title == "Mouse"), 23));
            Assert.False(_order.IsValid());
        }

        [Fact, Trait("Order", "New Order")]
        public void GivenAnStockProductItShouldUpdateQuantityOnHand()
        {
            _order.AddItem(new OrderItem(_listProduct.FirstOrDefault(x => x.Title == "Mouse"), 2));
            Assert.True(_listProduct.FirstOrDefault(x => x.Title == "Mouse").QuantityOnHand == 18);
        }

        [Fact, Trait("Order", "New Order")]
        public void GivenAValidOrderTheTotalShould2000()
        {
            _order.AddItem(new OrderItem(_listProduct.FirstOrDefault(x => x.Title == "Mouse"), 2));
            Assert.True(_order.Total()==2000);
        }
    }
}
