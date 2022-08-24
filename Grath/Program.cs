using Grath.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grath
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph();

            var v1 = new Vertex(1);
            var v2 = new Vertex(2);
            var v3 = new Vertex(3);
            var v4 = new Vertex(4);
            var v5 = new Vertex(5);
            var v6 = new Vertex(6);

            graph.AddVertex(v1);
            graph.AddVertex(v2);
            graph.AddVertex(v3);
            graph.AddVertex(v4);
            graph.AddVertex(v5);
            graph.AddVertex(v6);

            graph.AddEdge(v1, v2, 15);
            graph.AddEdge(v1, v3, 6);
            graph.AddEdge(v2, v5, 7);
            graph.AddEdge(v2, v6, 3);
            graph.AddEdge(v3, v4, 4);
            graph.AddEdge(v5, v6, 11);
            graph.AddEdge(v6, v5, 11);

            WriteMatrix(graph);

            Console.WriteLine();

            foreach (var vertex in graph.Vertexes)
            {
                WriteLinkedVertexes(graph, vertex);
            }

            Console.WriteLine();

            Console.WriteLine(graph.Connected(v1, v6));
            Console.WriteLine(graph.Connected(v1, v3));
            Console.WriteLine(graph.Connected(v4, v6));

            Console.ReadLine();
        }


        /// <summary>
        /// Выыести список смежных вершин.
        /// </summary>
        /// <param name="graph">Граф.</param>
        /// <param name="v1">Исходная вершина.</param>
        private static void WriteLinkedVertexes(Graph graph, Vertex v1)
        {
            if (graph is null)
            {
                throw new ArgumentNullException(nameof(graph), "Граф не может быть null");
            }

            if (v1 is null)
            {
                throw new ArgumentNullException(nameof(v1), "Вершина не может быть null");
            }

            var linkedVertexes = graph.GetLinkedVertexes(v1);
            Console.Write($"{v1}: ");
            foreach (var vertex in linkedVertexes)
            {
                Console.Write($"{vertex}, ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Вывести матрицу отношений.
        /// </summary>
        /// <param name="graph">Граф.</param>
        private static void WriteMatrix(Graph graph)
        {
            if (graph is null)
            {
                throw new ArgumentNullException(nameof(graph), "Граф не может быть null");
            }

            var matrix = graph.GetMatrix();

            for (int i = 0; i < graph.Vertexes.Count; i++)
            {
                for (int j = 0; j < graph.Vertexes.Count; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
