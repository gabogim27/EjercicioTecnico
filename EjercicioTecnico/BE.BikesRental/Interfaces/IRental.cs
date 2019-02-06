namespace EjercicioTecnico
{
    public interface IRental
    {
        void SetRentedPeriod(int rentedTime);

        decimal CalculateRent();
    }
}
