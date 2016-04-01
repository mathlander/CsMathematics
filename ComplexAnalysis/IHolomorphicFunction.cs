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
        /// A holomorphic function f(z=x+iy) := u(x,y) + iv(x,y), where both u(x,y) and v(x,y) : R^2 => R.
        /// </summary>
        Func<Complex, Complex> Function { get; }

        /// <summary>
        /// If not provided explicitly via a constructor, this can be implicitly defined via a call to Function(new Complex(double, double))
        /// and returning the real part of the result
        /// </summary>
        IScalarFieldFunction RealHarmonicConjugate { get; }
        //public Func<double, double, double> RealHarmonicConjugate { get; }

        /// <summary>
        /// If not provided explicitly via a constructor, this can be implicitly defined via a call to Function(new Complex(double, double))
        /// and returning the imaginary part of the result
        /// </summary>
        IScalarFieldFunction ComplexHarmonicConjugate { get; }
    }
}
