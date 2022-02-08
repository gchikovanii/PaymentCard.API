using MediatR;
using PaymentCard.Domain.Entities;
using PaymentCard.Infrastructure.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentCard.Application.Command.CardAggregate
{
    public class CreateCardCommandHandler : IRequestHandler<CreateCardCommand, bool>
    {
        private readonly ICardRepository _cardRepository;
        public CreateCardCommandHandler(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<bool> Handle(CreateCardCommand request, CancellationToken cancellationToken)
        {
            var card = new Card()
            {
                CardNumber = request.CardNumber,
                SecurityCode = request.SecurityCode,
                OwnerName = request.OwnerName,
                ValidateDate = request.ValidateDate
            };
            await _cardRepository.Create(card);
            return await _cardRepository.SaveChangesAsync();
        }
    }
}
