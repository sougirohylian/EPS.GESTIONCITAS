using EPS.GESTIONCITAS.PERSONAS.WEBSERVICE;
using EPS.GESTIONCITAS.PERSONAS.WEBSERVICE.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace EPS.GESTIONCITAS.PERSONAS.WEBSERVICE.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Disponer
            HomeController controller = new HomeController();

            // Actuar
            ViewResult result = controller.Index() as ViewResult;

            // Declarar
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
