﻿using System;
using Fitness.BL.Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fitness.BLTests.Controller {

    [TestClass()]
    public class UserControllerTests {

        [TestMethod()]
        public void SaveTest() {
            var userName = Guid.NewGuid().ToString();
            var controller = new UserController(userName);

            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }

        [TestMethod()]
        public void SetNewUserDataTest() {

           //Arrage
           var userName = Guid.NewGuid().ToString();
           var birthdate = DateTime.Now.AddYears(-18);
           var weight = 90;
           var height = 190;
           var gender = "man";
           var controller = new UserController(userName);
           //Act
           controller.SetNewUserData(gender, birthdate, weight, height);
           var controller2 = new UserController(userName);
           //Assert
           Assert.AreEqual(userName, controller2.CurrentUser.Name);
           Assert.AreEqual(birthdate, controller2.CurrentUser.BirthDay);
           Assert.AreEqual(weight, controller2.CurrentUser.Weight);
           Assert.AreEqual(height, controller2.CurrentUser.Height);
           Assert.AreEqual(gender, controller2.CurrentUser.Gender.Name);
            
        }
    }
}