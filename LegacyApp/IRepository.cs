namespace LegacyApp
{
    public interface IRepository<T>
    {
        T GetById(int id);
        bool Add(T item);
    }
}