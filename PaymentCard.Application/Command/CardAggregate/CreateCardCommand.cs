using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentCard.Application.Command.CardAggregate
{
    public class CreateCardCommand : IRequest<bool>
    {
        public string OwnerName { get; set; }
        public string CardNumber { get; set; }
        public string SecurityCode { get; set; }
        public string ValidateDate { get; set; }
    }
}
