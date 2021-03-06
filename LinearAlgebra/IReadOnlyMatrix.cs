﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsMathematics.LinearAlgebra
{
    /// <summary>
    /// Represents a read-only matrix of real (double) values.
    /// </summary>
    public interface IReadOnlyMatrix : IEquatable<IMatrix>, IEquatable<IReadOnlyMatrix>
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
        /// Gets the value at the specified matrix row and index.
        /// </summary>
        /// <param name="row">The row for the element to be returned or updated.</param>
        /// <param name="col">The column for the element to be returned or updated.</param>
        /// <returns>The value at the specified row and column.</returns>
        double this[int row, int col] { get; }


        /// <summary>
        /// Returns a copy of the row vector at the specified rowId.
        /// </summary>
        /// <param name="rowId">The row number whose values should be returned.</param>
        /// <returns>A copy of the row vector at the specified rowId.</returns>
        IReadOnlyVector GetRow(int rowId);

        /// <summary>
        /// Returns a copy of the column vector at the specified columnId.
        /// </summary>
        /// <param name="columnId">The column number whose values should be returned.</param>
        /// <returns>A copy of the column vector at the specified columnId.</returns>
        IReadOnlyVector GetColumn(int columnId);

        /// <summary>
        /// Returns a collection of IReadOnlyVector instances which are copies of the row vectors
        /// which make up the current IReadOnlyMatrix instance.
        /// </summary>
        /// <returns>A collection of IReadOnlyVector instances copied from the row vectors of
        /// the current IReadOnlyMatrix instance.</returns>
        IEnumerable<IReadOnlyVector> GetRows();

        /// <summary>
        /// Returns a collection of IReadOnlyVector instances which are copies of the column vectors
        /// which make up the current IReadOnlyMatrix instance.
        /// </summary>
        /// <returns>A collection of IReadOnlyVector instances copied from the column vectors of
        /// the current IReadOnlyMatrix instance.</returns>
        IEnumerable<IReadOnlyVector> GetColumns();

        /// <summary>
        /// Defines the operation of matrix addition.  The elements of the input matrix are
        /// added to the elements of the current IReadOnlyMatrix instance.
        /// </summary>
        /// <param name="matrix">The matrix whose elements should be added to the current instance.</param>
        /// <returns>A new instance of IReadOnlyMatrix composed of the elements from the binary
        /// operation of addition of two matrices.</returns>
        IReadOnlyMatrix Add(IMatrix matrix);

        /// <summary>
        /// Defines the operation of matrix addition.  The elements of the input matrix are
        /// added to the elements of the current IReadOnlyMatrix instance.
        /// </summary>
        /// <param name="matrix">The matrix whose elements should be added to the current instance.</param>
        /// <returns>A new instance of IReadOnlyMatrix composed of the elements from the binary
        /// operation of addition of two matrices.</returns>
        IReadOnlyMatrix Add(IReadOnlyMatrix matrix);

        /// <summary>
        /// Defines the operation of matrix subtraction.  The elements of the input matrix are
        /// subtracted from the elements of the current IReadOnlyMatrix instance.
        /// </summary>
        /// <param name="matrix">The matrix whose elements should be subtracted from the current instance.</param>
        /// <returns>A new instance of IReadOnlyMatrix composed of the elements from the binary
        /// operation of subtraction of the input matrix from the current instance.</returns>
        IReadOnlyMatrix Subtract(IMatrix matrix);

        /// <summary>
        /// Defines the operation of matrix subtraction.  The elements of the input matrix are
        /// subtracted from the elements of the current IReadOnlyMatrix instance.
        /// </summary>
        /// <param name="matrix">The matrix whose elements should be subtracted from the current instance.</param>
        /// <returns>A new instance of IReadOnlyMatrix composed of the elements from the binary
        /// operation of subtraction of the input matrix from the current instance.</returns>
        IReadOnlyMatrix Subtract(IReadOnlyMatrix matrix);

        /// <summary>
        /// Defines the operation of matrix multiplication.  Let A, B, C be matrices and multiplication defined as A * B = C.
        /// Then, the current IReadOnlyMatrix instance is represented A, the input matrix is represented by B, and the result
        /// of the product is represented by C.
        /// </summary>
        /// <param name="matrix">For matrix multiplication given by A * B = C, the input matrix is represented by B.</param>
        /// <returns>A new IReadOnlyMatrix instance which is the product of the current IReadOnlyMatrix instance and the input matrix.</returns>
        IReadOnlyMatrix Multiply(IMatrix matrix);

        /// <summary>
        /// Defines the operation of matrix multiplication.  Let A, B, C be matrices and multiplication defined as A * B = C.
        /// Then, the current IReadOnlyMatrix instance is represented A, the input matrix is represented by B, and the result
        /// of the product is represented by C.
        /// </summary>
        /// <param name="matrix">For matrix multiplication given by A * B = C, the input matrix is represented by B.</param>
        /// <returns>A new IReadOnlyMatrix instance which is the product of the current IReadOnlyMatrix instance and the input matrix.</returns>
        IReadOnlyMatrix Multiply(IReadOnlyMatrix matrix);

        /// <summary>
        /// Defines the operation of scalar matrix multiplication.
        /// </summary>
        /// <param name="matrix">The value by which all elements in the matrix should be multiplied.</param>
        /// <returns>A new IReadOnlyMatrix instance which is the product of the current IReadOnlyMatrix and the input scalar.</returns>
        IReadOnlyMatrix MultiplyByScalar(double scalar);
    }
}
