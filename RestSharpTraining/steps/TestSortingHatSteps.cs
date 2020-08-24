using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace RestSharpTraining.steps
{
    [Binding]
    public class TestSortingHatSteps
    {
        public const string apiKey = "$2a$10$acz0eQe5a76QO5wgZZ.piuUZZ.chuB2wObXDm7WIQjpkCBMJc6niK";
        IRestClient client = new RestClient("https://www.potterapi.com/v1/");
        IRestResponse response;
        IRestRequest request;
        //string hannah = "5a0fa4daae5bc100213c232e";

        [Given(@"I set up all the variables")]
        public void GivenISetUpAllTheVariables()
        {
            request = new RestRequest("/sortingHat", DataFormat.Json);
        }
        
        [Given(@"send my get request")]
        public void GivenSendMyGetRequest()
        {
           response = client.Get(request);
        }
        
        [Then(@"status code should be ""(.*)""")]
        public void ThenStatusCodeShouldBe(string p0)
        {
            Assert.AreEqual(p0, response.StatusCode.ToString());
            Console.WriteLine(response.StatusCode);
        }
        
        [Then(@"Assert that you are assigned to one of the houses")]
        public void ThenAssertThatYouAreAssignedToOneOfTheHouses()
        {
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
    }
}
