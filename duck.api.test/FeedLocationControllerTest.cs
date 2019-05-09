using System;
using System.Collections.Generic;
using duck.api.Controllers;
using duck.model;
using duck.model.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace duck.api.test
{
    [TestClass]
    public class FeedLocationControllerTest
    {
        [TestMethod]
        public void FeedLocationControllerGet()
        {
            var controller = new FeedLocationController();
            var result = controller.Get() as List<FeedLocation>;

            FeedLocationModel FeedLocationModel = new FeedLocationModel();

            Assert.AreEqual(FeedLocationModel.GetFeedLocations().Count, result.Count);
        }
    }
}
