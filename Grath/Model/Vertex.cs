using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grath.Model
{
    class Vertex
    {
        /// <summary>
        /// Номер.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Создать вершину.
        /// </summary>
        /// <param name="number">Номер вершины.</param>
        public Vertex(int number)
        {
            if (number == 0)
            {
                throw new ArgumentNullException(nameof(number), "Номер не может быть равен нулю."); 
            }
            if (number.GetType() != typeof(int))
            {
                throw new ArgumentException(nameof(number), "Некорректный номер вершины.");
            }
            Number = number;
        }

        public override string ToString()
        {
            return Number.ToString();
        }
    }
}
