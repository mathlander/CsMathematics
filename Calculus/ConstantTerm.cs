using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsMathematics.LinearAlgebra;

namespace CsMathematics.Calculus
{
    internal class ConstantTerm : IDifferentiableTerm
    {
        private readonly double _scalar;

        public ConstantTerm(double scalar)
        {
            _scalar = scalar;
        }

        public IDifferentiableTerm DifferentiateWrtKthParameter(int k)
        {
            return new ConstantTerm(0.0);
        }

        public double Evaluate(IVector vector)
        {
            return _scalar;
        }
    }
}
