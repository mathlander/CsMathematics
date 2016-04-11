using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsMathematics.LinearAlgebra;

namespace CsMathematics.Calculus
{
    /// <summary>
    /// A collection of differentiable terms which are additive.  Differentiation is distributed
    /// to each term.
    /// </summary>
    internal class SumTerm : IDifferentiableTerm
    {
        private readonly IDifferentiableTerm _leftSummand;
        private readonly IDifferentiableTerm _rightSummand;

        public SumTerm(IDifferentiableTerm leftSummand, IDifferentiableTerm rightSummand)
        {
            _leftSummand = leftSummand;
            _rightSummand = rightSummand;
        }

        public IDifferentiableTerm DifferentiateWrtKthParameter(int k)
        {
            // differentiability is distributed among terms for a function f(x) = g(x) + h(x) as
            // f'(x) = g'(x) + h'(x)
            var gPrime = _leftSummand.DifferentiateWrtKthParameter(k);
            var hPrime = _rightSummand.DifferentiateWrtKthParameter(k);

            return new SumTerm(gPrime, hPrime);
        }

        public double Evaluate(IVector vector)
        {
            return _leftSummand.Evaluate(vector) + _rightSummand.Evaluate(vector);
        }
    }
}
