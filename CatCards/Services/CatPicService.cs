using CatCards.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RestSharp;

namespace CatCards.Services
{
    //this is being a called from a client ie use restsharp
    
    public class CatPicService : ICatPicService
    {
        RestClient client = new RestClient();
        private string API_URL = "https://random-cat-image.herokuapp.com/";
        
        public CatPic GetPic()
        {
            //restRequest request = new restrequest
            RestRequest request = new RestRequest(API_URL);
            IRestResponse<CatPic> response = client.Get < CatPic>(request);
            return response.Data;
        }
    }
}
