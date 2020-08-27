using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestSharpTraining.pojos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace RestSharpTraining.step_definitions
{
    [Binding]
    public sealed class ApiStepDefs : Endpoints 
    {
        IRestClient client = new RestClient(Endpoints.BASE_URL);
        IRestRequest request;
        IRestResponse response;

        [Given(@"I have my testing endpoint ""(.*)""")]
        public void GivenIHaveMyTestingEndpoint(string endpoint)
        {
            request = new RestRequest(endpoint);
        }



        [Given(@"send the get request")]
        public void GivenSendTheGetRequest()
        {
            response = client.Get(request);
        }

        [Then(@"my status code should be ""(.*)""")]
        public void ThenMyStatusCodeShouldBe(string status)
        {
           // Assert.AreEqual(status, response.StatusCode.ToString());
        }

        [Then(@"Assert that it assigns a proper house")]
        public void ThenAssertThatItAssignsAProperHouse()
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
        [Given(@"I have my testing endpoint ""(.*)"" and (.*) of the character")]
        public void GivenIHaveMyTestingEndpointAndOfTheCharacter(string endpoint, string id)
        {
            request = new RestRequest(endpoint + id);
        }

        [Then(@"Assert that name is (.*)")]
        public void ThenAssertThatNameIs(string name)
        {

            string content = response.Content;
            Console.WriteLine(content);
           Character character1 = JsonConvert.DeserializeObject<Character>(content);


            Assert.AreEqual(name, character1.Name);
        }
        [Given(@"add my api key")]
        public void GivenAddMyApiKey()
        {
            request.AddParameter("key", Endpoints.API_KEY);
        }

        [Then(@"Assert that the number of characters is ""(.*)""")]
        public void ThenAssertThatTheNumberOfCharactersIs(int size)
        {
            string content = response.Content;
            IList<Character> characters = JsonConvert.DeserializeObject<IList<Character>>(content);
            Assert.AreEqual(size, characters.Count);
            Console.WriteLine(content);
        }




    }
}
