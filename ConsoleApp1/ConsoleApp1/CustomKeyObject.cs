using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CustomKeyObject : ICustomHashObject
    {
        public string Key { get; set; }

        public int GetHash(int hashedArraySize, int tryCount)
        {
            int hash = 0;
            //Простая сумма символов ключа
            foreach (var item in Key)
            {
                hash += item;
            }
            //Берем абсолютный для гарантии попадания + берем остаток от деления
            return Math.Abs(hash + tryCount * GetHaskShift()) % hashedArraySize;
        }

        public int GetHaskShift()
        {
            return 2;
        }

        public string GetKey()
        {
            return Key;
        }
    }
}
