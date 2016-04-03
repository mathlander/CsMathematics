using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsMathematics.Calculus;
using CsMathematics.LinearAlgebra;

namespace CsMathematics.Functions
{
    public class ConstantFunction : IFunctional
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

        double IFunctional.Evaluate(IVector pointVector)
        {
            throw new NotImplementedException();
        }

        IVector IFunction.Evaluate(IVector pointVector)
        {
            return new Vector(new[] { _scalar });
        }

        public IFunctional DifferentiateWrtKthParameter(int k)
        {
            return Zero;
        }

        IFunction IFunction.DifferentiateWrtKthParameter(int k)
        {
            return this.DifferentiateWrtKthParameter(k);
        }

        public IJacobian Differentiate()
        {
            return new Jacobian(new[] { new VectorOperator(new[] { Zero }) });
        }

        IGradient IFunctional.Differentiate()
        {
            return new Gradient(new[] { Zero });
        }

        IJacobian IFunction.Differentiate()
        {
            return this.Differentiate();
        }
    }
}
