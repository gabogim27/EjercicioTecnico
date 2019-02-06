using EjercicioTecnico.BE.BikesRental.Exceptions;

namespace EjercicioTecnico.BE.BikesRental
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FamilyRent : Rental
    {
        public List<Rental> Rentals { get; set; } = new List<Rental>();

        public void AddRentals(List<Rental> rentals)
        {
            if (rentals != null && rentals.Any())
            {
                if (rentals.Count < 3 || rentals.Count > 5)
                {
                    throw new FamilyRentException("A family rental must contain between 3 and 5 rentals");
                }

                Rentals.AddRange(rentals);
            }
            else
            {
                throw new FamilyRentException("Family rental should not be null or empty");
            }
        }

        public override decimal CalculateRent()
        {
            var rentPrice = 0;

            foreach (var rental in Rentals)
            {
                rentPrice += (int)rental.CalculateRent();
            }

            return rentPrice * 0.7m;
        }
    }
}
