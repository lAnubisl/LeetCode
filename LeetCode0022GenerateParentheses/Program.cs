using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode0022GenerateParentheses
{
    class Node 
    {
        public Node(char value, Node parent)
        {
            this.Value = value;
            this.Parent = parent;
        }
        public char Value { get; }
        public Node Parent { get; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var result = GenerateParenthesis(3);
            
            Console.WriteLine(string.Join(", ", result));
        }
         
        private static IEnumerable<Node> Generate(Node node, int opened, int closed, int n)
        {
            var sb = new StringBuilder();
            if (opened == n)
            {
                if (closed == n)
                {
                    return new List<Node> { node };
                }

                return Generate(new Node(')', node), opened, closed + 1, n);
            }

            if (opened == closed)
            {
                return Generate(new Node('(', node), opened + 1, closed, n);
            }

            return Generate(new Node('(', node), opened + 1, closed, n).Union(Generate(new Node(')', node), opened, closed + 1, n));
        }

        public static IList<string> GenerateParenthesis(int n) 
        {
            var result = new List<string>();
            var nodes = Generate(null, 0, 0, n);
            foreach(var node in nodes)
            {
                var current = node;
                var arr = new char[2*n];
                for(var i = 2*n-1; i >=0; i--)
                {
                    arr[i] = current.Value;
                    current = current.Parent;
                }

                result.Add(new string(arr));
            }
            
            return result;
        }
    }
}
