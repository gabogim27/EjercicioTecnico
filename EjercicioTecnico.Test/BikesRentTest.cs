namespace EjercicioTecnico.Test
{
    using BE.BikesRental;
    using BE.BikesRental.Exceptions;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class BikesRentTest
    {
        [Test]
        public void RentByHourForFiveHours()
        {
            var hourRent = new HourRent();
            hourRent.SetRentedPeriod(5);

            Assert.IsTrue(hourRent.CalculateRent() == 5 * 5);
        }

        [Test]
        public void RentByDayForFiveDays()
        {
            var dayRent = new DayRent();
            dayRent.SetRentedPeriod(5);

            Assert.IsTrue(dayRent.CalculateRent() == 5 * 20);
        }

        [Test]
        public void RentByWeekForFiveWeeks()
        {
            var weekRent = new WeekRent();
            weekRent.SetRentedPeriod(5);

            Assert.IsTrue(weekRent.CalculateRent() == 5 * 60);
        }

        [Test]
        public void RentForFamilyRental()
        {
            var dayRent = GetDayRent(20, 5);
            var hourRent = GetHourRent(5, 5);
            var weekRent = GetWeekRent(60, 5);

            var familyRent = new FamilyRent();
            var rentals = new List<Rental> { dayRent, hourRent, weekRent };


            familyRent.AddRentals(rentals);

            Assert.IsTrue(familyRent.Rentals.Count < 6);
            Assert.IsTrue(familyRent.Rentals.Count > 2);
            Assert.IsTrue(familyRent.CalculateRent() == (20 * 5 + 5 * 5 + 60 * 5) * 0.7m);
        }

        [Test]
        public void AddTwoRentals_ToFamilyRental_ShouldThrowAnException()
        {
            var dayRent = GetDayRent(20, 5);
            var hourRent = GetHourRent(5, 5);

            var familyRent = new FamilyRent();
            var rentals = new List<Rental> { dayRent, hourRent };

            Assert.Throws<FamilyRentException>(() => familyRent.AddRentals(rentals));
        }

        [Test]
        public void AddSixRentals_ToFamilyRental_ShouldThrowAnException()
        {
            var dayRent1 = GetDayRent(20, 5);
            var hourRent1 = GetHourRent(5, 5);
            var dayRent2 = GetDayRent(20, 5);
            var hourRent2 = GetHourRent(5, 5);
            var dayRent3 = GetDayRent(20, 5);
            var hourRent3 = GetHourRent(5, 5);

            var familyRent = new FamilyRent();
            var rentals = new List<Rental>
            {
                dayRent1,
                hourRent1,
                dayRent2,
                hourRent2,
                dayRent3,
                hourRent3
            };


            Assert.Throws<FamilyRentException>(() => familyRent.AddRentals(rentals));
        }

        [Test]
        public void AddZeroRentals_ToFamilyRental_ShouldThrowAnException()
        {

            var familyRent = new FamilyRent();
            var rentals = new List<Rental>();

            Assert.Throws<FamilyRentException>(() => familyRent.AddRentals(null));
            Assert.Throws<FamilyRentException>(() => familyRent.AddRentals(rentals));
        }

        private static DayRent GetDayRent(int rentalPrice, int rentedPeriod)
        {
            return new DayRent() { RentalPrice = rentalPrice, RentedPeriod = rentedPeriod };
        }

        private static HourRent GetHourRent(int rentalPrice, int rentedPeriod)
        {
            return new HourRent() { RentalPrice = rentalPrice, RentedPeriod = rentedPeriod };
        }

        private static WeekRent GetWeekRent(int rentalPrice, int rentedPeriod)
        {
            return new WeekRent() { RentalPrice = rentalPrice, RentedPeriod = rentedPeriod };
        }
    }
}
