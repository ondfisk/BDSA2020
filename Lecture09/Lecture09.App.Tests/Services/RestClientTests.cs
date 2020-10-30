using Lecture09.App.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Lecture09.App.Tests.Services
{
    public class RestClientTests
    {
        [Fact]
        public async Task GetAllAsync_given_resource_returns_converted()
        { 
            var resource = "https://foo.bar";

            var json = "[{\"id\":1,\"name\":\"foo\"},{\"id\":2,\"name\":\"bar\"}]";

            var handler = new HttpMessageHandlerStub { StatusCode = HttpStatusCode.OK, Content = json };
            var httpClient = new HttpClient(handler);
            var client = new RestClient(httpClient);

            var response = await client.GetAllAsync<TestType>(resource);

            Assert.Collection(response,
                d => { Assert.Equal(1, d.Id); Assert.Equal("foo", d.Name); },
                d => { Assert.Equal(2, d.Id); Assert.Equal("bar", d.Name); });
        }

        [Fact]
        public async Task GetAsync_given_resource_returns_converted()
        {
            var resource = "https://foo.bar";

            var json = "{\"id\":1,\"name\":\"foo\"}";

            var handler = new HttpMessageHandlerStub { StatusCode = HttpStatusCode.OK, Content = json };
            var httpClient = new HttpClient(handler);
            var client = new RestClient(httpClient);

            var response = await client.GetAsync<TestType>(resource);

            Assert.Equal(1, response.Id);
            Assert.Equal("foo", response.Name);
        }

        [Fact]
        public async Task PostAsync_given_resource_returns_location()
        {
            var resource = "https://foo.bar";
            var type = new TestType();

            var handler = new HttpMessageHandlerStub { StatusCode = HttpStatusCode.Created, Location = new Uri("https://foo.bar/data/2") };
            var httpClient = new HttpClient(handler);
            var client = new RestClient(httpClient);

            var response = await client.PostAsync(resource, type);

            Assert.Equal(new Uri("https://foo.bar/data/2"), response);
        }

        [Fact]
        public async Task PutAsync_given_NoContent_returns_true()
        {
            var resource = "https://foo.bar";
            var type = new TestType();

            var handler = new HttpMessageHandlerStub { StatusCode = HttpStatusCode.NoContent };
            var httpClient = new HttpClient(handler);
            var client = new RestClient(httpClient);

            var response = await client.PutAsync(resource, type);

            Assert.True(response);
        }

        [Fact]
        public async Task PutAsync_given_Conflict_returns_false()
        {
            var resource = "https://foo.bar";
            var type = new TestType();

            var handler = new HttpMessageHandlerStub { StatusCode = HttpStatusCode.Conflict };
            var httpClient = new HttpClient(handler);
            var client = new RestClient(httpClient);

            var response = await client.PutAsync(resource, type);

            Assert.False(response);
        }

        [Fact]
        public async Task DeleteAsync_given_NoContent_returns_true()
        {
            var resource = "https://foo.bar";

            var handler = new HttpMessageHandlerStub { StatusCode = HttpStatusCode.NoContent };
            var httpClient = new HttpClient(handler);
            var client = new RestClient(httpClient);

            var response = await client.DeleteAsync(resource);

            Assert.True(response);
        }

        [Fact]
        public async Task DeleteAsync_given_Conflict_returns_false()
        {
            var resource = "https://foo.bar";

            var handler = new HttpMessageHandlerStub { StatusCode = HttpStatusCode.Conflict };
            var httpClient = new HttpClient(handler);
            var client = new RestClient(httpClient);

            var response = await client.DeleteAsync(resource);

            Assert.False(response);
        }

        class TestType
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        class HttpMessageHandlerStub : HttpMessageHandler
        {
            public HttpStatusCode StatusCode { get; set; }
            public string Content { get; set; }
            public Uri Location { get; set; }

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                var response = new HttpResponseMessage(StatusCode);

                if (!string.IsNullOrWhiteSpace(Content))
                {
                    response.Content = new StringContent(Content, Encoding.UTF8, "application/json");
                }

                response.Headers.Location = Location;

                return await Task.FromResult(response);
            }
        }
    }
}
