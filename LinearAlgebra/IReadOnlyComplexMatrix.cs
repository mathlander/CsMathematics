using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CsMathematics.LinearAlgebra
{
    /// <summary>
    /// Represents a read-only matrix of complex values.
    /// </summary>
    internal interface IReadOnlyComplexMatrix : IEquatable<IComplexMatrix>, IEquatable<IReadOnlyComplexMatrix>, IEquatable<IMatrix>, IEquatable<IReadOnlyMatrix>
    {
        /// <summary>
        /// The number of rows in the matrix.
        /// </summary>
        int RowCount { get; }

        /// <summary>
        /// The number of columns in the matrix.
        /// </summary>
        int ColumnCount { get; }

        /// <summary>
        /// Gets the complex value at the specified matrix row and index.
        /// </summary>
        /// <param name="row">The row for the element to be returned or updated.</param>
        /// <param name="col">The column for the element to be returned or updated.</param>
        /// <returns>The complex value at the specified row and column.</returns>
        Complex this[int row, int col] { get; }


        /// <summary>
        /// Returns a copy of the row vector at the specified rowId.
        /// </summary>
        /// <param name="rowId">The row number whose values should be returned.</param>
        /// <returns>A copy of the row vector at the specified rowId.</returns>
        IReadOnlyComplexVector GetRow(int rowId);

        /// <summary>
        /// Returns a copy of the column vector at the specified columnId.
        /// </summary>
        /// <param name="columnId">The column number whose values should be returned.</param>
        /// <returns>A copy of the column vector at the specified columnId.</returns>
        IReadOnlyComplexVector GetColumn(int columnId);

        /// <summary>
        /// Returns a collection of IReadOnlyComplexVector instances which are copies of the row vectors
        /// which make up the current IReadOnlyComplexMatrix instance.
        /// </summary>
        /// <returns>A collection of IReadOnlyComplexVector instances copied from the row vectors of
        /// the current IReadOnlyComplexMatrix instance.</returns>
        IEnumerable<IReadOnlyComplexVector> GetRows();

        /// <summary>
        /// Returns a collection of IReadOnlyComplexVector instances which are copies of the column vectors
        /// which make up the current IReadOnlyComplexMatrix instance.
        /// </summary>
        /// <returns>A collection of IReadOnlyComplexVector instances copied from the column vectors of
        /// the current IReadOnlyComplexMatrix instance.</returns>
        IEnumerable<IReadOnlyComplexVector> GetColumns();

        /// <summary>
        /// Defines the operation of matrix addition.  The elements of the input matrix are
        /// added to the elements of the current IReadOnlyComplexMatrix instance.
        /// </summary>
        /// <param name="matrix">The matrix whose elements should be added to the current instance.</param>
        /// <returns>A new instance of IReadOnlyComplexMatrix composed of the elements from the binary
        /// operation of addition of two matrices.</returns>
        IReadOnlyComplexMatrix Add(IReadOnlyComplexMatrix matrix);

        /// <summary>
        /// Defines the operation of matrix addition.  The elements of the input matrix are
        /// added to the elements of the current IReadOnlyComplexMatrix instance.
        /// </summary>
        /// <param name="matrix">The matrix whose elements should be added to the current instance.</param>
        /// <returns>A new instance of IReadOnlyComplexMatrix composed of the elements from the binary
        /// operation of addition of two matrices.</returns>
        IReadOnlyComplexMatrix Add(IReadOnlyMatrix matrix);

        /// <summary>
        /// Defines the operation of matrix addition.  The elements of the input matrix are
        /// added to the elements of the current IReadOnlyComplexMatrix instance.
        /// </summary>
        /// <param name="matrix">The matrix whose elements should be added to the current instance.</param>
        /// <returns>A new instance of IReadOnlyComplexMatrix composed of the elements from the binary
        /// operation of addition of two matrices.</returns>
        IReadOnlyComplexMatrix Add(IComplexMatrix matrix);

        /// <summary>
        /// Defines the operation of matrix addition.  The elements of the input matrix are
        /// added to the elements of the current IReadOnlyComplexMatrix instance.
        /// </summary>
        /// <param name="matrix">The matrix whose elements should be added to the current instance.</param>
        /// <returns>A new instance of IReadOnlyComplexMatrix composed of the elements from the binary
        /// operation of addition of two matrices.</returns>
        IReadOnlyComplexMatrix Add(IMatrix matrix);

        /// <summary>
        /// Defines the operation of matrix subtraction.  The elements of the input matrix are
        /// subtracted from the elements of the current IReadOnlyComplexMatrix instance.
        /// </summary>
        /// <param name="matrix">The matrix whose elements should be subtracted from the current instance.</param>
        /// <returns>A new instance of IReadOnlyComplexMatrix composed of the elements from the binary
        /// operation of subtraction of the input matrix from the current instance.</returns>
        IReadOnlyComplexMatrix Subtract(IReadOnlyComplexMatrix matrix);

        /// <summary>
        /// Defines the operation of matrix subtraction.  The elements of the input matrix are
        /// subtracted from the elements of the current IReadOnlyComplexMatrix instance.
        /// </summary>
        /// <param name="matrix">The matrix whose elements should be subtracted from the current instance.</param>
        /// <returns>A new instance of IReadOnlyComplexMatrix composed of the elements from the binary
        /// operation of subtraction of the input matrix from the current instance.</returns>
        IReadOnlyComplexMatrix Subtract(IReadOnlyMatrix matrix);

        /// <summary>
        /// Defines the operation of matrix subtraction.  The elements of the input matrix are
        /// subtracted from the elements of the current IReadOnlyComplexMatrix instance.
        /// </summary>
        /// <param name="matrix">The matrix whose elements should be subtracted from the current instance.</param>
        /// <returns>A new instance of IReadOnlyComplexMatrix composed of the elements from the binary
        /// operation of subtraction of the input matrix from the current instance.</returns>
        IReadOnlyComplexMatrix Subtract(IComplexMatrix matrix);

        /// <summary>
        /// Defines the operation of matrix subtraction.  The elements of the input matrix are
        /// subtracted from the elements of the current IReadOnlyComplexMatrix instance.
        /// </summary>
        /// <param name="matrix">The matrix whose elements should be subtracted from the current instance.</param>
        /// <returns>A new instance of IReadOnlyComplexMatrix composed of the elements from the binary
        /// operation of subtraction of the input matrix from the current instance.</returns>
        IReadOnlyComplexMatrix Subtract(IMatrix matrix);

        /// <summary>
        /// Defines the operation of matrix multiplication.  Let A, B, C be matrices and multiplication defined as A * B = C.
        /// Then, the current IReadOnlyComplexMatrix instance is represented A, the input matrix is represented by B, and the result
        /// of the product is represented by C.
        /// </summary>
        /// <param name="matrix">For matrix multiplication given by A * B = C, the input matrix is represented by B.</param>
        /// <returns>A new IReadOnlyComplexMatrix instance which is the product of the current IReadOnlyComplexMatrix instance and the input matrix.</returns>
        IReadOnlyComplexMatrix Multiply(IReadOnlyComplexMatrix matrix);

        /// <summary>
        /// Defines the operation of matrix multiplication.  Let A, B, C be matrices and multiplication defined as A * B = C.
        /// Then, the current IReadOnlyComplexMatrix instance is represented A, the input matrix is represented by B, and the result
        /// of the product is represented by C.
        /// </summary>
        /// <param name="matrix">For matrix multiplication given by A * B = C, the input matrix is represented by B.</param>
        /// <returns>A new IReadOnlyComplexMatrix instance which is the product of the current IReadOnlyComplexMatrix instance and the input matrix.</returns>
        IReadOnlyComplexMatrix Multiply(IReadOnlyMatrix matrix);

        /// <summary>
        /// Defines the operation of matrix multiplication.  Let A, B, C be matrices and multiplication defined as A * B = C.
        /// Then, the current IReadOnlyComplexMatrix instance is represented A, the input matrix is represented by B, and the result
        /// of the product is represented by C.
        /// </summary>
        /// <param name="matrix">For matrix multiplication given by A * B = C, the input matrix is represented by B.</param>
        /// <returns>A new IReadOnlyComplexMatrix instance which is the product of the current IReadOnlyComplexMatrix instance and the input matrix.</returns>
        IReadOnlyComplexMatrix Multiply(IComplexMatrix matrix);

        /// <summary>
        /// Defines the operation of matrix multiplication.  Let A, B, C be matrices and multiplication defined as A * B = C.
        /// Then, the current IReadOnlyComplexMatrix instance is represented A, the input matrix is represented by B, and the result
        /// of the product is represented by C.
        /// </summary>
        /// <param name="matrix">For matrix multiplication given by A * B = C, the input matrix is represented by B.</param>
        /// <returns>A new IReadOnlyComplexMatrix instance which is the product of the current IReadOnlyComplexMatrix instance and the input matrix.</returns>
        IReadOnlyComplexMatrix Multiply(IMatrix matrix);

        /// <summary>
        /// Defines the operation of scalar matrix multiplication.
        /// </summary>
        /// <param name="matrix">The complex value by which all elements in the matrix should be multiplied.</param>
        /// <returns>A new IReadOnlyComplexMatrix instance which is the product of the current IReadOnlyComplexMatrix and the input scalar.</returns>
        IReadOnlyComplexMatrix MultiplyByScalar(Complex scalar);

        /// <summary>
        /// Defines the operation of scalar matrix multiplication.
        /// </summary>
        /// <param name="matrix">The real (double) value by which all elements in the matrix should be multiplied.</param>
        /// <returns>A new IReadOnlyComplexMatrix instance which is the product of the current IReadOnlyComplexMatrix and the input scalar.</returns>
        IReadOnlyComplexMatrix MultiplyByScalar(double scalar);
    }
}
