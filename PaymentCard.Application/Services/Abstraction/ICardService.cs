using PaymentCard.Application.Model;
using PaymentCard.Infrastructure.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCard.Application.Service
{
    public interface ICardService
    {
        Task<CardDto> GetCardsById(int id);

    }
}
