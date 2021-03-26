using EntityFrameworkCoreMock;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TheProduct.Data;
using TheProduct.DataContracts;
using Xunit;

namespace TheProduct.Tests
{
    public class QueryDataPointsByIdTests
    {
        [Fact]
        public async Task QueryByValidId_Returns200WithResult()
        {
            var id = Guid.NewGuid();
            var value = 0;

            using (var server = new TestServer(new WebHostBuilder().UseStartup<TestStartup>()))
            using (var client = server.CreateClient())
            using (var scope = server.Services.CreateScope())
            {
                scope.ServiceProvider
                    .GetRequiredService<DbContextMock<ProductContext>>()
                    .CreateDbSetMock(db => db.DataPoints, new[] { new DataPoint() { Id = id, Value = value } });

                var request = new HttpRequestMessage(HttpMethod.Get, $"/api/datapoints/{id}");
                var response = await client.SendAsync(request);

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                var responseBody = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<DataPointDto>(responseBody);

                Assert.Equal(id, responseObject.Id);
                Assert.Equal(value, responseObject.Value);
            }
        }

        [Fact]
        public async Task QueryByValidId_Returns404()
        {
            var id = Guid.NewGuid();

            using (var server = new TestServer(new WebHostBuilder().UseStartup<TestStartup>()))
            using (var client = server.CreateClient())
            using (var scope = server.Services.CreateScope())
            {
                scope.ServiceProvider
                    .GetRequiredService<DbContextMock<ProductContext>>()
                    .CreateDbSetMock(db => db.DataPoints, new[] { new DataPoint() { Id = id, Value = 0 } });

                var request = new HttpRequestMessage(HttpMethod.Get, $"/api/datapoints/{Guid.NewGuid()}");
                var response = await client.SendAsync(request);

                Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            }
        }
    }
}
