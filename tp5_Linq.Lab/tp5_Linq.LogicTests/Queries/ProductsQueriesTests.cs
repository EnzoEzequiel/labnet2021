using Microsoft.VisualStudio.TestTools.UnitTesting;
using tp5_Linq.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp5_Linq.Entities;

namespace tp5_Linq.Logic.Tests
{
    [TestClass()]
    public class ProductsQueriesTests
    {
        [TestMethod()]
        public void UnitPriceGreaterTest()
        {
            List<Products> productos = new List<Products>()
            {
                new Products{UnitsInStock=2,UnitPrice=4},
                new Products{UnitsInStock=4,UnitPrice=5},
                new Products{UnitsInStock=0,UnitPrice=0},
                new Products{UnitsInStock=6,UnitPrice=7},
                new Products{UnitsInStock=0,UnitPrice=0}
            };
            List<Products> resultado = (productos.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3)).ToList();

            List<Products> productosEsperados = new List<Products>()
            {
                new Products{UnitsInStock=2,UnitPrice=4},
                new Products{UnitsInStock=4,UnitPrice=5},
                new Products{UnitsInStock=6,UnitPrice=7}
            };

            CollectionAssert.AreEqual(productosEsperados.ToArray(), resultado.ToArray());
        }
    }
}