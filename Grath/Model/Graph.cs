using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grath.Model
{
    class Graph
    {
        /// <summary>
        /// Список вершин.
        /// </summary>
        public List<Vertex> Vertexes { get; set; }

        /// <summary>
        /// Список ребер.
        /// </summary>
        public List<Edge> Edges { get; set; }

        /// <summary>
        /// Создать граф.
        /// </summary>
        public Graph()
        {
            Vertexes = new List<Vertex>();
            Edges = new List<Edge>();
        }

        /// <summary>
        /// Добавить вершину.
        /// </summary>
        /// <param name="vertex">Новая вершина.</param>
        public void AddVertex(Vertex vertex)
        {
            if (vertex is null)
            {
                throw new ArgumentNullException(nameof(vertex), "Вершина не может быть null");
            }

            Vertexes.Add(vertex);
        }

        /// <summary>
        /// Добавить ребро
        /// </summary>
        /// <param name="from">Исходная вершина.</param>
        /// <param name="to">Конечная вершина.</param>
        /// <param name="weight">Вес.</param>
        public void AddEdge(Vertex from, Vertex to, int weight)
        {
            if (from is null)
            {
                throw new ArgumentNullException(nameof(from), "Вершина не может быть null");
            }

            if (to is null)
            {
                throw new ArgumentNullException(nameof(to), "Вершина не может быть null");
            }

            if (weight == 0)
            {
                throw new ArgumentNullException(nameof(weight), "Вес не может быть равен нулю.");
            }
            if (weight.GetType() != typeof(int))
            {
                throw new ArgumentException(nameof(weight), "Некорректный вес.");
            }

            var edge = new Edge(from, to, weight);
            Edges.Add(edge);
        }

        /// <summary>
        /// Получить матрицу отношений.
        /// </summary>
        /// <returns>Матрица отношений.</returns>
        public int[,] GetMatrix()
        {
            var result = new int[Vertexes.Count, Vertexes.Count];
            foreach(var edge in Edges)
            {
                result[edge.From.Number - 1, edge.To.Number - 1] = edge.Weight;
            }
            return result;
        }

        /// <summary>
        /// Получить список смежных вершин.
        /// </summary>
        /// <param name="vertex">Исходная вершина.</param>
        /// <returns>Список смежных вершин.</returns>
        public List<Vertex> GetLinkedVertexes(Vertex vertex)
        {
            if (vertex is null)
            {
                throw new ArgumentNullException(nameof(vertex), "Вершина не может быть null");
            }

            var result = new List<Vertex>();

            foreach (var edge in Edges)
            {
                if (vertex == edge.From)
                {
                    result.Add(edge.To);
                }
            }

            return result;
        }

        /// <summary>
        /// Проверить есть ли дорога между вершинами.
        /// </summary>
        /// <param name="start">Исходная вершина.</param>
        /// <param name="finish">Конечная вершина.</param>
        /// <returns>Результат проверки.</returns>
        public bool Connected(Vertex start, Vertex finish)
        {
            if (start is null)
            {
                throw new ArgumentNullException(nameof(start), "Вершина не может быть null");
            }

            if (finish is null)
            {
                throw new ArgumentNullException(nameof(finish), "Вершина не может быть null");
            }

            var list = new List<Vertex>();
            list.Add(start);
            for (int i = 0; i < list.Count; i++)
            {
                foreach (var vertex in GetLinkedVertexes(list[i]))
                {
                    if(!list.Contains(vertex))
                    {
                        list.Add(vertex);
                    }
                }
            }

            if (list.Contains(finish))
            {
                return true;
            }
            return false;
        }
    }
}
