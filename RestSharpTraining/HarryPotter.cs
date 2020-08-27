using NUnit.Framework;
using RestSharp;
using RestSharpTraining.pojos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace RestSharpTraining
{
   
        public class HarryPotter: Endpoints
    {

        IRestClient client = new RestClient(Endpoints.BASE_URL);

        [SetUp]
        public void setup()
        {
            
        }
        [Test]
        public void sortingHat()
        {
            IRestRequest request = new RestRequest(Endpoints.GET_HOUSES);
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
            IRestRequest request = new RestRequest(Endpoints.GET_CHARACTERS).AddParameter("key",Endpoints.API_KEY);
            IRestResponse response = client.Get(request);
            string content = response.Content;
           
            IList<Character> listOfCharacters = JsonConvert.DeserializeObject<List<Character>>(content);
            Console.WriteLine(listOfCharacters);


            //foreach (Character each in listOfCharacters)
            //{
            //    Console.WriteLine(each.Name);
            //}


            Assert.IsTrue(response.IsSuccessful);
            Assert.AreEqual("OK", response.StatusCode.ToString());

            //Console.WriteLine(response.Content);

        }

        [Test]
        public void getAcharacter()
        {
            IRestRequest request = new RestRequest(Endpoints.GET_ONE_CHARACTER+Endpoints.HANNAH_ID).AddParameter("key",Endpoints.API_KEY);
            IRestResponse response = client.Get(request);
            
            string content = response.Content;

            Character hannah = JsonConvert.DeserializeObject<Character>(content);

            Assert.AreEqual("Hannah Abbott", hannah.Name);
            Assert.AreEqual("OK", response.StatusCode.ToString());

            Console.WriteLine(hannah.MinistryOfMagic);
            Console.WriteLine(hannah.Name);
            Console.WriteLine(hannah.School);
            Console.WriteLine(response.Content);


        }
    }
}
