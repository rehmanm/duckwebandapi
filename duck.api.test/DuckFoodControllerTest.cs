using System;
using System.Collections.Generic;
using duck.api.Controllers;
using duck.model;
using duck.model.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace duck.api.test
{
    [TestClass]
    public class DuckFoodControllerTest
    {
        [TestMethod]
        public void DuckFoodControllerGet()
        {
            var controller = new DuckFoodController();
            var result = controller.Get() as List<DuckFood>;

            DuckFoodModel duckFoodModel = new DuckFoodModel();

            Assert.AreEqual(duckFoodModel.GetDuckFoods().Count, result.Count);
        }
    }
}
