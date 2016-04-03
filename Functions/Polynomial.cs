using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsMathematics.LinearAlgebra;

namespace CsMathematics.Functions
{
    public class PolynomialException : Exception { public PolynomialException(string message) : base(message) { } }

    /// <summary>
    /// Represents a polynomial function f(x) : R -&gt; R.  That is, f(x) takes as its input a single
    /// real (double) value and returns a real (double) value as its output.
    /// </summary>
    internal class Polynomial : IFunctional
    {
        private readonly IDictionary<int, double> _coefficients = new SortedDictionary<int, double>();
        private readonly int _variableIndex;

        private IList<double> _cachedRoots = null;

        /// <summary>
        /// Constructs a polynomial from the coefficients which define it.
        /// </summary>
        /// <param name="coefficients">The collection of coefficients which are used to compute values
        /// and differentiate the function.</param>
        /// <param name="variableIndex"></param>
        public Polynomial(IReadOnlyList<double> coefficients, int variableIndex = 1)
        {
            if (variableIndex < 1)
                throw new PolynomialException("Unable to create a polynomial which evaluates a variable at index less than 1.");

            _variableIndex = variableIndex;

            // coefficients[0] => a_0, ..., coefficients[n] => a_n
            foreach (var index in Enumerable.Range(0, coefficients.Count))
                _coefficients.Add(index, coefficients[index]);
        }

        public IEnumerable<double> Roots
        {
            get
            {
                if (_cachedRoots != null)
                    return _cachedRoots;

                // DMU Notes(4/3/2016):
                // need to choose a root finding method... bracketing methods will work nicely if all of the roots are real
                // need to decide what to do in the case that they are not... the property signature suggest that all roots
                // are always real, but this is known not to be true, for example: var f = new Polynomial(new List<double> { 1.0, 0.0, 1.0 })
                throw new NotImplementedException();
            }
        }

        public double Evaluate(double x)
        {
            return _coefficients.Values.Select((a_i, i) => a_i * Math.Pow(x, i)).Sum();
        }

        public double Evaluate(IVector pointVector)
        {
            if (pointVector.Length < _variableIndex)
                throw new PolynomialException("The input vector did not have enough elements to evaluate.");

            return Evaluate(pointVector[_variableIndex]);
        }

        public IFunction DifferentiateWrtKthParameter(int k)
        {
            // if differentiating with respect to a variable that doesn't appear in the polynomial
            // or if differentiating a constant, then the derivative is the constant function zero
            if (k != _variableIndex || _coefficients.Count == 1)
                return ConstantFunction.Zero;

            var fPrimeCoeffs = new List<double>(_coefficients.Count - 1);

            foreach (var keyValuePair in _coefficients)
            {
                var power = keyValuePair.Key;
                var coeff = keyValuePair.Value;

                if (power > 0)
                    fPrimeCoeffs.Add(coeff * power);
            }

            return new Polynomial(fPrimeCoeffs);
        }

        IVector IFunction.Evaluate(IVector pointVector)
        {
            return new Vector(new[] { this.Evaluate(pointVector) });
        }
    }
}
