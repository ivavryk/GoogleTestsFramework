using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RestSharp;

namespace APITests
{
    [TestFixture]
    class API
    {
        [Test]
        public void GETCurrentWeatherDataOfALocation()
        {
            var client = new RestClient("https://weatherbit-v1-mashape.p.rapidapi.com/current?lang=en&lon=%3Crequired%3E&lat=%3Crequired%3E");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "weatherbit-v1-mashape.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "SIGN-UP-FOR-KEY");
            IRestResponse response = client.Execute(request);
            Assert.IsTrue(response.IsSuccessful, "Error!");
        }
    }
}
