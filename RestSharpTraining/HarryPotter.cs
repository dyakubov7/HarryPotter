using NUnit.Framework;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RestSharpTraining
{
   
    class HarryPotter
    {
        public const string apiKey = "$2a$10$acz0eQe5a76QO5wgZZ.piuUZZ.chuB2wObXDm7WIQjpkCBMJc6niK";
        IRestClient client = new RestClient("https://www.potterapi.com/v1/");

        string hannah = "5a0fa4daae5bc100213c232e";
        [SetUp]
        public void setup()
        {
            
        }
        [Test]
        public void sortingHat()
        {
            IRestRequest request = new RestRequest("/sortingHat", DataFormat.Json);
            IRestResponse response = client.Get(request);
            Console.WriteLine(response.Content);
            List<string> houses = new List<string>();
            houses.Add("Gryffindor");
            houses.Add("Ravenclaw");
            houses.Add("Slytherin");
            houses.Add("Hufflepuff");

            string actual = response.Content;
            actual = actual.Replace("\"", "");

            Console.WriteLine(actual);
            if (houses.Contains(actual))
                Assert.Pass();
            else
                Assert.Fail();
            
        }
        [Test]

        public void getCharacters()
        {
            IRestRequest request = new RestRequest("/characters").AddParameter("key",apiKey);
            IRestResponse response = client.Get(request);
            Assert.IsTrue(response.IsSuccessful);
            Assert.AreEqual("OK", response.StatusCode.ToString());

            Console.WriteLine(response.Content);

        }

        [Test]
        public void getAcharacter()
        {
            IRestRequest request = new RestRequest("/characters/" + hannah).AddParameter("key",apiKey);
            IRestResponse response = client.Get(request);
            Console.WriteLine(response.Content);


        }
    }
}
