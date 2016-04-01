using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsMathematics.LinearAlgebra
{
    public interface IVector : IEquatable<IVector>, IEquatable<IReadOnlyVector>, IEnumerable<double>
    {
        /// <summary>
        /// Returns the number of elements in the vector.
        /// </summary>
        int Length { get; }

        /// <summary>
        /// Gets or sets the vector value at the specified index.  Valid values are 1 through Length.
        /// </summary>
        /// <param name="index">The index of the element which should be returned or updated.</param>
        /// <returns>The value at the specified vector index.</returns>
        double this[int index] { get; set; }


        /// <summary>
        /// Performs the binary operation of vector addition.
        /// </summary>
        /// <param name="vector">The vector whose values should be added to those of the current instance.</param>
        /// <returns>A new IVector instance resulting from the addition of the current vector to the input vector.</returns>
        IVector Add(IVector vector);

        /// <summary>
        /// Performs the binary operation of vector addition.
        /// </summary>
        /// <param name="vector">The vector whose values should be added to those of the current instance.</param>
        /// <returns>A new IVector instance resulting from the addition of the current vector to the input vector.</returns>
        IVector Add(IReadOnlyVector vector);

        /// <summary>
        /// Performs the binary operation of vector subtraction.
        /// </summary>
        /// <param name="vector">The vector whose values should be subtracted from those of the current instance.</param>
        /// <returns>A new IVector instance resulting from the subtraction of the input vector from the current vector.</returns>
        IVector Subtract(IVector vector);

        /// <summary>
        /// Performs the binary operation of vector subtraction.
        /// </summary>
        /// <param name="vector">The vector whose values should be subtracted from those of the current instance.</param>
        /// <returns>A new IVector instance resulting from the subtraction of the input vector from the current vector.</returns>
        IVector Subtract(IReadOnlyVector vector);

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
        /// <returns>A new IMatrix instance which results from matrix multiplication of a column vector with a row vector.</returns>
        IMatrix OuterProduct(IVector vector);

        /// <summary>
        /// Performs multiplication on the current vector and the input vector as that of an mx1 matrix multiplied with a 1xn matrix.
        /// </summary>
        /// <param name="vector">A vector which will act as a 1xn matrix for the purposes of matrix multiplication.</param>
        /// <returns>A new IMatrix instance which results from matrix multiplication of a column vector with a row vector.</returns>
        IMatrix OuterProduct(IReadOnlyVector vector);

        /// <summary>
        /// Multiplies every element of the vector by the scalar parameter.
        /// </summary>
        /// <param name="scalar">The scaling factor for the vector.</param>
        /// <returns>A new IVector instance parallel to the current instance and scaled by the 'scalar' factor.</returns>
        IVector MultiplyByScalar(double scalar);

        double DotProduct(IVector vector);

        IVector ToUnitVector();

        /// <summary>
        /// Returns a vector with all elements set to zero, except for the one at 'ordinal'.
        /// </summary>
        /// <param name="ordinal">The index for the vector element to keep.</param>
        /// <returns>A vector with zeros at every position except the one with index == 'ordinal'.</returns>
        IVector ProjectOntoCoordinate(int ordinal);

        /// <summary>
        /// Applies vector projection of the current IVector instance onto the input instance.  Vector projection is given by
        /// a_b = a * (b / ||b||), i.e. the projection of 'a' onto 'b' is equal to the dot product of 'a' and the unit length vector
        /// which is parallel to 'b'.
        /// </summary>
        /// <param name="vector">The vector being projected onto.  That is, the result vector will be parallel to this input vector.</param>
        /// <returns>The projection vector.  This is equal to (||a|| * cos(\theta), where \theta is the angle between vectors 'a', 'b'.</returns>
        IVector ProjectOntoVector(IVector vector);

        IVector Clone();
    }
}
