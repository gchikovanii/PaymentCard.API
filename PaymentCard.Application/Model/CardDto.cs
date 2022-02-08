using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentCard.Application.Model
{
    public class CardDto
    {
        public string OwnerName { get; set; }
        public string CardNumber { get; set; }
        public string SecurityCode { get; set; }
        public string ValidateDate { get; set; }
    }
}
