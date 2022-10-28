namespace dominando_injecao_de_dependencia.Services.Contracts
{
    public interface IDeliveryFeeService
    {
         Task<decimal> GetDeliveryFeeAsync(string zipCode);
    }
}