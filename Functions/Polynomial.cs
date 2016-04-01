using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsMathematics.LinearAlgebra;

namespace CsMathematics.Functions
{
    /// <summary>
    /// Represents a polynomial function f(x) : R -> R.  That is, f(x) takes as its input a single
    /// real (double) value and returns a real (double) value as its output.
    /// </summary>
    internal class Polynomial : ISingleInputScalarFunction, IScalarFieldFunction
    {
        private readonly IDictionary<int, double> _coefficients = new SortedDictionary<int, double>();

        public Polynomial(IReadOnlyList<double> coefficients)
        {
            // coefficients[0] => a_0, ..., coefficients[n] => a_n
            foreach (var index in Enumerable.Range(0, coefficients.Count))
                _coefficients.Add(index, coefficients[index]);
        }

        public IVector Roots
        {
            get { throw new NotImplementedException(); }
        }

        public Func<double, double> Function
        {
            get { throw new NotImplementedException(); }
        }

        public ISingleInputScalarFunction GetNthOrderDerivative(int n)
        {
            throw new NotImplementedException();
        }

        Func<IVector, double> IScalarFieldFunction.Function
        {
            get { throw new NotImplementedException(); }
        }

        IScalarFieldFunction IScalarFieldFunction.GetNthOrderDerivative(int n)
        {
            throw new NotImplementedException();
        }
    }
}
