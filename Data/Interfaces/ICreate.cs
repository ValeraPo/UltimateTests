namespace Data.Interfaces
{
    public interface ICreate<T>
        where T: class
    {
        void Create(T item);
    }
}