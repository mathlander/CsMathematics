using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsMathematics.Functions;
using CsMathematics.LinearAlgebra;

namespace CsMathematics.Calculus
{
    internal class Jacobian : IJacobian
    {
        private readonly IDictionary<int, IVectorOperator> _rows;

        public Jacobian(IEnumerable<IVectorOperator> rows)
        {
            _rows = new SortedDictionary<int, IVectorOperator>();
            var i = 1;

            foreach (var row in rows)
            {
                _rows.Add(i, row);
                i++;
            }
        }

        public IEnumerable<IVectorOperator> Rows
        {
            get { return _rows.Values; }
        }

        public IMatrix Evaluate(IVector vector)
        {
            var matrixRows = new List<IVector>(_rows.Values.Select(vectorOperator => vectorOperator.Evaluate(vector)));

            return new Matrix(matrixRows);
        }
    }
}
