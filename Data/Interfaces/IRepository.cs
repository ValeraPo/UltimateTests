using System;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IRepository<T> : IDisposable
        where T: class
    {
        IEnumerable<T> GetListEntity(); // получение всех объектов
        T GetEntity(long id);           // получение одного объекта по id
        void Create(T item);            // создание объекта
        void Update(T item);            // обновление объекта
        void Delete(long id);           // удаление объекта по id
        void Save();                    // сохранение изменений
    }
}