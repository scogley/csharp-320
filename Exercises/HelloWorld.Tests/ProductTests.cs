using NUnit.Framework;
using Microsoft.Extensions.Options;
using HelloWorldASP_MVC.Controllers;
using HelloWorldASP_MVC.Models;
using System.Linq;

namespace HelloWorld.Tests
{
    public class ProductTests
    {
        [Test]
        public void TestMethodWithFakeClass()
        {
            // Arrange - set up your test
            //var optionsMyJsonSettings = Options.Create(new MyJsonSettings());
            //var optionsSecondJson = Options.Create(new SecondJson());

            var controller = new HomeController(new FakeProductRepository()/*, optionsMyJsonSettings, optionsSecondJson*/);

            // Act - execute the code that you are testing
            // We want to test how many products we "display"
            var result = controller.Products();

            // Assert - verify the results
            var products = (Product[])((Microsoft.AspNetCore.Mvc.ViewResult)(result)).Model;
            Assert.AreEqual(5, products.Length, "Length is invalid");

            // 3 products with price > $10 and 2 with price < $10
            Assert.GreaterOrEqual(products.Where(t => t.Price > 10).Count(), 3);
            Assert.GreaterOrEqual(products.Where(t => t.Price < 10).Count(), 2);
        }
    }
}