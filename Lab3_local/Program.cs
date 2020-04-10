using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab3_local
{
    class Program
    {
        static public Node Tabu(ref Node s0, ref Stack<Node> Path)
        {
            bool corner = true;
            Node sBest = new Node(s0);
            sBest.Children = s0.Children;
            sBest.bank_number = s0.bank_number;
            Node bestCandidate = new Node(s0);
            bestCandidate.Children = s0.Children;
            List<Node> tabuList = new List<Node>();
            tabuList.Add(s0);
            Path.Push(s0);
            while (!sBest.second_bank.SequenceEqual(new List<int>() { 1, 1, 1, 1 }))
            {
                List<Node> sNeighborhood = new List<Node>();
                foreach (var x in bestCandidate.Children)
                {
                    Node added = new Node(x);
                    added.bank_number = x.bank_number;
                    sNeighborhood.Add(added);

                }

                foreach (var sCandidate in sNeighborhood)
                    if (!tabuList.Exists(x => x.first_bank.SequenceEqual(sCandidate.first_bank)) && sCandidate.value < bestCandidate.value)
                    {
                        bestCandidate = sCandidate;
                        corner = false;
                    }

                if (!bestCandidate.first_bank.SequenceEqual(sBest.first_bank))
                {
                    sBest = bestCandidate;
                    Path.Push(sBest);
                    tabuList.Add(bestCandidate);
                }

                if(corner == true)
                {
                    Path.Pop();
                    sBest = Path.Peek();
                }
                corner = true;

                setChildren(ref sBest);
                bestCandidate = new Node(sBest);
                bestCandidate.Children = sBest.Children;
            }

            return sBest;
        }
        static public void setChildren(ref Node n0)
        {
            n0.Children = new List<Node>();
            if (n0.bank_number == false)
            {
                if (n0.first_bank[0] == 1 && (n0.first_bank[2] != n0.first_bank[3] || n0.first_bank[2] == 0))
                {
                    Node child = new Node(n0);
                    child.first_bank[0] = 0;
                    child.second_bank[0] = 1;
                    child.bank_number = true;
                    n0.AddChildren(child);
                }
                if (n0.first_bank[1] == 1 && (n0.first_bank[0] != n0.first_bank[2] || n0.first_bank[0] == 0) && (n0.first_bank[3] != n0.first_bank[2] || n0.first_bank[3] == 0))
                {
                    Node child = new Node(n0);
                    child.first_bank[1] = 0;
                    child.second_bank[1] = 1;
                    child.bank_number = true;
                    n0.AddChildren(child);
                }
                if (n0.first_bank[2] == 1 && (n0.first_bank[0] != n0.first_bank[1] || n0.first_bank[0] == 0))
                {
                    Node child = new Node(n0);
                    child.first_bank[2] = 0;
                    child.second_bank[2] = 1;
                    child.bank_number = true;
                    n0.AddChildren(child);
                }
                if (n0.first_bank[3] == 1 && (n0.first_bank[0] != n0.first_bank[2] || n0.first_bank[0] == 0) && (n0.first_bank[0] != n0.first_bank[1] || n0.first_bank[0] == 0))
                {
                    Node child = new Node(n0);
                    child.first_bank[3] = 0;
                    child.second_bank[3] = 1;
                    child.bank_number = true;
                    n0.AddChildren(child);
                }
                if (n0.first_bank[0] == 1 && n0.first_bank[3] == 1)
                {
                    Node child = new Node(n0);
                    child.first_bank[0] = 0;
                    child.second_bank[0] = 1;
                    child.first_bank[3] = 0;
                    child.second_bank[3] = 1;
                    child.bank_number = true;
                    n0.AddChildren(child);
                }
                if (n0.first_bank[2] == 1 && n0.first_bank[3] == 1 && (n0.first_bank[0] != n0.first_bank[1] || n0.first_bank[0] == 0))
                {
                    Node child = new Node(n0);
                    child.first_bank[2] = 0;
                    child.second_bank[2] = 1;
                    child.first_bank[3] = 0;
                    child.second_bank[3] = 1;
                    child.bank_number = true;
                    n0.AddChildren(child);
                }
            }
            else
            {
                if (n0.second_bank[0] == 1 && (n0.second_bank[2]!=n0.second_bank[3] || n0.second_bank[2]==0))
                {
                    Node child = new Node(n0);
                    child.second_bank[0] = 0;
                    child.first_bank[0] = 1;
                    n0.bank_number = false;
                    n0.AddChildren(child);
                }
                if (n0.second_bank[1] == 1 && (n0.second_bank[0] != n0.second_bank[2] || n0.second_bank[0]==0) && (n0.second_bank[3] != n0.second_bank[2] || n0.second_bank[3]==0))
                {
                    Node child = new Node(n0);
                    child.second_bank[1] = 0;
                    child.first_bank[1] = 1;
                    n0.bank_number = false;
                    n0.AddChildren(child);
                }
                if (n0.second_bank[2] == 1 && (n0.second_bank[0] != n0.second_bank[1] || n0.second_bank[0]==0))
                {
                    Node child = new Node(n0);
                    child.second_bank[2] = 0;
                    child.first_bank[2] = 1;
                    n0.bank_number = false;
                    n0.AddChildren(child);
                }
                if (n0.second_bank[3] == 1 && (n0.second_bank[0] != n0.second_bank[2] || n0.second_bank[0] == 0) && (n0.second_bank[0] != n0.second_bank[1] || n0.second_bank[0]==0))
                {
                    Node child = new Node(n0);
                    child.second_bank[3] = 0;
                    child.first_bank[3] = 1;
                    n0.bank_number = false;
                    n0.AddChildren(child);
                }
                if (n0.second_bank[0] == 1 && n0.second_bank[3] == 1)
                {
                    Node child = new Node(n0);
                    child.second_bank[0] = 0;
                    child.first_bank[0] = 1;
                    child.second_bank[3] = 0;
                    child.first_bank[3] = 1;
                    n0.bank_number = false;
                    n0.AddChildren(child);
                }
                if (n0.second_bank[2] == 1 && n0.second_bank[3] == 1 && (n0.second_bank[0] != n0.second_bank[1] || n0.second_bank[0]==0))
                {
                    Node child = new Node(n0);
                    child.second_bank[2] = 0;
                    child.first_bank[2] = 1;
                    child.second_bank[3] = 0;
                    child.first_bank[3] = 1;
                    n0.bank_number = false;
                    n0.AddChildren(child);
                }
                if((n0.second_bank[0] != n0.second_bank[1] || n0.second_bank[0] == 0) && (n0.second_bank[0] != n0.second_bank[2] || n0.second_bank[0] == 0) && (n0.second_bank[2] != n0.second_bank[3] || n0.second_bank[2] == 0))
                {
                    Node child = new Node(n0);
                    n0.AddChildren(child);
                }
            }
        }
        static void Main(string[] args)
        {
            #region Inicizlization
            Node output_node = null;
            Stack<Node> output = new Stack<Node>();
            Stack<Node> Path = new Stack<Node>();
            Node n0 = new Node(new int[]{ 1,1,1,1 },new int[]{ 0,0,0,0 });
            #endregion
            Console.WriteLine("The start is : 1/1/1/1 & 0/0/0/0");
            n0.value = 100;
            setChildren(ref n0); // Setting the children of the root node
            Tabu(ref n0,ref Path); // Using the Tabu algorithm to root node
            while (Path.Count!=0) // Sorting the Stack of path because of LIFO
                output.Push(Path.Pop()); 
            while (output.Count != 0) // Output of the path founded by Tabu
            {
                output_node = output.Pop();
                Console.WriteLine($"{output_node.first_bank[0]}/{output_node.first_bank[1]}/{output_node.first_bank[2]}/{output_node.first_bank[3]} " +
                $" {output_node.second_bank[0]}/{output_node.second_bank[1]}/{output_node.second_bank[2]}/{output_node.second_bank[3]}");
            }
        }
    }
}
