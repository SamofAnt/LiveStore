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

    public Task<IEnumerable<Product>> GetAllByCategoryId(int id)
    {
        var products = _originalRepository.GetAllByCategoryId(id);
        _logger.LogInformation("Method GetAllByCategoryId returned the products successfully: {@Products}", products);
        return products;
    }

    public Task<IEnumerable<Product>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Product?> FindById(int id)
    {
        throw new NotImplementedException();
    }

    public bool TryGet(int id, out Product? entity)
    {
        throw new NotImplementedException();
    }

    public async Task Add(Product product)
    {
        try
        {
            throw new InvalidOperationException("Test exception");
        }
        catch (Exception e)
        {
            _logger.LogError(e,"Testing sentry");
        }
        
        /*try
        {
            await _originalRepository.Add(product);
            _logger.LogInformation("Product adding successfully: {@Product}", product);
        }
        catch (Exception e)
        {
            _logger.LogError(e,"Product adding failed: {@Product}", product);
        }*/
    }

    public Task Update(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Remove(int id)
    {
        throw new NotImplementedException();
    }
}