using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsMathematics.Functions;
using CsMathematics.LinearAlgebra;

namespace CsMathematics.Calculus
{
    /// <summary>
    /// 
    /// </summary>
    public class ParametricCurve : IParametricCurve
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="scalarFunctions"></param>
        public ParametricCurve(IEnumerable<IScalarFunction> scalarFunctions)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t_i"></param>
        /// <returns></returns>
        public IVector Evaluate(double t_i)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IParametricCurve DifferentiateWrtTime()
        {
            throw new NotImplementedException();
        }
    }
}
