using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsMathematics.LinearAlgebra;

namespace CsMathematics.Functions
{
    /// <summary>
    /// Represents a matrix of operators, such as a Jacobian or Hessian.
    /// </summary>
    public interface IMatrixOperator
    {
        /// <summary>
        /// The IVectorOperator instances which comprise the rows of the IMatrixOperator.
        /// </summary>
        IEnumerable<IVectorOperator> Rows { get; }


        /// <summary>
        /// Evaluates the input vector by invoking the Evaluate() method of every element
        /// in the IMatrixOperator.
        /// </summary>
        /// <param name="vector">The point at which each of the component functionals should
        /// be evaluated.</param>
        /// <returns>An IMatrix instance which is the composite output of all of the component
        /// functionals within the IMatrixOperator instance.</returns>
        IMatrix Evaluate(IVector vector);
    }
}
