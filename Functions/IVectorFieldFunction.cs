using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsMathematics.LinearAlgebra;

namespace CsMathematics.Functions
{
    /// <summary>
    /// Represents a vector function which takes a vector of real (double) values as input and outputs
    /// a vector of real (double) values.
    /// </summary>
    public interface IVectorFieldFunction
    {
        /// <summary>
        /// A mathematical function which maps a R^m -> R^n.
        /// </summary>
        Func<IVector, IVector> Function { get; }

        /// <summary>
        /// Differentiates the mathematical function represented by IScalarFieldFunction.Function
        /// and returns the result, which in turn may be evaluated at a point to determine velocity,
        /// acceleration, jerk, snap, crackle, pop, or some other higher order derivative vector.
        /// </summary>
        /// <param name="n">The number of times which the mathematical representation of
        /// IVectorFieldFunction.Function should be differentiated.</param>
        /// <returns>A new IVectorFieldFunction instance whose Function property may be evaluated
        /// by passing it an IVector instance of the same length as the input to the original
        /// IVectorFieldFunction.Function.</returns>
        IVectorFieldFunction GetNthOrderDerivative(int n);
    }
}
