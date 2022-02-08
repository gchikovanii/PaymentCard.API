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
        public CardController(IMediator mediator, ICardService cardService)
        {
            _mediator = mediator;
            _cardService = cardService;
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
        [HttpPut]
        public async Task<IActionResult> UpdateCard(UpdateCardCommand input)
        {
            return Ok(await _mediator.Send(input));
        }
        [HttpDelete]

        public async Task<IActionResult> DeleteCard(DeleteCardCommand input)
        {
            return Ok(await _mediator.Send(input));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotelById(int id)
        {
            var hotel = await _cardService.GetCardsById(id);
            return Ok(hotel);
        }


    }
}
