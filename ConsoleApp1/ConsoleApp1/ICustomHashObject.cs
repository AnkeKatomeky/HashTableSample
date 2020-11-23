using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// Интерфейс обьекта ключа
    /// </summary>
    public interface ICustomHashObject
    {
        /// <summary>
        /// Метод полученния хеша/индекса
        /// </summary>
        /// <param name="hashedArraySize">Размер масива</param>
        /// <param name="tryCount">Номер попытки на вставку</param>
        /// <returns>Хеш/индекс</returns>
        int GetHash(int hashedArraySize, int tryCount);

        /// <summary>
        /// Функция сдвига
        /// </summary>
        /// <returns>Результат функции сдвига</returns>
        int GetHaskShift();

        /// <summary>
        /// Получить значение ключа
        /// </summary>
        /// <returns>Ключ</returns>
        string GetKey();
    }
}
