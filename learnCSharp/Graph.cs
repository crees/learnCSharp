using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace learnCSharp
{
    class GraphNode<T>
    {
        public List<GraphEdge<T>> Edges { get; }
        public readonly T Data;

        public GraphNode(T data)
        {
            this.Data = data;
            this.Edges = new List<GraphEdge<T>>();
        }

        /// <summary>
        /// This connects two nodes together with provided weight
        /// </summary>
        /// <param name="otherNode">Node to connect</param>
        /// <param name="weight">Perhaps distance in km?</param>
        public void ConnectTo(GraphNode<T> otherNode, int weight = 0)
        {
            Edges.Add(new GraphEdge<T>(this, otherNode, weight));

            // Should we sort them?
        }

        public bool IsConnectedTo(GraphNode<T> other)
        {
            foreach (GraphEdge<T> e in this.Edges)
            {
                if (e.OtherNode(this) == other)
                {
                    // Ah, a connection is found!
                    return true;
                }
            }

            return false;
        }


        public void DepthFirstTraversalIterative()
        {
            var stack = new Stack<GraphNode<T>>();
            var visited = new List<GraphNode<T>>();

            stack.Push(this);

            while (stack.Count > 0)
            {
                var node = stack.Pop();

                if (!visited.Contains(node))
                {
                    visited.Add(node);
                    Console.Out.WriteLine(node.Data);
                }

                // Get all of the adjacent vertices, and push to the stack
                foreach (var edge in node.Edges)
                {
                    var newNode = edge.OtherNode(node);
                    
                    if (!visited.Contains(newNode))
                    {
                        stack.Push(newNode);
                    }
                }
            }
        }

        public void RecursiveDepthFirst(List<GraphNode<T>> visited = null)
        {
            // This is the first calling, we need to make the List
            if (visited == null)
            {
                visited = new List<GraphNode<T>>();
            }

            // Unusually for recursion, we want call by reference as this list is the one that records all the visited ones.

            if (!visited.Contains(this))
            {
                visited.Add(this);
                Console.Out.WriteLine(this.Data);
            }

            foreach (var edge in this.Edges)
            {
                var node = edge.OtherNode(this);
                if (!visited.Contains(node))
                {
                    node.RecursiveDepthFirst(visited);
                }
            }

            
        }

    }

    class GraphEdge<T>
    {
        private GraphNode<T> A, B;
        int Weight;

        public GraphEdge(GraphNode<T> a, GraphNode<T> b, int weight)
        {
            this.A = a;
            this.B = b;
            this.Weight = weight;
        }

        /// <summary>
        /// Pass a Node to this
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        public GraphNode<T> OtherNode(GraphNode<T> from)
        {
            GraphNode<T> to;

            if (from == this.A) {
                to = B;
            } else if (from == this.B) {
                to = A;
            } else
            {
                // Turns out the passed node isn't actually to do with this!
                throw new ArgumentOutOfRangeException("This edge isn't actually connected to this node.");
            }

            return to;
        }
    }
}
