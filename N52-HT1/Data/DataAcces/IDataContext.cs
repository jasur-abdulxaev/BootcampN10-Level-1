using N52_HT1.Models;

namespace N52_HT1.Data.DataAcces;

public interface IDataContext
{
    List<User> Users { get; }
    void SaveChanges();
}
