using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsMathematics.Functions
{
    /// <summary>
    /// Represents a scalar function which takes a input a single real (double) value and outputs
    /// a single real (double) value.  This is a convenience interface, which is superseded by 
    /// the more general IScalarFieldFunction.  In particular, ISingleInputScalarFunction.Function
    /// may be replaced with IScalarFieldFunction.Function by inputting a vector with just a single element,
    /// rather than inputting a double.
    /// </summary>
    internal interface ISingleInputScalarFunction
    {
        /// <summary>
        /// A mathematical function which maps a R -> R.
        /// </summary>
        Func<double, double> Function { get; }

        /// <summary>
        /// Differentiates the mathematical function represented by ISingleInputScalarFunction.Function
        /// and returns the result, which in turn may be evaluated at a point to determine velocity,
        /// acceleration, jerk, snap, crackle, pop, or some other higher order derivative.
        /// </summary>
        /// <param name="n">The number of times which the mathematical representation of
        /// ISingleInputScalarFunction.Function should be differentiated.</param>
        /// <returns>A new ISingleInputScalarFunction instance whose Function property may be evaluated
        /// by passing it any real (double) value.</returns>
        ISingleInputScalarFunction GetNthOrderDerivative(int n);
    }
}
