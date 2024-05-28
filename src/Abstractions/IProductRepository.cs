using sda_onsite_2_csharp_backend_teamwork.src.DTOs;

namespace sda_onsite_2_csharp_backend_teamwork.src.Abstractions;

public interface IProductRepository
{
  public IEnumerable<ProductWithStock> FindAll(int limit, int offset);

  public Product? FindeOne(Guid Id);
  public Product CreateOne(Product product);
  public bool DeleteById(Guid id);
  public Product UpdateOne(Product product);
}
