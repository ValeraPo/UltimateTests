namespace Data.Interfaces
{
    public interface IUpdate<T>
        where T: class
    {
        void Update(T item);
    }
}