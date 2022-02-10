using MediatR;
using Microsoft.EntityFrameworkCore;
using PaymentCard.Infrastructure.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentCard.Application.Command.CardAggregate
{
    public class DeleteHotelCommandHandler : IRequestHandler<DeleteCardCommand, bool>
    {
        private readonly ICardRepository _cardRepository;
        public DeleteHotelCommandHandler(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }
        public async Task<bool> Handle(DeleteCardCommand request, CancellationToken cancellationToken)
        {
            var card = await _cardRepository.GetQuery(i => i.Id == request.Id).SingleOrDefaultAsync();
            if (card != null)
            {
                _cardRepository.Delete(card);
                return await _cardRepository.SaveChangesAsync();
            }
            else
            {
                return false;
            }


        }
    }
}
