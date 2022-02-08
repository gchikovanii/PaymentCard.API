using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentCard.Application.Command.CardAggregate
{
    public class DeleteCardCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
