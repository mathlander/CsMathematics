using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsMathematics.Functions;
using CsMathematics.LinearAlgebra;

namespace CsMathematics.Calculus
{
    internal class Hessian : IHessian
    {
        private readonly IJacobian _jacobian;

        public Hessian(IEnumerable<IVectorOperator> rows)
        {
            // the Hessian is just a special type of Jacobian
            _jacobian = new Jacobian(rows);
        }

        public IEnumerable<IVectorOperator> Rows
        {
            get { return _jacobian.Rows; }
        }

        public IMatrix Evaluate(IVector vector)
        {
            return _jacobian.Evaluate(vector);
        }
    }
}
