using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
        }

        /// <summary>
        /// This connects two nodes together with provided weight
        /// </summary>
        /// <param name="otherNode">Node to connect</param>
        /// <param name="weight">Perhaps distance in km?</param>
        public void ConnectTo(GraphNode<T> otherNode, int weight)
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

        // This is an example of function overloading- same name, different argument lists.
        /// <summary>
        /// This connects with a weight of zero
        /// </summary>
        /// <param name="otherNode">Node to connect this node to</param>
        public void ConnectTo(GraphNode<T> otherNode)
        {
            Edges.Add(new GraphEdge<T>(this, otherNode, 0));
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
