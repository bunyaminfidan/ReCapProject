using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class FakeCard : IEntity
    {
        public int Id { get; set; }
        public string nameOnTheCard { get; set; }
        public string Number { get; set; }
        public string Cvv { get; set; }
        public string ExpirationDate { get; set; }
        public int MoneyInTheCard { get; set; }

    }
}
