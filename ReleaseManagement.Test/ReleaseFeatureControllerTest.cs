using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReleaseManagement.Controllers;
using ReleaseManagement.Core.Models;
using static ReleaseManagement.Common.Enums;

namespace ReleaseManagement.Test {
    [TestClass]
    public class ReleaseFeatureControllerTest {

        [TestMethod]
        public void get_release_fetures_returns_data() {
            //Arrange
            var clientController = new ReleaseFeaturesController();

            //Act 
            var response = clientController.GetReleaseFeatures() as OkNegotiatedContentResult<List<ReleaseFeature>>; ;

            //Assert
            Assert.IsNotNull(response);
            List<ReleaseFeature> releaseFeatures = response.Content;
            Assert.IsTrue(releaseFeatures.Any());

        }

        //[TestMethod]
        //public void get_client_by_id() {
        //    //Arrange
        //    var clientId = 4;
        //    var clientController = new ClientsController();

        //    //Act 
        //    var response = clientController.GetClient(clientId) as OkNegotiatedContentResult<Client>; ;

        //    //Assert
        //    Assert.IsNotNull(response);
        //    var client = response.Content;
        //    Assert.AreEqual(client.ClientId, clientId);
        //}

        [TestMethod]
        public void assign_feature_to_release() {
            //Arrange
            var model = new ReleaseFeature {
                FeatureId = 1,
                ReleaseId = 1,
                StatusCode = "new"
            };

            var controller = new ReleaseFeaturesController();

            //Act 
            var response = controller.PostReleaseFeature(model) as CreatedAtRouteNegotiatedContentResult<ReleaseFeature>; ;

            //Assert
            Assert.IsNotNull(response);
            var releaseFeature = response.Content;
            Assert.IsTrue(releaseFeature.ReleaseFeatureId > 0);


            Assert.AreEqual(model.ReleaseId, releaseFeature.ReleaseId);
            Assert.AreEqual(model.FeatureId, releaseFeature.FeatureId);

        }


        [TestMethod]
        public void update_release_feture_status() {
            //Arrange
            var id = 1;
            var controller = new ReleaseFeaturesController();
            var response = controller.GetReleaseFeature(id) as OkNegotiatedContentResult<ReleaseFeature>;
            Assert.IsNotNull(response);
            var releaseFeture = response.Content;
            Assert.IsNotNull(releaseFeture);

            releaseFeture.StatusCode = ReleaseFeatureStatusCodes.InProgress.ToString();

            controller.PutReleaseFeature(releaseFeture.ReleaseFeatureId, releaseFeture);

            controller = new ReleaseFeaturesController();
            response = controller.GetReleaseFeature(id) as OkNegotiatedContentResult<ReleaseFeature>;
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Content.StatusCode, ReleaseFeatureStatusCodes.InProgress.ToString());

        }

    }
}
