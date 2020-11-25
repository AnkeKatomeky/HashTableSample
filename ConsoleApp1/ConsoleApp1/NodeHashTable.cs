using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }

        public string Key { get; set; }

        public T Value { get; set; }
    }

    public class NodesHashTable<T>
    {
        private Node<T>[] _nodes;

        public NodesHashTable(int size)
        {
            _nodes = new Node<T>[size];
        }

        public T Get(string key)
        {
            Validate(key);

            var (_, cur) = GetNodeByKey(key);
            if (cur == null)
            {
                throw new ArgumentOutOfRangeException("Ключа ненашлось в таблице");
            }

            return cur.Value;
        }

        public void Add(string key, T value)
        {
            Validate(key);

            var node = new Node<T> { Key = key, Value = value, Next = null };
            var position = GetPositionByKey(key);

            Node<T> positionNode = _nodes[position];

            if (positionNode == null)
            {
                _nodes[position] = node;
            }
            else
            {
                while (positionNode.Next != null)
                {
                    positionNode = positionNode.Next;
                }
                positionNode.Next = node;
            }
        }

        public bool Remove(string key)
        {
            Validate(key);

            var position = GetPositionByKey(key);

            var (pre, cur) = GetNodeByKey(key);

            if (cur == null)
            {
                return false;
            }
            if (pre == null)
            {
                _nodes[position] = null;
                return true;
            }

            pre.Next = cur.Next;
            return true;
        }

        public bool ContainsKey(string key)
        {
            Validate(key);
            var (_, cur) = GetNodeByKey(key);
            return cur != null;
        }

        private void Validate(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("Отсутсвует ключ");
            }
        }

        private int GetPositionByKey(string key)
        {
            return Math.Abs(key.GetHashCode() % _nodes.Length);
        }

        private (Node<T> pre, Node<T> cur) GetNodeByKey(string key)
        {
            int position = GetPositionByKey(key);

            Node<T> curentNode = _nodes[position];
            Node<T> previous = null;

            while (curentNode != null)
            {
                if (curentNode.Key == key)
                {
                    return (previous, curentNode);
                }

                previous = curentNode;
                curentNode = curentNode.Next;
            }

            return (null,null);
        }
    }
}
