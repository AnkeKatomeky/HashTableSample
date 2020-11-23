using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// Интерфейс кастомной хеш таблицы
    /// </summary>
    /// <typeparam name="TKey">Обьект ключ реалезующий ICustomHashObject</typeparam>
    /// <typeparam name="TValue">Обьект значение</typeparam>
    public interface ICustomHashTable<TKey, TValue> where TKey : ICustomHashObject
    {
        /// <summary>
        /// Добавить в таблицу значение с ключем
        /// </summary>
        /// <param name="key">Обьект ключ реалезующий ICustomHashObject</param>
        /// <param name="value">Обьект значение</param>
        void Append(TKey key, TValue value);

        /// <summary>
        /// Удалить обьект и таблицы по ключу
        /// </summary>
        /// <param name="key">Обьект ключ реалезующий ICustomHashObject</param>
        void Remove(TKey key);

        /// <summary>
        /// Получить обьект по ключу
        /// </summary>
        /// <param name="key">Обьект ключ реалезующий ICustomHashObject</param>
        /// <returns>Искомый обьект</returns>
        TValue Get(TKey key);

        /// <summary>
        /// Получить индекс по ключу для вставки
        /// </summary>
        /// <param name="key">Обьект ключ реалезующий ICustomHashObject</param>
        /// <returns>Свободный индекс в масиве-таблице</returns>
        int GetIndex(TKey key);

        /// <summary>
        /// Найти индекс существующего обьекта в таблице
        /// </summary>
        /// <param name="key">Обьект ключ реалезующий ICustomHashObject</param>
        /// <returns>Индекс ключа в масиве-таблице</returns>
        int FindIndex(TKey key);
    }
}
