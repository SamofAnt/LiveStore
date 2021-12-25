using LiveStore.Data.Model;

namespace LiveStore.ORM.Repositories;

public class LoggableProductRepository : IProductRepository
{
    private readonly IProductRepository _originalRepository;
    private readonly ILogger<IProductRepository> _logger;

    public LoggableProductRepository(IProductRepository originalRepository, ILogger<LoggableProductRepository> logger)
    {
        _originalRepository = originalRepository;
        _logger = logger;
    }

    public async Task<Product> GetById(int id)
    {
        var product =  await _originalRepository.GetById(id);
        _logger.LogInformation("Method GetById  returned the product successfully: {@Product}", product);
        return product;
    }

    public async Task<IEnumerable<Product>> GetAllByCategoryId(int id)
    {
        var products = await _originalRepository.GetAllByCategoryId(id);
        _logger.LogInformation("Method GetAllByCategoryId returned the products successfully: {@Products}", products);
        return products;
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        var products = await _originalRepository.GetAll();
        _logger.LogInformation("Method GetAll returned the products successfully: {@Products}", products);
        return products;
    }

    public async Task<Product?> FindById(int id)
    {
        Product? product = await _originalRepository.FindById(id);
        _logger.LogInformation("Method FindById returned the product successfully: {@Product}", product);
        return product;
    }
    
    public async Task Add(Product product)
    {
        await _originalRepository.Add(product);
        _logger.LogInformation("Added product: {@Product}", product);
    }

    public async Task Update(Product product)
    {
        await _originalRepository.Update(product);
        _logger.LogInformation("Updated product: {@Product}", product);
    }

    public async Task Remove(Product product)
    {
        await _originalRepository.Remove(product);
        _logger.LogInformation("Removed product: {@Product}", product);
    }
}