using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PaymentCard.Application.Command.CardAggregate;
using PaymentCard.Application.Query;
using PaymentCard.Application.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace PaymentCard.API.Controllers
{
    public class CardController: BaseController
    {
        private readonly IMediator _mediator;
        private readonly ICardService _cardService;
        private readonly ApplicationDbContext _dbcontext;
        public CardController(IMediator mediator, ICardService cardService, ApplicationDbContext dbcontext)
        {
            _mediator = mediator;
            _cardService = cardService;
            _dbcontext = dbcontext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCards()
        {
            var cards = await _mediator.Send(new GetCardQuery());
            return Ok(cards);
        }
        [HttpPost]
        public async Task<IActionResult> AddCard([FromBody] CreateCardCommand input)
        {
            return Ok(await _mediator.Send(input));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCard(int id, UpdateCardCommand input)
        {
            var card = await _cardService.GetCardsById(id);
            if (card != null)
                return Ok(await _mediator.Send(input));
            else
                return null;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCardById(int id)
        {

            var card = await _dbcontext.Cards.FindAsync(id);
            if (card == null)
                return NotFound();
            _dbcontext.Remove(card);
            return Ok(await _dbcontext.SaveChangesAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCardById(int id)
        {
            var card = await _cardService.GetCardsById(id);
            return Ok(card);
        }


    }
}
