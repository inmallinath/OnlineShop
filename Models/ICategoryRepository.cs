using System.Collections.Generic;

namespace OnlineShop
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}