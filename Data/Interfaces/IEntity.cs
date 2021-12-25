namespace Data.Interfaces
{
    public interface IEntity<T>
        where T: class
    {
        T GetEntity(long id);
    }
}