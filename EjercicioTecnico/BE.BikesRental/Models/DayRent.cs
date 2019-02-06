namespace EjercicioTecnico.BE.BikesRental
{
    public class DayRent : Rental
    {
        private const int Price = 20;

        public override void SetRentedPeriod(int rentedPeriod)
        {
            RentedPeriod = rentedPeriod;
        }

        public override decimal CalculateRent()
        {
            return RentedPeriod * Price;
        }
    }
}
