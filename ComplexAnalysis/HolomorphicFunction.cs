using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using CsMathematics.Functions;
using CsMathematics.LinearAlgebra;

namespace CsMathematics.ComplexAnalysis
{
    /// <summary>
    /// Represents a holomorphic function f: C -> C.  Let u(x,y) and v(x,y) : R^2 -&gt; R, then f is given by f(z=x+iy) := u(x,y) + iv(x,y).
    /// This interface exposes a property for the real valued harmonic conjugate functions u, v.
    /// </summary>
    internal class HolomorphicFunction : IHolomorphicFunction
    {
        public HolomorphicFunction(IFunctional realHarmonicConjugate, IFunctional complexHarmonicConjugate)
        {
            RealHarmonicConjugate = realHarmonicConjugate;
            ComplexHarmonicConjugate = complexHarmonicConjugate;
        }

        public IFunctional RealHarmonicConjugate { get; private set; }
        public IFunctional ComplexHarmonicConjugate { get; private set; }

        public Complex Evaluate(Complex z)
        {
            var complexVector = new Vector(new[] {z.Real, z.Imaginary});
            var real = RealHarmonicConjugate.Evaluate(complexVector);
            var imag = ComplexHarmonicConjugate.Evaluate(complexVector);

            return new Complex(real, imag);
        }
    }
}
