using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using CsMathematics.Functions;

namespace CsMathematics.ComplexAnalysis
{
    /// <summary>
    /// Represents a complex differentiable function.
    /// </summary>
    interface IHolomorphicFunction
    {
        /// <summary>
        /// If not provided explicitly via a constructor, this can be implicitly defined via a call to Evaluate(new Complex(double, double))
        /// and returning the real part of the result.
        /// </summary>
        IFunctional RealHarmonicConjugate { get; }

        /// <summary>
        /// If not provided explicitly via a constructor, this can be implicitly defined via a call to Function(new Complex(double, double))
        /// and returning the imaginary part of the result.
        /// </summary>
        IFunctional ComplexHarmonicConjugate { get; }


        /// <summary>
        /// Evaluates the current IHolomorphicFunction at the point z.
        /// </summary>
        /// <param name="z">The point at which the current function should be evaluated.</param>
        /// <returns>A complex value.</returns>
        Complex Evaluate(Complex z);
    }
}
