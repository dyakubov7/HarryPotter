using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using RestSharp;
using RestSharpTraining.pojos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace RestSharpTraining.step_definitions
{
    [Binding]
    public sealed class ApiStepDefs
    {
        IRestClient client = new RestClient(Endpoints.BASE_URL);
        IRestRequest request;
        IRestResponse response;

        string house = "";

        [Given(@"I have my testing endpoint ""(.*)""")]
        public void GivenIHaveMyTestingEndpoint(string endpoint)
        {
            request = new RestRequest(endpoint);
        }



        [When(@"send the get request")]
        public void GivenSendTheGetRequest()
        {
            response = client.Get(request);
        }

        [Then(@"my status code should be ""(.*)""")]
        public void ThenMyStatusCodeShouldBe(string status)
        {
           Assert.AreEqual(status, response.StatusCode.ToString());
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
            Assert.IsTrue(houses.Contains(actual));
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
        [When(@"add my api key")]
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

        [Then(@"Assert the json schema with '(.*)'")]
        public void ThenAssertTheJsonSchemaWith(string fileName)
        {
            
            
                fileName = fileName.Replace("'", "");

                string path = @"C:\Users\dyakubov\source\repos\RestSharpTraining\RestSharpTraining\Schemas\" + fileName + ".json";

                var schema = File.ReadAllText(path);

                JSchema validSchema = JSchema.Parse(schema);

                JObject obj = JObject.Parse(response.Content);

                Assert.IsTrue(obj.IsValid(validSchema));
        }
        [Given(@"I have my assigned house")]
        public void GivenIHaveMyAssignedHouse()
        {
            request = new RestRequest(Endpoints.GET_SORTING_HAT);
            response = client.Get(request);
            house = response.Content;
            Console.WriteLine(house);
        }












    }
}
