using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsMathematics.LinearAlgebra;

namespace CsMathematics.Calculus
{
    /// <summary>
    /// A collection of terms which are multiplied together.  Differentiation is applied
    /// using the product rule of derivatives.  That is, f(x) = g(x)*h(x) implies
    /// f'(x) = g'(x)*h(x)*dx + g(x)*h'(x)*dx.
    /// </summary>
    public class ProductTerm : IDifferentiableTerm
    {
        private readonly IDifferentiableTerm _leftFactor;
        private readonly IDifferentiableTerm _rightFactor;

        public ProductTerm(IDifferentiableTerm leftFactor, IDifferentiableTerm rightFactor)
        {
            _leftFactor = leftFactor;
            _rightFactor = rightFactor;
        }

        public IDifferentiableTerm DifferentiateWrtKthParameter(int k)
        {
            // the product rule for f(x) = g(x)*h(x) is f'(x) = g'(x)*h(x) + g(x)*h'(x)
            var g = _leftFactor;
            var h = _rightFactor;
            var gPrime = g.DifferentiateWrtKthParameter(k);
            var hPrime = h.DifferentiateWrtKthParameter(k);

            var leftSummand = new ProductTerm(gPrime, h);
            var rightSummand = new ProductTerm(g, hPrime);
            return new SumTerm(leftSummand, rightSummand);
        }

        public double Evaluate(IVector vector)
        {
            return _leftFactor.Evaluate(vector) * _rightFactor.Evaluate(vector);
        }
    }
}
