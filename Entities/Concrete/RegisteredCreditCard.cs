using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class RegisteredCreditCard : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string NameOnTheCard { get; set; }
        public string Number { get; set; }
        public string Cvv { get; set; }
        public string ExpirationDate { get; set; }
        public bool IsActive { get; set; }
    }
}
