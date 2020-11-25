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
            NodesHashTable<CustomObject> nodesHashTable = new NodesHashTable<CustomObject>(10);

            CustomHashTable<CustomKeyObject, CustomObject> hashTable = new CustomHashTable<CustomKeyObject, CustomObject>(10);
            CustomObject q1 = new CustomObject() { FIO = "Андрей Тимофеев" };
            CustomObject q2 = new CustomObject() { FIO = "Иван Иванович" };
            CustomObject q3 = new CustomObject() { FIO = "Игорь Игоривичь" };
            CustomObject q4 = new CustomObject() { FIO = "Антон Антонович" };
            CustomObject q5 = new CustomObject() { FIO = "Андрей Тимофеев1" };
            CustomObject q6 = new CustomObject() { FIO = "Иван Иванович1" };
            CustomObject q7 = new CustomObject() { FIO = "Игорь Игоривичь1" };
            CustomObject q8 = new CustomObject() { FIO = "Антон Антонович1" };

            hashTable.Append(new CustomKeyObject() { Key = "Антон" }, q4);
            hashTable.Append(new CustomKeyObject() { Key = "Андрей" }, q1);
            hashTable.Append(new CustomKeyObject() { Key = "Иван" }, q2);
            hashTable.Append(new CustomKeyObject() { Key = "Игорь" }, q3);
            hashTable.Append(new CustomKeyObject() { Key = "Антон1" }, q5);
            hashTable.Append(new CustomKeyObject() { Key = "Андрей2" }, q6);
            hashTable.Append(new CustomKeyObject() { Key = "Иван3" }, q7);
            hashTable.Append(new CustomKeyObject() { Key = "Игорь4" }, q8);
            hashTable.Append(new CustomKeyObject() { Key = "Иван9" }, q7);
            hashTable.Append(new CustomKeyObject() { Key = "Игорь8" }, q8);

            var e1 = hashTable.Get(new CustomKeyObject() { Key = "Антон" });
            hashTable.Remove(new CustomKeyObject() { Key = "Антон" });
            var e2 = hashTable.Get(new CustomKeyObject() { Key = "Антон" });

            nodesHashTable.Add("Ku", q1);
            nodesHashTable.Add("Ki", q2);
            nodesHashTable.Add("Ka", q3);
            nodesHashTable.Add("Ko", q4);
            nodesHashTable.Add("Kz", q5);
            nodesHashTable.Add("Ks", q6);
            nodesHashTable.Add("Kh", q7);
            nodesHashTable.Add("Kp", q8);

            var w1 = nodesHashTable.Get("Ka");
            var contains1 = nodesHashTable.ContainsKey("Ks");
            var removed = nodesHashTable.Remove("Kz");
            var contains2 = nodesHashTable.ContainsKey("Kz");
            var w2 = nodesHashTable.Get("Kz");

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
