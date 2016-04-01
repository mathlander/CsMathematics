using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsMathematics.LinearAlgebra
{
    public interface IReadOnlyVector : IEquatable<IVector>, IEquatable<IReadOnlyVector>, IEnumerable<double>
    {
        /// <summary>
        /// Returns the number of elements in the vector.
        /// </summary>
        int Length { get; }

        /// <summary>
        /// Gets the vector value at the specified index.  Valid values are 1 through Length.
        /// </summary>
        /// <param name="index">The index of the element which should be returned.</param>
        /// <returns>The value at the specified vector index.</returns>
        double this[int index] { get; }


        /// <summary>
        /// Performs the binary operation of vector addition.
        /// </summary>
        /// <param name="vector">The vector whose values should be added to those of the current instance.</param>
        /// <returns>A new IReadOnlyVector instance resulting from the addition of the current vector to the input vector.</returns>
        IReadOnlyVector Add(IVector vector);

        /// <summary>
        /// Performs the binary operation of vector addition.
        /// </summary>
        /// <param name="vector">The vector whose values should be added to those of the current instance.</param>
        /// <returns>A new IReadOnlyVector instance resulting from the addition of the current vector to the input vector.</returns>
        IReadOnlyVector Add(IReadOnlyVector vector);

        /// <summary>
        /// Performs the binary operation of vector subtraction.
        /// </summary>
        /// <param name="vector">The vector whose values should be subtracted from those of the current instance.</param>
        /// <returns>A new IReadOnlyVector instance resulting from the subtraction of the input vector from the current vector.</returns>
        IReadOnlyVector Subtract(IVector vector);

        /// <summary>
        /// Performs the binary operation of vector subtraction.
        /// </summary>
        /// <param name="vector">The vector whose values should be subtracted from those of the current instance.</param>
        /// <returns>A new IReadOnlyVector instance resulting from the subtraction of the input vector from the current vector.</returns>
        IReadOnlyVector Subtract(IReadOnlyVector vector);

        /// <summary>
        /// Performs the binary operation of an inner product.
        /// </summary>
        /// <param name="vector">The second input to the inner product.</param>
        /// <returns>The value resulting from the inner product.</returns>
        double InnerProduct(IVector vector);

        /// <summary>
        /// Performs the binary operation of an inner product.
        /// </summary>
        /// <param name="vector">The second input to the inner product.</param>
        /// <returns>The value resulting from the inner product.</returns>
        double InnerProduct(IReadOnlyVector vector);

        /// <summary>
        /// Performs multiplication on the current vector and the input vector as that of an mx1 matrix multiplied with a 1xn matrix.
        /// </summary>
        /// <param name="vector">A vector which will act as a 1xn matrix for the purposes of matrix multiplication.</param>
        /// <returns>A new IReadOnlyMatrix instance which results from matrix multiplication of a column vector with a row vector.</returns>
        IReadOnlyMatrix OuterProduct(IVector vector);

        /// <summary>
        /// Performs multiplication on the current vector and the input vector as that of an mx1 matrix multiplied with a 1xn matrix.
        /// </summary>
        /// <param name="vector">A vector which will act as a 1xn matrix for the purposes of matrix multiplication.</param>
        /// <returns>A new IReadOnlyMatrix instance which results from matrix multiplication of a column vector with a row vector.</returns>
        IReadOnlyMatrix OuterProduct(IReadOnlyVector vector);

        /// <summary>
        /// Multiplies every element of the vector by the scalar parameter.
        /// </summary>
        /// <param name="scalar">The scaling factor for the vector.</param>
        /// <returns>A new IReadOnlyVector instance parallel to the current instance and scaled by the 'scalar' factor.</returns>
        IReadOnlyVector MultiplyByScalar(double scalar);
    }
}
