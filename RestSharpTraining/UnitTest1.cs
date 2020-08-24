using NUnit.Framework;
using RestSharp;

namespace RestSharpTraining
{
    public class Tests
    {
        IRestClient client = new RestClient();
        IRestRequest request = new RestRequest("http://tr01vdsiis073:9095/api/Training", DataFormat.Json);
        IRestResponse response;
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test1()
        {
            response = client.Get(request);
            System.Console.WriteLine(response.Content);
            System.Console.WriteLine(response.ContentType);
            System.Console.WriteLine(response.StatusCode);

           Assert.That(response.ContentType.Contains("application/json"));

           Assert.IsTrue(response.Content.Contains("1"));


        }
    }
}