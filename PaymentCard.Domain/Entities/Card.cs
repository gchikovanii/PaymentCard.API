using PaymentCard.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentCard.Domain.Entities
{
    public class Card : Entity
    {
        public string OwnerName { get; set; }
        public string CardNumber { get; set; }
        public string SecurityCode { get; set; }
        public string ValidateDate { get; set; }
    }
}
