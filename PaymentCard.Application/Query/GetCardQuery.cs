using MediatR;
using PaymentCard.Application.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentCard.Application.Query
{
    public class GetCardQuery : IRequest<List<CardDto>>
    {
        
    }
}
