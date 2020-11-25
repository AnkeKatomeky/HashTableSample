using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CustomHashTable<TKey, TValue> : ICustomHashTable<TKey, TValue> where TKey : ICustomHashObject
    {
        private KeyValuePair<TKey, TValue>[] _values;
        int _occupatedPlaces;

        public CustomHashTable(int initSize)
        {
            _values = new KeyValuePair<TKey, TValue>[initSize+3];
        }

        public void Append(TKey key, TValue value)
        {
            //Если есть место то вставляем иначе ошибка
            if (_occupatedPlaces < _values.Length)
            {               
                _occupatedPlaces++;
            }
            else
            {
                throw new IndexOutOfRangeException("В таблице нету места");
            }

            _values[GetIndex(key)] = new KeyValuePair<TKey, TValue>(key, value);
        }

        public TValue Get(TKey key)
        {
            return _values[FindIndex(key)].Value;
        }

        public void Remove(TKey key)
        {
            _occupatedPlaces--;
            _values[FindIndex(key)] = default(KeyValuePair<TKey, TValue>);
        }

        public int GetIndex(TKey key)
        {
            //Пытаемся получить вакантное место в масиве
            int tryCount = 0;
            int index = 0;
            do
            {
                index = key.GetHash(_values.Length, tryCount);
                tryCount++;
            //Не пустой ли обьект который мы только что получили
            } while (!EqualityComparer<TValue>.Default.Equals(_values[index].Value, default(TValue)));
            return index;
        }

        public int FindIndex(TKey key)
        {
            //Пытаемся получить вакантное место в масиве
            int tryCount = 0;
            int index = 0;
            do
            {
                if (tryCount >= _occupatedPlaces)
                {
                    throw new IndexOutOfRangeException("Такого ключа нету в таблице");
                }
                index = key.GetHash(_values.Length, tryCount);
                tryCount++;
            //Не тот ли ключ что мы ищем
            } while (_values[index].Key?.GetKey() != key.GetKey());
            return index;
        }
    }
}
