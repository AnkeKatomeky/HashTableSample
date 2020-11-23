using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomHashTable<CustomKeyObject, CustomObject> hashTable = new CustomHashTable<CustomKeyObject, CustomObject>(10);
            CustomObject q1 = new CustomObject() { FIO = "Андрей Тимофеев" };
            CustomObject q2 = new CustomObject() { FIO = "Иван Иванович" };
            CustomObject q3 = new CustomObject() { FIO = "Игорь Игоривичь" };
            CustomObject q4 = new CustomObject() { FIO = "Антон Антонович" };

            hashTable.Append(new CustomKeyObject() { Key = "Антон" }, q4);
            hashTable.Append(new CustomKeyObject() { Key = "Андрей" }, q1);
            hashTable.Append(new CustomKeyObject() { Key = "Иван" }, q2);
            hashTable.Append(new CustomKeyObject() { Key = "Игорь" }, q3);

            var d = hashTable.Get(new CustomKeyObject() { Key = "Антон" });

            Console.ReadKey();
        }
    }

    class CustomObject
    {
        public string FIO { get; set; }

        public override string ToString()
        {
            return FIO;
        }
    }
}
