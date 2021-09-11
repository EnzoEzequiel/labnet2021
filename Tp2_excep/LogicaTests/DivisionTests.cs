using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Tests
{
    [TestClass()]
    public class DivisionTests
    {

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ThrowExceptionTest()
        {
            //Arrange
            Logic exception = new Logic();
            //Act
            exception.ThrowException();
            //Assert en ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(NegativeException))]
        public void ThrowNoEsParExceptionTest()
        {
            //Arrange
            Logic exception = new Logic();
            string customMsg = "Mensaje Customized";
            int numero = -1;

            //Act
            exception.ThrowExceptionCustomized(customMsg, numero);
            //Assert en ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivisionPorCeroTest()
        {
            //Arrange
            Division dm = new Division();
            int numero = 2;

            //Act
            dm.DivisionPorCero(numero);
            //Assert en ExpectedException
        }

        [TestMethod()]
        public void DivisionIngresadoTest()
        {
            //Arrange
            Division div = new Division();
            int dividendo = 10;
            int divisor = 10;
            int resultadoEsperado = 1;

            //Act
            int resultado=div.DivisionIngresado(dividendo, divisor);
            
            //Assert
            Assert.AreEqual(resultado, resultadoEsperado);
        }

        
    }
}