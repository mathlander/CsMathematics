using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsMathematics.LinearAlgebra;

namespace CsMathematics.Functions
{
    internal class ConstantFunction : IFunctional
    {
        private static readonly IFunctional _zeroFunction = new ConstantFunction(0.0);

        private readonly double _scalar;

        public ConstantFunction(double scalar)
        {
            _scalar = scalar;
        }

        public static IFunctional Zero { get { return _zeroFunction; } }

        public double Evaluate(IVector pointVector)
        {
            return _scalar;
        }

        public IFunction DifferentiateWrtKthParameter(int k)
        {
            return Zero;
        }

        IVector IFunction.Evaluate(IVector pointVector)
        {
            return new Vector(new[] { _scalar });
        }
    }
}
