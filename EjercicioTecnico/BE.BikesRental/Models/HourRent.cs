namespace EjercicioTecnico.BE.BikesRental
{
    public class HourRent : Rental
    {
        private const int Price = 5;

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
