using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsMathematics.LinearAlgebra;

namespace CsMathematics.Functions
{
    /// <summary>
    /// Represents a scalar field function which takes a vector of real (double) values as input and outputs
    /// a single real (double) value.
    /// </summary>
    internal interface IScalarFieldFunction
    {
        /// <summary>
        /// A mathematical function which maps a R^n -> R.
        /// </summary>
        Func<IVector, double> Function { get; }

        /// <summary>
        /// Differentiates the mathematical function represented by IScalarFieldFunction.Function
        /// and returns the result, which in turn may be evaluated at a point to determine velocity,
        /// acceleration, jerk, snap, crackle, pop, or some other higher order derivative.
        /// </summary>
        /// <param name="n">The number of times which the mathematical representation of
        /// IScalarFieldFunction.Function should be differentiated.</param>
        /// <returns>A new IScalarFieldFunction instance whose Function property may be evaluated
        /// by passing it an IVector instance of the same length as the input to the original
        /// IScalarFieldFunction.Function.</returns>
        IScalarFieldFunction GetNthOrderDerivative(int n);
    }
}
