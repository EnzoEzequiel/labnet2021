using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.EF;

namespace Logic.EF.Tests
{
    [TestClass()]
    public class SuppliersLogicTests:BaseLogic
    {
        [TestMethod]
        public void EncontrarTest()
        {
            //Arrange
            int supplier = 30;
            Suppliers resultado;

            //Act
            resultado=context.Suppliers.Find(supplier);

            //Assert
            Assert.AreEqual(resultado, null);

        }
    }
}