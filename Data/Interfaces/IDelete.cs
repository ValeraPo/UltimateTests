namespace Data.Interfaces
{
    public interface IDelete<T>
        where T: class
    {
        void Delete(long id);
    }
}