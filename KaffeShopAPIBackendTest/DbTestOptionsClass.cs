using _Data;
using Microsoft.EntityFrameworkCore;

namespace KaffeShopAPIBackendTest;

public static class DbTestOptionsClass
{
    public static DbContextOptions<CoffeeShopContext> Create()
    {
        var optionsBuilder = new DbContextOptionsBuilder<CoffeeShopContext>();
        optionsBuilder.UseInMemoryDatabase(databaseName: "TestDatabase");

        return optionsBuilder.Options;
    }
}