using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using duck.api.Controllers;
using duck.model;
using duck.model.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace duck.api.test
{
    [TestClass]
    public class DuckFeedControllerTest
    {
        [TestMethod]
        public void DuckFeedControllerGet()
        {
            var controller = new DuckFeedController();
            var result = controller.Get() as List<DuckFeeding>;

            DuckFeedingModel duckFeedingModel = new DuckFeedingModel();

            Assert.AreEqual(duckFeedingModel.GetDuckFeedings().Count, result.Count);
        }

        [TestMethod]
        public void DuckFeedControllerPostWithRecurringSchedule()
        {
            var controller = new DuckFeedController
            {

                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()

            };
            var currentCount = controller.Get() as List<DuckFeeding>;

            DuckFeedingModel duckFeedingModel = new DuckFeedingModel();
            DateTime dateTime = DateTime.Now;

            DuckFeeding df = new DuckFeeding {
                AmountOfFood = 3,
                EmailAddress ="abc@test.com",
                FeedLocationID = 1,
                IsRecurring = true,
                NumberOfDucks = 10,
                Time = $"{dateTime.Hour.ToString()}:{dateTime.Minute.ToString()}",
                FoodType = "Vegetable"
            };

            var postResponse = Convert.ToInt32(controller.Post(df));

            var addRecordCount = controller.Get() as List<DuckFeeding>;
            Assert.AreEqual(addRecordCount.Count+1, currentCount.Count+ postResponse);
        }
    }
}
