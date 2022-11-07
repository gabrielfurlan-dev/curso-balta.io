using RestSharp;

namespace dominando_injecao_de_dependencia.Services
{
    public class Configuration
    {
        public RestClientOptions? DeliveryFeeServiceUrl { get; internal set; }
    }
}