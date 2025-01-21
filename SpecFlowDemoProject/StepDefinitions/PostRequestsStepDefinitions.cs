using NUnit.Framework;
using RestSharp;
using SpecFlowDemoProject.Models;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowDemoProject.StepDefinitions
{
    [Binding]
    public class PostRequestsStepDefinitions
    {
        private RestClient client;
        private RestRequest request;
        private RestResponse<Posts> response;
        private Posts payload; // Declaramos 'payload' como propiedad accesible.

        [Given(@"the API is available at ""([^""]*)""")]
        public void GivenTheAPIIsAvailableAt(string url)
        {
            client = new RestClient(url);
        }

        [When(@"I send a POST request to ""([^""]*)"" with the following details")]
        public void WhenISendAPOSTRequestToWithTheFollowingDetails(string endpoint, Table table)
        {
            // Convertimos la tabla en una instancia del modelo 'Posts'
            payload = table.CreateInstance<Posts>();

            // Configuramos la solicitud POST con el endpoint
            request = new RestRequest(endpoint, Method.Post);
            request.AddJsonBody(payload); // Agregamos el body como JSON

            // Ejecutamos la solicitud y almacenamos la respuesta
            response = client.Execute<Posts>(request);
        }

        [Then(@"the response should contain:")]
        public void ThenTheResponseShouldContain(Table table)
        {
            

            // Comparamos los valores de la tabla con la instancia 'response.Data'
            table.CompareToInstance(response.Data);
        }

        [Then(@"the title should be: ""([^""]*)""")]
        public void ThenTheTitleShouldBe(string expectedTitle)
        {
           

            // Comprobamos si el título coincide con el esperado
            Assert.That(response.Data.Title, Is.EqualTo(expectedTitle),
                $"Expected title to be '{expectedTitle}' but was '{response.Data.Title}'");
        }

    }
}
