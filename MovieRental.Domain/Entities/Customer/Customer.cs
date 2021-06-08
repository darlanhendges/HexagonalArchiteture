using MovieRental.Domain.Core.CrossCutting.Entities;
using System;

namespace MovieRental.Domain.Entities.Customer
{
    public class Customer : EntityBase
    {
        public string Name { get; private set; }
        public DateTime DateBirthday { get; private set; }
        public string Address { get; private set; }

    }
}
