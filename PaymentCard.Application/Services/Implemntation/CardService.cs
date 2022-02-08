using Microsoft.EntityFrameworkCore;
using PaymentCard.Application.Model;
using PaymentCard.Infrastructure.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCard.Application.Service
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }
        public async Task<CardDto> GetCardsById(int id)
        {
            var hotel = await _cardRepository.GetQuery(i => i.Id == id).SingleOrDefaultAsync();
            return new CardDto()
            {
                OwnerName = hotel.OwnerName,
                SecurityCode = hotel.SecurityCode,  
                CardNumber = hotel.CardNumber,
                ValidateDate = hotel.ValidateDate
            };
        }





    }
}
