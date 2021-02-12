using System.Collections.Generic;
using CatCards.DAO;
using CatCards.Models;
using CatCards.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatCards.Controllers
{
    [Route("api/cards")]//maybe: api/cards/
    [ApiController]
    public class CatController : ControllerBase
    {
        private readonly ICatCardDAO cardDAO;
        private readonly ICatFactService catFactService;
        private readonly ICatPicService catPicService;

        public CatController(ICatCardDAO _cardDAO, ICatFactService _catFact, ICatPicService _catPic)
        {
            catFactService = _catFact;
            catPicService = _catPic;
            cardDAO = _cardDAO;
        }
        [HttpGet]
        public List<CatCard> AllCatCards()
            //get ActionResult instead
        {
            return cardDAO.GetAllCards();
        }
        [HttpGet("{id}")]
        public ActionResult<CatCard> FindCard(int id)
        {
            CatCard c = cardDAO.GetCard(id);
            if (c == null)
            {
                return NotFound("Card not found");
            }
            return Ok(c);
        }
        [HttpGet("random")]
        public ActionResult<CatCard> CreateRandomCard()
        {
            CatCard c = new CatCard();

            CatPic pic = catPicService.GetPic();
            CatFact fact = catFactService.GetFact();
            //create pic and fact objects
            if (fact == null || pic == null)//fact or pic == null; status code 500
            {
                return StatusCode(500);
            }
            c.CatFact = fact.Text;
            c.ImgUrl = pic.File;
            
            return Ok(c);
        }
        [HttpPost]
        public CatCard AddCard(CatCard catCard)
        {
            return cardDAO.SaveCard(catCard);
        }
        [HttpPut("{id}")]
        public bool UpdateCard(CatCard catCard)
        {
            return cardDAO.UpdateCard(catCard);
        }
        [HttpDelete("{id}")]
        public bool RemoveCard(int id)
        {
            return cardDAO.RemoveCard(id);
        }
    }
}
