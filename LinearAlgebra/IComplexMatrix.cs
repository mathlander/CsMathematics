using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CsMathematics.LinearAlgebra
{
    /// <summary>
    /// Represents a matrix of complex values.
    /// </summary>
    internal interface IComplexMatrix : IEquatable<IComplexMatrix>, IEquatable<IReadOnlyComplexMatrix>, IEquatable<IMatrix>, IEquatable<IReadOnlyMatrix>
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
        /// Gets or sets a complex value at the specified matrix row and index.
        /// </summary>
        /// <param name="row">The row for the element to be returned or updated.</param>
        /// <param name="col">The column for the element to be returned or updated.</param>
        /// <returns>The complex value at the specified row and column.</returns>
        Complex this[int row, int col] { get; set; }


        /// <summary>
        /// Replaces the specified row of the current IComplexMatrix instance with
        /// the values of the input IComplexVector instance.
        /// </summary>
        /// <param name="vector">A vector of new values for the IComplexMatrix at the specified row.</param>
        /// <param name="rowId">The row number which should be replaced.  Values may range from 1 to RowCount.</param>
        void OverwriteRow(IComplexVector vector, int rowId);

        /// <summary>
        /// Replaces the specified row of the current IComplexMatrix instance with
        /// the values of the input IComplexVector instance.
        /// </summary>
        /// <param name="vector">A vector of new values for the IComplexMatrix at the specified column.</param>
        /// <param name="columnId">The column number which should be replaced.  Values may range from 1 to ColumnCount.</param>
        void OverwriteColumn(IComplexVector vector, int columnId);

        /// <summary>
        /// Returns a copy of the row vector at the specified rowId.
        /// </summary>
        /// <param name="rowId">The row number whose values should be returned.</param>
        /// <returns>A copy of the row vector at the specified rowId.</returns>
        IComplexVector GetRow(int rowId);

        /// <summary>
        /// Returns a copy of the column vector at the specified columnId.
        /// </summary>
        /// <param name="columnId">The column number whose values should be returned.</param>
        /// <returns>A copy of the column vector at the specified columnId.</returns>
        IComplexVector GetColumn(int columnId);

        /// <summary>
        /// Returns a collection of IComplexVector instances which are copies of the row vectors
        /// which make up the current IComplexMatrix instance.
        /// </summary>
        /// <returns>A collection of IComplexVector instances copied from the row vectors of
        /// the current IComplexMatrix instance.</returns>
        IEnumerable<IComplexVector> GetRows();

        /// <summary>
        /// Returns a collection of IComplexVector instances which are copies of the column vectors
        /// which make up the current IComplexMatrix instance.
        /// </summary>
        /// <returns>A collection of IComplexVector instances copied from the column vectors of
        /// the current IComplexMatrix instance.</returns>
        IEnumerable<IComplexVector> GetColumns();

        /// <summary>
        /// Defines the operation of matrix addition.  The elements of the input matrix are
        /// added to the elements of the current IComplexMatrix instance.
        /// </summary>
        /// <param name="matrix">The matrix whose elements should be added to the current instance.</param>
        /// <returns>A new instance of IComplexMatrix composed of the elements from the binary
        /// operation of addition of two matrices.</returns>
        IComplexMatrix Add(IComplexMatrix matrix);

        /// <summary>
        /// Defines the operation of matrix addition.  The elements of the input matrix are
        /// added to the elements of the current IComplexMatrix instance.
        /// </summary>
        /// <param name="matrix">The matrix whose elements should be added to the current instance.</param>
        /// <returns>A new instance of IComplexMatrix composed of the elements from the binary
        /// operation of addition of two matrices.</returns>
        IComplexMatrix Add(IMatrix matrix);

        /// <summary>
        /// Defines the operation of matrix addition.  The elements of the input matrix are
        /// added to the elements of the current IComplexMatrix instance.
        /// </summary>
        /// <param name="matrix">The matrix whose elements should be added to the current instance.</param>
        /// <returns>A new instance of IComplexMatrix composed of the elements from the binary
        /// operation of addition of two matrices.</returns>
        IComplexMatrix Add(IReadOnlyComplexMatrix matrix);

        /// <summary>
        /// Defines the operation of matrix addition.  The elements of the input matrix are
        /// added to the elements of the current IComplexMatrix instance.
        /// </summary>
        /// <param name="matrix">The matrix whose elements should be added to the current instance.</param>
        /// <returns>A new instance of IComplexMatrix composed of the elements from the binary
        /// operation of addition of two matrices.</returns>
        IComplexMatrix Add(IReadOnlyMatrix matrix);

        /// <summary>
        /// Defines the operation of matrix subtraction.  The elements of the input matrix are
        /// subtracted from the elements of the current IComplexMatrix instance.
        /// </summary>
        /// <param name="matrix">The matrix whose elements should be subtracted from the current instance.</param>
        /// <returns>A new instance of IComplexMatrix composed of the elements from the binary
        /// operation of subtraction of the input matrix from the current instance.</returns>
        IComplexMatrix Subtract(IComplexMatrix matrix);

        /// <summary>
        /// Defines the operation of matrix subtraction.  The elements of the input matrix are
        /// subtracted from the elements of the current IComplexMatrix instance.
        /// </summary>
        /// <param name="matrix">The matrix whose elements should be subtracted from the current instance.</param>
        /// <returns>A new instance of IComplexMatrix composed of the elements from the binary
        /// operation of subtraction of the input matrix from the current instance.</returns>
        IComplexMatrix Subtract(IMatrix matrix);

        /// <summary>
        /// Defines the operation of matrix subtraction.  The elements of the input matrix are
        /// subtracted from the elements of the current IComplexMatrix instance.
        /// </summary>
        /// <param name="matrix">The matrix whose elements should be subtracted from the current instance.</param>
        /// <returns>A new instance of IComplexMatrix composed of the elements from the binary
        /// operation of subtraction of the input matrix from the current instance.</returns>
        IComplexMatrix Subtract(IReadOnlyComplexMatrix matrix);

        /// <summary>
        /// Defines the operation of matrix subtraction.  The elements of the input matrix are
        /// subtracted from the elements of the current IComplexMatrix instance.
        /// </summary>
        /// <param name="matrix">The matrix whose elements should be subtracted from the current instance.</param>
        /// <returns>A new instance of IComplexMatrix composed of the elements from the binary
        /// operation of subtraction of the input matrix from the current instance.</returns>
        IComplexMatrix Subtract(IReadOnlyMatrix matrix);

        /// <summary>
        /// Defines the operation of matrix multiplication.  Let A, B, C be matrices and multiplication defined as A * B = C.
        /// Then, the current IComplexMatrix instance is represented A, the input matrix is represented by B, and the result
        /// of the product is represented by C.
        /// </summary>
        /// <param name="matrix">For matrix multiplication given by A * B = C, the input matrix is represented by B.</param>
        /// <returns>A new IComplexMatrix instance which is the product of the current IComplexMatrix instance and the input matrix.</returns>
        IComplexMatrix Multiply(IComplexMatrix matrix);

        /// <summary>
        /// Defines the operation of matrix multiplication.  Let A, B, C be matrices and multiplication defined as A * B = C.
        /// Then, the current IComplexMatrix instance is represented A, the input matrix is represented by B, and the result
        /// of the product is represented by C.
        /// </summary>
        /// <param name="matrix">For matrix multiplication given by A * B = C, the input matrix is represented by B.</param>
        /// <returns>A new IComplexMatrix instance which is the product of the current IComplexMatrix instance and the input matrix.</returns>
        IComplexMatrix Multiply(IMatrix matrix);

        /// <summary>
        /// Defines the operation of matrix multiplication.  Let A, B, C be matrices and multiplication defined as A * B = C.
        /// Then, the current IComplexMatrix instance is represented A, the input matrix is represented by B, and the result
        /// of the product is represented by C.
        /// </summary>
        /// <param name="matrix">For matrix multiplication given by A * B = C, the input matrix is represented by B.</param>
        /// <returns>A new IComplexMatrix instance which is the product of the current IComplexMatrix instance and the input matrix.</returns>
        IComplexMatrix Multiply(IReadOnlyComplexMatrix matrix);

        /// <summary>
        /// Defines the operation of matrix multiplication.  Let A, B, C be matrices and multiplication defined as A * B = C.
        /// Then, the current IComplexMatrix instance is represented A, the input matrix is represented by B, and the result
        /// of the product is represented by C.
        /// </summary>
        /// <param name="matrix">For matrix multiplication given by A * B = C, the input matrix is represented by B.</param>
        /// <returns>A new IComplexMatrix instance which is the product of the current IComplexMatrix instance and the input matrix.</returns>
        IComplexMatrix Multiply(IReadOnlyMatrix matrix);

        /// <summary>
        /// Defines the operation of scalar matrix multiplication.
        /// </summary>
        /// <param name="matrix">The complex value by which all elements in the matrix should be multiplied.</param>
        /// <returns>A new IComplexMatrix instance which is the product of the current IComplexMatrix and the input scalar.</returns>
        IComplexMatrix MultiplyByScalar(Complex scalar);

        /// <summary>
        /// Defines the operation of scalar matrix multiplication.
        /// </summary>
        /// <param name="matrix">The real (double) value by which all elements in the matrix should be multiplied.</param>
        /// <returns>A new IComplexMatrix instance which is the product of the current IComplexMatrix and the input scalar.</returns>
        IComplexMatrix MultiplyByScalar(double scalar);
    }
}
