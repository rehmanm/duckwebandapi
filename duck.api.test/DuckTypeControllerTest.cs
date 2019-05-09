using System;
using System.Collections.Generic;
using duck.api.Controllers;
using duck.model;
using duck.model.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace duck.api.test
{
    [TestClass]
    public class DuckTypeControllerTest
    {
        [TestMethod]
        public void DuckTypeControllerGet()
        {
            var controller = new DuckTypeController();
            var result = controller.Get() as List<DuckType>;

            DuckTypeModel duckTypeModel = new DuckTypeModel();

            Assert.AreEqual(duckTypeModel.GetDuckTypes().Count, result.Count);
        }
    }
}
