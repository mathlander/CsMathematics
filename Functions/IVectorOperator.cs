using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsMathematics.LinearAlgebra;

namespace CsMathematics.Functions
{
    /// <summary>
    /// Represents a vector of operators, such as a system of differential equations or a gradient.
    /// </summary>
    public interface IVectorOperator : IEnumerable<IFunctional>
    {
        /// <summary>
        /// The collection of functionals which make up the elements of the IVectorOperator.
        /// </summary>
        IEnumerable<IFunctional> Components { get; }

        /// <summary>
        /// Evaluates the input vector and returns a vector in the range of the IVectorOperator instance.
        /// </summary>
        /// <param name="vector">The point which is being evaluated.</param>
        /// <returns>An IVector instance which is the result of the IVectorOperator instance acting on the input vector.</returns>
        IVector Evaluate(IVector vector);
    }
}
