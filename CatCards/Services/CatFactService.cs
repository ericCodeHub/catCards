using CatCards.Models;
using RestSharp;

namespace CatCards.Services
{
    public class CatFactService : ICatFactService
    {
        
        RestClient client = new RestClient();
        private string API_URL = "https://cat-fact.herokuapp.com/facts/random";
        public CatFact GetFact()
        {
            RestRequest request = new RestRequest(API_URL);
            IRestResponse<CatFact> response = client.Get<CatFact>(request);
            return response.Data;
        }
    }    
}
