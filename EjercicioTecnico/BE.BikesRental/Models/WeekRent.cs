namespace EjercicioTecnico.BE.BikesRental
{
    public class WeekRent : Rental
    {
        private static int Price = 60;

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
