using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactProject.Controllers;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using Microsoft.Practices.Unity;
using ContactProject.Repository;
using ContactProject.Models;

namespace ContactProject.UnitTests
{
    [TestClass]
    public class Unittests
    {
        [TestInitialize]
        public void TestInitialize()
        {
             IUnityContainer container = new UnityContainer();
             container.RegisterType<IContactRepository, ContactRepository>();
             container.RegisterType<DbContext, MVCEntities>();
             container.RegisterType<Controller, MyController>();
           
        }

        [TestMethod]
        public void TestIndexviewRender()
        {
            // Arrange
            var myController = new MyController();

            // Act
            var Result = myController.Index() as ViewResult;

            //Assert
            Assert.IsTrue(Result.ViewName == "List of Contacts", "Incorrect view.");


        }


        [TestMethod]
        public void TestDetailsrviewRender()
        {
            // Arrange
            var myController = new MyController();

            // Act
            var Result = myController.Details(1) as ViewResult;

            //Assert
            Assert.IsTrue(Result.ViewName == "Details", "Incorrect view.");

        }
    }
}
