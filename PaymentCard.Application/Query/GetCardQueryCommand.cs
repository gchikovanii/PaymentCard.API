using MediatR;
using PaymentCard.Application.Model;
using PaymentCard.Infrastructure.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentCard.Application.Query
{
    public class GetCardQueryCommand : IRequestHandler<GetCardQuery, List<CardDto>>
    {
        private readonly ICardRepository _cardRepository;

        public GetCardQueryCommand(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }
        public async Task<List<CardDto>> Handle(GetCardQuery request, CancellationToken cancellationToken)
        {
            var cards = await _cardRepository.GetCollectionAsync();
            return cards.Select(i => new CardDto()
            {
                OwnerName = i.OwnerName,
                CardNumber = i.CardNumber,
                SecurityCode = i.SecurityCode,
                ValidateDate = i.ValidateDate
            }).ToList();

        }
    }
}
