using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grath.Model
{
    class Edge
    {
        /// <summary>
        /// Вес.
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// Исходная вершина. 
        /// </summary>
        public Vertex From { get; set; }

        /// <summary>
        /// Конечная вершина.
        /// </summary>
        public Vertex To { get; set; }


        /// <summary>
        /// Создать ребро 
        /// </summary>
        /// <param name="from">Исходная вершина.</param>
        /// <param name="to">Конечная вершина.</param>
        /// <param name="weight">Вес.</param>
        public Edge(Vertex from, Vertex to, int weight)
        {
            if (weight == 0)
            {
                throw new ArgumentNullException(nameof(weight), "Вес не может быть равен нулю.");
            }
            if (weight.GetType() != typeof(int))
            {
                throw new ArgumentException(nameof(weight), "Некорректный вес.");
            }
            From = from ?? throw new ArgumentNullException(nameof(from));
            To = to ?? throw new ArgumentNullException(nameof(to));
            Weight = weight;
        }

        public override string ToString()
        {
            return $"({From}, {To}) {Weight}";
        }
    }
}
