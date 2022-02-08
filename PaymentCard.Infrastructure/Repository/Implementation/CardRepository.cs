using PaymentCard.Domain.Entities;
using PaymentCard.Infrastructure.DataContext;
using PaymentCard.Infrastructure.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentCard.Infrastructure.Repository.Implementation
{
    public class CardRepository : Repository<Card>, ICardRepository
    {
        public CardRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
