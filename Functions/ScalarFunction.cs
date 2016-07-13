using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsMathematics.Calculus;
using CsMathematics.LinearAlgebra;

namespace CsMathematics.Functions
{
    public class ScalarFunction : IScalarFunction
    {


        public ScalarFunction(IEnumerable<IDifferentiableTerm> terms)
        {
        }

        public double Evaluate(double t_i)
        {
            throw new NotImplementedException();
        }

        public IScalarFunction Differentiate()
        {
            throw new NotImplementedException();
        }

        public double Evaluate(LinearAlgebra.IVector pointVector)
        {
            throw new NotImplementedException();
        }

        public IFunctional DifferentiateWrtKthParameter(int k)
        {
            throw new NotImplementedException();
        }

        IGradient IFunctional.Differentiate()
        {
            throw new NotImplementedException();
        }

        IVector IFunction.Evaluate(LinearAlgebra.IVector pointVector)
        {
            throw new NotImplementedException();
        }

        IFunction IFunction.DifferentiateWrtKthParameter(int k)
        {
            throw new NotImplementedException();
        }

        IJacobian IFunction.Differentiate()
        {
            throw new NotImplementedException();
        }
    }
}
