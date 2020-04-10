using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Lab3_local
{
    class Node
    {
        /// Имя вершины.
        public int[] first_bank = new int[4];
        public int[] second_bank = new int[4];
        public int value = new int();
        public bool bank_number = false;
        /// Список соседних вершин.
        public List<Node> Children = new List<Node>();
        public Node()
        {
            Children = new List<Node>();
        }
        public Node(int[] arr1, int[] arr2)
        {
            this.first_bank = arr1;
            this.second_bank = arr2;
            Children = new List<Node>();
        }
        public Node(Node node)
        {
            this.first_bank = (int[])node.first_bank.Clone();
            this.second_bank = (int[])node.second_bank.Clone();
            value = node.value - 1;
        }

        /// Добавляет новую соседнюю вершину.
        public Node AddChildren(Node node, bool bidirect = false)
        {
            Children.Add(node);

            if (bidirect)
            {
                node.Children.Add(this);
            }
            return this;
        }
    }
}
