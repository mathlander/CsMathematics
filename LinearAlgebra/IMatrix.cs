using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsMathematics.LinearAlgebra
{
    /// <summary>
    /// Represents a matrix of real (double) values.
    /// </summary>
    public interface IMatrix : IEquatable<IMatrix>, IEquatable<IReadOnlyMatrix>
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
        /// Gets or sets a value at the specified matrix row and index.
        /// </summary>
        /// <param name="row">The row for the element to be returned or updated.</param>
        /// <param name="col">The column for the element to be returned or updated.</param>
        /// <returns>The value at the specified row and column.</returns>
        double this[int row, int col] { get; set; }


        /// <summary>
        /// Replaces the specified row of the current IMatrix instance with
        /// the values of the input IVector instance.
        /// </summary>
        /// <param name="vector">A vector of new values for the IMatrix at the specified row.</param>
        /// <param name="rowId">The row number which should be replaced.  Values may range from 1 to RowCount.</param>
        void OverwriteRow(IVector vector, int rowId);

        /// <summary>
        /// Replaces the specified row of the current IMatrix instance with
        /// the values of the input IVector instance.
        /// </summary>
        /// <param name="vector">A vector of new values for the IMatrix at the specified column.</param>
        /// <param name="columnId">The column number which should be replaced.  Values may range from 1 to ColumnCount.</param>
        void OverwriteColumn(IVector vector, int columnId);

        /// <summary>
        /// Returns a copy of the row vector at the specified rowId.
        /// </summary>
        /// <param name="rowId">The row number whose values should be returned.</param>
        /// <returns>A copy of the row vector at the specified rowId.</returns>
        IVector GetRow(int rowId);

        /// <summary>
        /// Returns a copy of the column vector at the specified columnId.
        /// </summary>
        /// <param name="columnId">The column number whose values should be returned.</param>
        /// <returns>A copy of the column vector at the specified columnId.</returns>
        IVector GetColumn(int columnId);

        /// <summary>
        /// Returns a collection of IVector instances which are copies of the row vectors
        /// which make up the current IMatrix instance.
        /// </summary>
        /// <returns>A collection of IVector instances copied from the row vectors of
        /// the current IMatrix instance.</returns>
        IEnumerable<IVector> GetRows();

        /// <summary>
        /// Returns a collection of IVector instances which are copies of the column vectors
        /// which make up the current IMatrix instance.
        /// </summary>
        /// <returns>A collection of IVector instances copied from the column vectors of
        /// the current IMatrix instance.</returns>
        IEnumerable<IVector> GetColumns();

        /// <summary>
        /// Defines the operation of matrix addition.  The elements of the input matrix are
        /// added to the elements of the current IMatrix instance.
        /// </summary>
        /// <param name="matrix">The matrix whose elements should be added to the current instance.</param>
        /// <returns>A new instance of IMatrix composed of the elements from the binary
        /// operation of addition of two matrices.</returns>
        IMatrix Add(IMatrix matrix);

        /// <summary>
        /// Defines the operation of matrix addition.  The elements of the input matrix are
        /// added to the elements of the current IMatrix instance.
        /// </summary>
        /// <param name="matrix">The matrix whose elements should be added to the current instance.</param>
        /// <returns>A new instance of IMatrix composed of the elements from the binary
        /// operation of addition of two matrices.</returns>
        IMatrix Add(IReadOnlyMatrix matrix);

        /// <summary>
        /// Defines the operation of matrix subtraction.  The elements of the input matrix are
        /// subtracted from the elements of the current IMatrix instance.
        /// </summary>
        /// <param name="matrix">The matrix whose elements should be subtracted from the current instance.</param>
        /// <returns>A new instance of IMatrix composed of the elements from the binary
        /// operation of subtraction of the input matrix from the current instance.</returns>
        IMatrix Subtract(IMatrix matrix);

        /// <summary>
        /// Defines the operation of matrix subtraction.  The elements of the input matrix are
        /// subtracted from the elements of the current IMatrix instance.
        /// </summary>
        /// <param name="matrix">The matrix whose elements should be subtracted from the current instance.</param>
        /// <returns>A new instance of IMatrix composed of the elements from the binary
        /// operation of subtraction of the input matrix from the current instance.</returns>
        IMatrix Subtract(IReadOnlyMatrix matrix);

        /// <summary>
        /// Defines the operation of matrix multiplication.  Let A, B, C be matrices and multiplication defined as A * B = C.
        /// Then, the current IMatrix instance is represented A, the input matrix is represented by B, and the result
        /// of the product is represented by C.
        /// </summary>
        /// <param name="matrix">For matrix multiplication given by A * B = C, the input matrix is represented by B.</param>
        /// <returns>A new IMatrix instance which is the product of the current IMatrix instance and the input matrix.</returns>
        IMatrix Multiply(IMatrix matrix);

        /// <summary>
        /// Defines the operation of matrix multiplication.  Let A, B, C be matrices and multiplication defined as A * B = C.
        /// Then, the current IMatrix instance is represented A, the input matrix is represented by B, and the result
        /// of the product is represented by C.
        /// </summary>
        /// <param name="matrix">For matrix multiplication given by A * B = C, the input matrix is represented by B.</param>
        /// <returns>A new IMatrix instance which is the product of the current IMatrix instance and the input matrix.</returns>
        IMatrix Multiply(IReadOnlyMatrix matrix);

        /// <summary>
        /// Defines the operation of scalar matrix multiplication.
        /// </summary>
        /// <param name="matrix">The value by which all elements in the matrix should be multiplied.</param>
        /// <returns>A new IMatrix instance which is the product of the current IMatrix and the input scalar.</returns>
        IMatrix MultiplyByScalar(double scalar);
    }
}
