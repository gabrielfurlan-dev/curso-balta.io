namespace DependencyStore.Models;

public class Order
{
    public Order(DateTime date, decimal deliveryFee, decimal discount, List<Product> produtcts)
    {
        this.Code = Guid.NewGuid().ToString().Substring(0, 8);
        this.Date = date;
        this.DeliveryFee = deliveryFee;
        this.Discount = discount;
        Products = produtcts;
    }
    public string Code { get; set; }
    public DateTime Date { get; set; }
    public decimal DeliveryFee { get; set; }
    public decimal Discount { get; set; }
    public List<Product> Products { get; set; }
    public decimal SubTotal => Products.Sum(x => x.Price);
    public decimal Total => SubTotal - Discount + DeliveryFee;
}