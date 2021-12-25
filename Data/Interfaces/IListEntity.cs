using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IListEntity<T>
        where T: class
    {
        IEnumerable<T> GetListEntity();
    }
}