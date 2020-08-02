using Accion.Model.Request;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Accion.Test
{
    public class IntegrationTest
    {
        HttpClient client;

        [SetUp]
        public async System.Threading.Tasks.Task SetupAsync()
        {
            // Arrange
            var hostBuilder = new HostBuilder()
                .ConfigureWebHost(webHost =>
                {
                    // Add TestServer
                    webHost.UseTestServer();
                    webHost.UseStartup<EmployeeMgmt.Startup>();
                });

            // Create and start up the host
            var host = await hostBuilder.StartAsync();

            // Create an HttpClient which is setup for the test host
            client = host.GetTestClient();
        }

        [Test]
        public async System.Threading.Tasks.Task IntegrationAsync()
        {
            var empRequest = new AddEmpRequest() { CoRelationId = Guid.NewGuid(), Employee = new Model.Business.EmpModel() { EmpName = "test" } };

            var json = JsonConvert.SerializeObject(empRequest);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/v1/employee/AddEmployee", data);

            // Assert
            var responseString = await response.Content.ReadAsStringAsync();
        }

    }
}
