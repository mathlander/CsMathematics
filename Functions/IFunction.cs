using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsMathematics.LinearAlgebra;

namespace CsMathematics.Functions
{
    /// <summary>
    /// Represents f: R^m -&gt; R^n, where f is continuous over R^m for some region with measure greater than zero.
    /// </summary>
    public interface IFunction
    {

        /// <summary>
        /// Evaluates the input vector of length InputDimension (m) and returns vector of length OutputDimension (n).
        /// </summary>
        /// <param name="pointVector">The point which f is evaluating.</param>
        /// <returns>An IVector with length OutputDimension (n).</returns>
        IVector Evaluate(IVector pointVector);

        /// <summary>
        /// Let f: R^m -&gt; R^n.  This method returns the partial derivative of the current function with respect
        /// to the kth input variable, where k is an integer between 1 and m.
        /// </summary>
        /// <param name="k">The variable ID (between 1 and m).</param>
        /// <returns>A new IFunction instance which represents a partial derivative of the current instance with
        /// respect to the kth input parameter.</returns>
        IFunction DifferentiateWrtKthParameter(int k);
    }
}
