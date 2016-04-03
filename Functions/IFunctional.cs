using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsMathematics.Calculus;
using CsMathematics.LinearAlgebra;

namespace CsMathematics.Functions
{
    /// <summary>
    /// Represents f(x): R^n -&gt; R, where f is continuous over some interval with measure greater than zero.
    /// </summary>
    public interface IFunctional : IFunction
    {
        /// <summary>
        /// Takes an IVector instance and maps it to a real (double) value.
        /// </summary>
        /// <param name="pointVector">The input vector, i.e. an element of R^n.</param>
        /// <returns>A scalar (double) value.</returns>
        new double Evaluate(IVector pointVector);

        /// <summary>
        /// Let f: R^m -&gt; R^n.  This method returns the partial derivative of the current function with respect
        /// to the kth input variable, where k is an integer between 1 and m.
        /// </summary>
        /// <param name="k">The variable ID (between 1 and m).</param>
        /// <returns>A new IFunction instance which represents a partial derivative of the current instance with
        /// respect to the kth input parameter.</returns>
        new IFunctional DifferentiateWrtKthParameter(int k);

        /// <summary>
        /// Computes the vector of partial derivatives.  For a function f: R^n -&gt; R, this is an IVectorOperator
        /// with n elements.
        /// </summary>
        /// <returns>The gradient of the current IFunctional instance.</returns>
        new IGradient Differentiate();
    }
}
