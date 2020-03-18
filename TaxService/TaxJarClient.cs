using System.Net;
using RestSharp;
namespace TaxServiceProject
{
    public class TaxJarClient : ITaxCalculator
    {

        private readonly RestClient client;

        public TaxJarClient(string token)
        {
            this.client = new RestClient("https://api.taxjar.com/v2/");
            this.client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", token));
        }

        public string CalculateTaxOrder(dynamic orderObject)
        {
            RestRequest getRequest = new RestRequest("taxes", Method.POST);
            getRequest.AddHeader("Accept", "application/json");

            getRequest.AddJsonBody(orderObject);

            IRestResponse response = client.Execute(getRequest);

            HttpStatusCode statusCode = response.StatusCode;

            if ((int)statusCode != 200)
            { 
                return response.ErrorException.ToString();
            }

            var content = response.Content;

            return content;
        }
        //==================
        //Request with Dynamic optional Parameters
        public string GetTaxRateLocation(string zip, dynamic OptionalLocation)
        {
            RestRequest getRequest = new RestRequest("rates/{zip}", Method.GET);
            getRequest.AddHeader("Accept", "application/json");

            getRequest.AddUrlSegment("zip", zip);
            getRequest.AddObject(OptionalLocation);

            IRestResponse response = client.Execute(getRequest);

            HttpStatusCode statusCode = response.StatusCode;

            if((int)statusCode != 200)
            {
                return response.ErrorException.ToString();
            }

            var content = response.Content;

            return content;
        }
        //====================
        //Request with only Zipcode
        public string GetTaxRateLocation(string zip)
        {
            RestRequest getRequest = new RestRequest("rates/{zip}", Method.GET);
            getRequest.AddHeader("Accept", "application/json");

            getRequest.AddUrlSegment("zip", zip);

            IRestResponse response = client.Execute(getRequest);

            HttpStatusCode statusCode = response.StatusCode;

            if ((int)statusCode != 200)
            {
                return response.Content;
            }

            var content = response.Content;

            return content;
        }
    }
}
