using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using CsMathematics.Functions;

namespace CsMathematics.ComplexAnalysis
{
    internal class HolomorphicFunction : IHolomorphicFunction
    {
        // a holomorphic function f(z=x+iy) := u(x,y) + iv(x,y), where both u(x,y) and v(x,y) : R^2 => R
        // this class would expose a property for the real valued harmonic conjugate functions u, v

        public Func<Complex, Complex> Function { get; private set; }

        // if not provided explicitly via a constructor, this can be implicitly defined via a call to Function(new Complex(double, double))
        // and returning the real part of the result
        public IScalarFieldFunction RealHarmonicConjugate { get; private set; }

        // if not provided explicitly via a constructor, this can be implicitly defined via a call to Function(new Complex(double, double))
        // and returning the imaginary part of the result
        public IScalarFieldFunction ComplexHarmonicConjugate { get; private set; }
    }
}
