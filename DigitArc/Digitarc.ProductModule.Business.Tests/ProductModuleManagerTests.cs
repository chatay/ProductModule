using DigitArc.ProductModule.Business.Logic;
using DigitArc.ProductModule.DataAccess.DatabaseLogic;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Digitarc.ProductModule.Business.Tests
{
    [TestClass]
    public class ProductModuleManagerTests
    {
        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void TestMethod1()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            ProductModuleManager productModuleManager = new ProductModuleManager(mock.Object);
            productModuleManager.Add(new DigitArc.ProductModule.Entities.Models.Product());
        }
    }
}
