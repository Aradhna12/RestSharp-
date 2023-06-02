using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void getRequestTest()
        {
            var restClient = new RestClient("https://reqres.in");
            //Create a rest request
            var restRequest = new RestRequest("/api/users/2", Method.Get);  //Single user detail
            //add headers
            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;

            RestResponse response = restClient.Execute(restRequest);
            var content = response.Content;
            Console.WriteLine(content);
            Console.WriteLine(response.StatusCode);
            //var users = JsonConvert.DeserializeObject<ClassAPI>(content);
            //var response = demo.GetUsers();
            //Assert.AreEqual(2, response.Page);
            //Assert.AreEqual("Michel", response.Data[0].FirstName);
        }
        [TestMethod]
        public void postRequestTest()
        {
            var client = new RestClient("https://reqres.in");
            var request = new RestRequest("api/users", Method.Post);
            request.AddBody(new { name = "Michael" });
            request.AddUrlSegment("postid", 7);
            var response = client.Execute(request);

            Console.WriteLine("Status code" + response.StatusCode);
            Console.WriteLine(response.Content.ToString());
            var content = response.Content.ToString();
            //JObject joResponse = JObject.Parse(content);
            //Console.WriteLine(joResponse["id"]);
            //Assert.IsNotNull(joResponse["name"]);


        }



        public void putRequestTest()
        {
            var client = new RestClient("https://reqres.in");
            var request = new RestRequest("api/users", Method.Put);
            request.AddBody(new { name = "Mich" });
            request.AddUrlSegment("postid", 7);
            var response = client.Execute(request);

            Console.WriteLine("Status code" + response.StatusCode);
            Console.WriteLine(response.Content.ToString());
            var content = response.Content.ToString();
            JObject joResponse = JObject.Parse(content);
            //Console.WriteLine(joResponse["id"]);
            Assert.IsNotNull(joResponse);


        }

        [TestMethod]
        public void delRequestTest()
        {
            var client = new RestClient("https://reqres.in");
            var request = new RestRequest("api/users", Method.Delete);
            request.AddBody(new { name = "Michael" });
           request.AddUrlSegment("postid", 2);
            var response = client.Execute(request);

            Console.WriteLine("Status code" + response.StatusCode);
            Console.WriteLine(response.Content.ToString());
           var content = response.Content.ToString();
            //JObject joResponse = JObject.Parse(content);
            //Console.WriteLine(joResponse["id"]);
            //Assert.IsNotNull(joResponse["name"]);


        }
    }

    class JObject
    {
        internal static JObject Parse(string content)
        {
            throw new NotImplementedException();
        }
    }
}
