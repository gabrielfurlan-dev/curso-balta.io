using Dapper;
using DependencyStore.Models;
using dominando_injecao_de_dependencia.Repositories.Contracts;
using dominando_injecao_de_dependencia.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace DependencyStore.Controllers;

public class OrderController : ControllerBase
{
    ICustomerRepository _customerRepository;
    IDeliveryFeeService _deliveryFeeService;
    IPromoCodeRepository _promoCodeRepository;

    public OrderController(ICustomerRepository customerRepository, IDeliveryFeeService deliveryFeeService, IPromoCodeRepository promoCodeRepository)
        {
            _customerRepository = customerRepository;
            _deliveryFeeService = deliveryFeeService;
            _promoCodeRepository = promoCodeRepository;
        } 

    [Route("v1/orders")]
    [HttpPost]
    public async Task<IActionResult> Place(string customerId, string zipCode, string promoCode, int[] products)
    {
        // #1 - Recupera o cliente
        var customer = _customerRepository.GetByIdAsync(customerId);

        if (customer is null)
                NotFound();

        // #2 - Calcula o frete
        decimal deliveryFee = await _deliveryFeeService.GetDeliveryFeeAsync(zipCode);
        PromoCode? cupom = await _promoCodeRepository.GetPromoCodeById(promoCode);
        decimal discount = cupom?.Value ?? 0M;
        var order = new Order(DateTime.Now, deliveryFee, discount, products, )

        // #7 - Retorna
        return Ok(new
        {
            Message = $"Pedido gerado com sucesso!"
        });
    }
}