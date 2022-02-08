using MediatR;
using Microsoft.EntityFrameworkCore;
using PaymentCard.Infrastructure.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentCard.Application.Command.CardAggregate
{
    public class UpdateCardCommandHandler : IRequestHandler<UpdateCardCommand, bool>
    {
        private readonly ICardRepository _cardRepository;
        public UpdateCardCommandHandler(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }
        public async Task<bool> Handle(UpdateCardCommand request, CancellationToken cancellationToken)
        {
            var card = await _cardRepository.GetQuery(i => i.Id == request.Id).SingleOrDefaultAsync();

            if (card != null)
            {
                if (request.OwnerName != null)
                    card.OwnerName = request.OwnerName;
                if (request.CardNumber != null)
                    card.CardNumber = request.CardNumber;
                if (request.SecurityCode != null)
                    card.SecurityCode = request.SecurityCode;
                if (request.ValidateDate != null)
                    card.ValidateDate = request.ValidateDate;
                return await _cardRepository.SaveChangesAsync();
            }
            else
            {
                return false;
            }
                
        }
    }
}
