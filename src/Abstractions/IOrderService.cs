
using sda_onsite_2_csharp_backend_teamwork.src.DTOs;
using sda_onsite_2_csharp_backend_teamwork.src.Entities;

namespace sda_onsite_2_csharp_backend_teamwork.src.Abstractions;

public interface IOrderService
{
    public IEnumerable<OrderCreateDTO> FindAll();
    public IEnumerable<Order> FindByUserId(Guid userId);
    public Order? FindById(Guid id);
    public Order CreateOne(OrderCreateDTO newOrder);
    public bool DeleteOneById(Guid id);
    public bool DeleteOrderByUserId(Guid userId);
    public OrderReadDto? Checkout(List<CheckoutDto> newOrder, string userId);
}
