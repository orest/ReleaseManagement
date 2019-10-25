using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReleaseManagement.Controllers;
using ReleaseManagement.Core.Models;

namespace ReleaseManagement.Test {
    [TestClass]
    public class ClientControllerTest {

        [TestMethod]
        public void get_clients_returns_data() {
            //Arrange
            var clientController = new ClientsController();

            //Act 
            var response = clientController.GetClients() as OkNegotiatedContentResult<List<Client>>; ;

            //Assert
            Assert.IsNotNull(response);
            List<Client> clientList = response.Content;
            Assert.IsTrue(clientList.Any());

        }

        [TestMethod]
        public void get_client_by_id() {
            //Arrange
            var clientId = 4;
            var clientController = new ClientsController();

            //Act 
            var response = clientController.GetClient(clientId) as OkNegotiatedContentResult<Client>; ;

            //Assert
            Assert.IsNotNull(response);
            var client = response.Content;
            Assert.AreEqual(client.ClientId, clientId);
        }

        [TestMethod]
        public void get_create_client() {
            //Arrange
            var newClient = new Client {
                ClientName = "Vasya",
                IsActive = true,
                ImageUrl = "ImageUrl"
            };

            var clientController = new ClientsController();

            //Act 
            var response = clientController.PostClient(newClient) as CreatedAtRouteNegotiatedContentResult<Client>; ;

            //Assert
            Assert.IsNotNull(response);
            var client = response.Content;
            Assert.IsTrue(client.ClientId > 0);

            clientController = new ClientsController();
            var validateResult= clientController.GetClient(client.ClientId) as OkNegotiatedContentResult<Client>; 
            Assert.IsNotNull(validateResult);
            
            Assert.AreEqual(validateResult.Content.ClientName, newClient.ClientName);
            Assert.AreEqual(validateResult.Content.IsActive, newClient.IsActive);
            Assert.AreEqual(validateResult.Content.ImageUrl, newClient.ImageUrl);
        }

    }
}
