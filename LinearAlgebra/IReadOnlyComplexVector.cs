using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CsMathematics.LinearAlgebra
{
    internal interface IReadOnlyComplexVector : IEquatable<IComplexVector>, IEquatable<IReadOnlyComplexVector>, IEquatable<IVector>, IEquatable<IReadOnlyVector>, IEnumerable<Complex>
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
        Complex this[int index] { get; }


        /// <summary>
        /// Performs the binary operation of vector addition.
        /// </summary>
        /// <param name="vector">The vector whose values should be added to those of the current instance.</param>
        /// <returns>A new IReadOnlyComplexVector instance resulting from the addition of the current vector to the input vector.</returns>
        IReadOnlyComplexVector Add(IComplexVector vector);

        /// <summary>
        /// Performs the binary operation of vector addition.
        /// </summary>
        /// <param name="vector">The vector whose values should be added to those of the current instance.</param>
        /// <returns>A new IReadOnlyComplexVector instance resulting from the addition of the current vector to the input vector.</returns>
        IReadOnlyComplexVector Add(IReadOnlyComplexVector vector);

        /// <summary>
        /// Performs the binary operation of vector addition.
        /// </summary>
        /// <param name="vector">The vector whose values should be added to those of the current instance.</param>
        /// <returns>A new IReadOnlyComplexVector instance resulting from the addition of the current vector to the input vector.</returns>
        IReadOnlyComplexVector Add(IVector vector);

        /// <summary>
        /// Performs the binary operation of vector addition.
        /// </summary>
        /// <param name="vector">The vector whose values should be added to those of the current instance.</param>
        /// <returns>A new IReadOnlyComplexVector instance resulting from the addition of the current vector to the input vector.</returns>
        IReadOnlyComplexVector Add(IReadOnlyVector vector);

        /// <summary>
        /// Performs the binary operation of vector subtraction.
        /// </summary>
        /// <param name="vector">The vector whose values should be subtracted from those of the current instance.</param>
        /// <returns>A new IReadOnlyComplexVector instance resulting from the subtraction of the input vector from the current vector.</returns>
        IReadOnlyComplexVector Subtract(IComplexVector vector);

        /// <summary>
        /// Performs the binary operation of vector subtraction.
        /// </summary>
        /// <param name="vector">The vector whose values should be subtracted from those of the current instance.</param>
        /// <returns>A new IReadOnlyComplexVector instance resulting from the subtraction of the input vector from the current vector.</returns>
        IReadOnlyComplexVector Subtract(IReadOnlyComplexVector vector);

        /// <summary>
        /// Performs the binary operation of vector subtraction.
        /// </summary>
        /// <param name="vector">The vector whose values should be subtracted from those of the current instance.</param>
        /// <returns>A new IReadOnlyComplexVector instance resulting from the subtraction of the input vector from the current vector.</returns>
        IReadOnlyComplexVector Subtract(IVector vector);

        /// <summary>
        /// Performs the binary operation of vector subtraction.
        /// </summary>
        /// <param name="vector">The vector whose values should be subtracted from those of the current instance.</param>
        /// <returns>A new IReadOnlyComplexVector instance resulting from the subtraction of the input vector from the current vector.</returns>
        IReadOnlyComplexVector Subtract(IReadOnlyVector vector);

        /// <summary>
        /// Performs the binary operation of a sesquilinear inner product.  For column vectors u, v this represents u^* * v = x,
        /// where we have taken the conjugate transpose of u (the current vector) and performed an inner product with v (the input vector)
        /// get a scalar value x (the complex value returned).
        /// </summary>
        /// <param name="vector">The second input to the sesquilinear inner product.</param>
        /// <returns>The complex value resulting from the sesquilinear inner product.</returns>
        Complex SesquilinearInnerProduct(IComplexVector vector);

        /// <summary>
        /// Performs the binary operation of a sesquilinear inner product.  For column vectors u, v this represents u^* * v = x,
        /// where we have taken the conjugate transpose of u (the current vector) and performed an inner product with v (the input vector)
        /// get a scalar value x (the complex value returned).
        /// </summary>
        /// <param name="vector">The second input to the sesquilinear inner product.</param>
        /// <returns>The complex value resulting from the sesquilinear inner product.</returns>
        Complex SesquilinearInnerProduct(IReadOnlyComplexVector vector);

        /// <summary>
        /// Performs the binary operation of a sesquilinear inner product.  For column vectors u, v this represents u^* * v = x,
        /// where we have taken the conjugate transpose of u (the current vector) and performed an inner product with v (the input vector)
        /// get a scalar value x (the complex value returned).
        /// </summary>
        /// <param name="vector">The second input to the sesquilinear inner product.</param>
        /// <returns>The complex value resulting from the sesquilinear inner product.</returns>
        Complex SesquilinearInnerProduct(IVector vector);

        /// <summary>
        /// Performs the binary operation of a sesquilinear inner product.  For column vectors u, v this represents u^* * v = x,
        /// where we have taken the conjugate transpose of u (the current vector) and performed an inner product with v (the input vector)
        /// get a scalar value x (the complex value returned).
        /// </summary>
        /// <param name="vector">The second input to the sesquilinear inner product.</param>
        /// <returns>The complex value resulting from the sesquilinear inner product.</returns>
        Complex SesquilinearInnerProduct(IReadOnlyVector vector);

        /// <summary>
        /// Performs multiplication on the current vector and the input vector as that of an mx1 matrix multiplied with a 1xn matrix.
        /// </summary>
        /// <param name="vector">A vector which will act as a 1xn matrix for the purposes of matrix multiplication.</param>
        /// <returns>A new IReadOnlyComplexMatrix instance which results from matrix multiplication of a column vector with a row vector.</returns>
        IReadOnlyComplexMatrix OuterProduct(IComplexVector vector);

        /// <summary>
        /// Performs multiplication on the current vector and the input vector as that of an mx1 matrix multiplied with a 1xn matrix.
        /// </summary>
        /// <param name="vector">A vector which will act as a 1xn matrix for the purposes of matrix multiplication.</param>
        /// <returns>A new IReadOnlyComplexMatrix instance which results from matrix multiplication of a column vector with a row vector.</returns>
        IReadOnlyComplexMatrix OuterProduct(IReadOnlyComplexVector vector);

        /// <summary>
        /// Performs multiplication on the current vector and the input vector as that of an mx1 matrix multiplied with a 1xn matrix.
        /// </summary>
        /// <param name="vector">A vector which will act as a 1xn matrix for the purposes of matrix multiplication.</param>
        /// <returns>A new IReadOnlyComplexMatrix instance which results from matrix multiplication of a column vector with a row vector.</returns>
        IReadOnlyComplexMatrix OuterProduct(IVector vector);

        /// <summary>
        /// Performs multiplication on the current vector and the input vector as that of an mx1 matrix multiplied with a 1xn matrix.
        /// </summary>
        /// <param name="vector">A vector which will act as a 1xn matrix for the purposes of matrix multiplication.</param>
        /// <returns>A new IReadOnlyComplexMatrix instance which results from matrix multiplication of a column vector with a row vector.</returns>
        IReadOnlyComplexMatrix OuterProduct(IReadOnlyVector vector);

        /// <summary>
        /// Multiplies every element of the vector by the scalar parameter.
        /// </summary>
        /// <param name="scalar">The scaling factor for the vector.</param>
        /// <returns>A new IReadOnlyComplexVector instance parallel to the current instance and scaled by the 'scalar' factor.</returns>
        IReadOnlyComplexVector MultiplyByScalar(Complex scalar);

        /// <summary>
        /// Multiplies every element of the vector by the scalar parameter.
        /// </summary>
        /// <param name="scalar">The scaling factor for the vector.</param>
        /// <returns>A new IReadOnlyComplexVector instance parallel to the current instance and scaled by the 'scalar' factor.</returns>
        IReadOnlyComplexVector MultiplyByScalar(double scalar);
    }
}
