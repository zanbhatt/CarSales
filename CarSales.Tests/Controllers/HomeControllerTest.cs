using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarSales;
using CarSales.Controllers;
using CarSales.Models;
using CarSales.Services;
using Moq;
using CarSales.DAL;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace CarSales.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        
        public void Redirects_To_Car_If_Car_Selected()
        {
            // Arrange
            var mock = new Mock<IVehicleManager>();            
            HomeController controller = new HomeController(mock.Object);
            mock.Setup(x => x.GetTypes()).Returns(new List<SelectListItem>());
            VehicleType type = new VehicleType { Id = 1, Type = "Car" };

            // Act
            ViewResult result = controller.Create(type) as ViewResult;
            
            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Shows_Message_If_Car_Is_Not_Selected()
        {
            // Arrange
            var mock = new Mock<IVehicleManager>();
            HomeController controller = new HomeController(mock.Object);
            mock.Setup(x => x.GetTypes()).Returns(new List<SelectListItem>());
            VehicleType vtype = new VehicleType { Id = 2, Type = "Bus" };

            // Act
            ViewResult result = controller.Create(vtype) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("This feature is not available.", result.ViewBag.Message);
        }
    }
}
