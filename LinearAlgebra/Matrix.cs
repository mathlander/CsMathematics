using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsMathematics.LinearAlgebra
{
    public class MatrixException : Exception { public MatrixException(string message) : base(message) { } }

    internal class Matrix : IMatrix, IReadOnlyMatrix
    {
        private readonly IDictionary<int, IVector> _matrixRows = new SortedDictionary<int, IVector>();

        public Matrix(IList<IVector> rowVectors)
        {
            if (rowVectors.Count == 0)
                throw new MatrixException("Matrices with zero rows are not supported.");

            var numberOfColumns = rowVectors[0].Length;

            foreach (var rowIndex in Enumerable.Range(1, rowVectors.Count))
            {
                var vector = rowVectors[rowIndex-1];

                // enforce that all row vectors have the same length
                if (vector.Length == numberOfColumns)
                    _matrixRows.Add(rowIndex, vector);
                else
                    throw new MatrixException("All rows in the matrix must have the same number of columns.");
            }

            RowCount = rowVectors.Count;
            ColumnCount = numberOfColumns;
        }

        public static IMatrix GenerateTranspose(IMatrix matrix)
        {
            // the transpose of a matrix is simply when the column vectors or the original become the row vectors of the transpose
            var columnVectors = new List<IVector>(matrix.GetColumns());

            return new Matrix(columnVectors);
        }

        public static IReadOnlyMatrix GenerateTranspose(IReadOnlyMatrix matrix)
        {
            // the transpose of a matrix is simply when the column vectors or the original become the row vectors of the transpose
            var columnVectors = new List<IVector>(matrix.GetColumns().Select(readOnlyVector => new Vector(readOnlyVector)));

            return new Matrix(columnVectors);
        }

        public int RowCount { get; private set; }
        public int ColumnCount { get; private set; }

        public double this[int row, int col]
        {
            get
            {
                return _matrixRows[row][col];
            }
            set
            {
                _matrixRows[row][col] = value;
            }
        }

        public void OverwriteRow(IVector vector, int rowId)
        {
            if (vector.Length != ColumnCount)
                throw new MatrixException(String.Format("Cannot overwrite a matrix row vector of length [{0}] with values from a vector of length [{1}].", ColumnCount, vector.Length));
            else if (rowId > RowCount || rowId < 1)
                throw new MatrixException(String.Format("Index out of range.  Attempted to access row [{0}] in a matrix with [{1}] rows.  Row ID must be in the range [1,{1}].", rowId, RowCount));

            var rowVector = _matrixRows[rowId];

            foreach (var index in Enumerable.Range(1, vector.Length))
                rowVector[index] = vector[index];
        }

        public void OverwriteColumn(IVector vector, int columnId)
        {
            if (vector.Length != RowCount)
                throw new ComplexMatrixException(String.Format("Cannot overwrite a matrix column vector of length [{0}] with values from a vector of length [{1}].", RowCount, vector.Length));
            else if (columnId > ColumnCount || columnId < 1)
                throw new ComplexMatrixException(String.Format("Index out of range.  Attempted to access column [{0}] in a matrix with [{1}] columns.  Column ID must be in the range [1,{1}].", columnId, ColumnCount));

            foreach (var index in Enumerable.Range(1, vector.Length))
                this[index, columnId] = vector[index];
        }

        public IVector GetRow(int rowId)
        {
            return new Vector(_matrixRows[rowId]);
        }

        IReadOnlyVector IReadOnlyMatrix.GetRow(int rowId)
        {
            return new Vector(_matrixRows[rowId]);
        }

        public IVector GetColumn(int columnId)
        {
            return new Vector(Enumerable.Range(1, RowCount).Select(rowIndex => _matrixRows[rowIndex][columnId]));
        }

        IReadOnlyVector IReadOnlyMatrix.GetColumn(int columnId)
        {
            return new Vector(Enumerable.Range(1, RowCount).Select(rowIndex => _matrixRows[rowIndex][columnId]));
        }

        public IEnumerable<IVector> GetRows()
        {
            foreach (var rowId in Enumerable.Range(1, RowCount))
                yield return GetRow(rowId);
        }

        IEnumerable<IReadOnlyVector> IReadOnlyMatrix.GetRows()
        {
            foreach (var rowId in Enumerable.Range(1, RowCount))
                yield return ((IReadOnlyMatrix)this).GetRow(rowId);
        }

        public IEnumerable<IVector> GetColumns()
        {
            foreach (var columnId in Enumerable.Range(1, ColumnCount))
                yield return GetColumn(columnId);
        }

        IEnumerable<IReadOnlyVector> IReadOnlyMatrix.GetColumns()
        {
            foreach (var columnId in Enumerable.Range(1, ColumnCount))
                yield return ((IReadOnlyMatrix)this).GetColumn(columnId);
        }

        public IMatrix Add(IMatrix matrix)
        {
            if (RowCount != matrix.RowCount || ColumnCount != matrix.ColumnCount)
                throw new MatrixException("Addition is undefined for matrices of different size.");

            var summedVectors = GetRows().Zip(matrix.GetRows(), (thisRow, thatRow) => thisRow.Add(thatRow));
            var resultMatrixRows = new List<IVector>(summedVectors);

            return new Matrix(resultMatrixRows);
        }

        public IMatrix Add(IReadOnlyMatrix matrix)
        {
            if (RowCount != matrix.RowCount || ColumnCount != matrix.ColumnCount)
                throw new MatrixException("Addition is undefined for matrices of different size.");

            var summedVectors = GetRows().Zip(matrix.GetRows(), (thisRow, thatRow) => thisRow.Add(thatRow));
            var resultMatrixRows = new List<IVector>(summedVectors);

            return new Matrix(resultMatrixRows);
        }

        IReadOnlyMatrix IReadOnlyMatrix.Add(IMatrix matrix)
        {
            if (RowCount != matrix.RowCount || ColumnCount != matrix.ColumnCount)
                throw new MatrixException("Addition is undefined for matrices of different size.");

            var summedVectors = GetRows().Zip(matrix.GetRows(), (thisRow, thatRow) => thisRow.Add(thatRow));
            var resultMatrixRows = new List<IVector>(summedVectors);

            return new Matrix(resultMatrixRows);
        }

        IReadOnlyMatrix IReadOnlyMatrix.Add(IReadOnlyMatrix matrix)
        {
            if (RowCount != matrix.RowCount || ColumnCount != matrix.ColumnCount)
                throw new MatrixException("Addition is undefined for matrices of different size.");

            var summedVectors = GetRows().Zip(matrix.GetRows(), (thisRow, thatRow) => thisRow.Add(thatRow));
            var resultMatrixRows = new List<IVector>(summedVectors);

            return new Matrix(resultMatrixRows);
        }

        public IMatrix Subtract(IMatrix matrix)
        {
            if (RowCount != matrix.RowCount || ColumnCount != matrix.ColumnCount)
                throw new MatrixException("Subtraction is undefined for matrices of different size.");

            var diffVectors = GetRows().Zip(matrix.GetRows(), (thisRow, thatRow) => thisRow.Subtract(thatRow));
            var resultMatrixRows = new List<IVector>(diffVectors);

            return new Matrix(resultMatrixRows);
        }

        public IMatrix Subtract(IReadOnlyMatrix matrix)
        {
            if (RowCount != matrix.RowCount || ColumnCount != matrix.ColumnCount)
                throw new MatrixException("Subtraction is undefined for matrices of different size.");

            var diffVectors = GetRows().Zip(matrix.GetRows(), (thisRow, thatRow) => thisRow.Subtract(thatRow));
            var resultMatrixRows = new List<IVector>(diffVectors);

            return new Matrix(resultMatrixRows);
        }

        IReadOnlyMatrix IReadOnlyMatrix.Subtract(IMatrix matrix)
        {
            if (RowCount != matrix.RowCount || ColumnCount != matrix.ColumnCount)
                throw new MatrixException("Subtraction is undefined for matrices of different size.");

            var diffVectors = GetRows().Zip(matrix.GetRows(), (thisRow, thatRow) => thisRow.Subtract(thatRow));
            var resultMatrixRows = new List<IVector>(diffVectors);

            return new Matrix(resultMatrixRows);
        }

        IReadOnlyMatrix IReadOnlyMatrix.Subtract(IReadOnlyMatrix matrix)
        {
            if (RowCount != matrix.RowCount || ColumnCount != matrix.ColumnCount)
                throw new MatrixException("Subtraction is undefined for matrices of different size.");

            var diffVectors = GetRows().Zip(matrix.GetRows(), (thisRow, thatRow) => thisRow.Subtract(thatRow));
            var resultMatrixRows = new List<IVector>(diffVectors);

            return new Matrix(resultMatrixRows);
        }

        public IMatrix Multiply(IMatrix matrix)
        {
            if (ColumnCount != matrix.RowCount)
                throw new MatrixException("Matrix multiplication is undefined if the number of columns from the left factor does not equal the number of rows from the right factor.");

            var diffVectors = GetRows().Zip(matrix.GetRows(), (thisRow, thatRow) => thisRow.Subtract(thatRow));
            var resultMatrixRows = new List<IVector>(RowCount);

            foreach (var rowVector in GetRows())
            {
                // create a new complex vector by taking the dot product of the current row vector each column of the input matrix
                resultMatrixRows.Add(new Vector(
                    Enumerable.Range(1, matrix.ColumnCount)
                        .Select(thatColId => rowVector.InnerProduct(matrix.GetColumn(thatColId)))));
            }

            return new Matrix(resultMatrixRows);
        }

        public IMatrix Multiply(IReadOnlyMatrix matrix)
        {
            if (ColumnCount != matrix.RowCount)
                throw new MatrixException("Matrix multiplication is undefined if the number of columns from the left factor does not equal the number of rows from the right factor.");

            var diffVectors = GetRows().Zip(matrix.GetRows(), (thisRow, thatRow) => thisRow.Subtract(thatRow));
            var resultMatrixRows = new List<IVector>(RowCount);

            foreach (var rowVector in GetRows())
            {
                // create a new complex vector by taking the dot product of the current row vector each column of the input matrix
                resultMatrixRows.Add(new Vector(
                    Enumerable.Range(1, matrix.ColumnCount)
                        .Select(thatColId => rowVector.InnerProduct(matrix.GetColumn(thatColId)))));
            }

            return new Matrix(resultMatrixRows);
        }

        IReadOnlyMatrix IReadOnlyMatrix.Multiply(IMatrix matrix)
        {
            if (ColumnCount != matrix.RowCount)
                throw new MatrixException("Matrix multiplication is undefined if the number of columns from the left factor does not equal the number of rows from the right factor.");

            var diffVectors = GetRows().Zip(matrix.GetRows(), (thisRow, thatRow) => thisRow.Subtract(thatRow));
            var resultMatrixRows = new List<IVector>(RowCount);

            foreach (var rowVector in GetRows())
            {
                // create a new complex vector by taking the dot product of the current row vector each column of the input matrix
                resultMatrixRows.Add(new Vector(
                    Enumerable.Range(1, matrix.ColumnCount)
                        .Select(thatColId => rowVector.InnerProduct(matrix.GetColumn(thatColId)))));
            }

            return new Matrix(resultMatrixRows);
        }

        IReadOnlyMatrix IReadOnlyMatrix.Multiply(IReadOnlyMatrix matrix)
        {
            if (ColumnCount != matrix.RowCount)
                throw new MatrixException("Matrix multiplication is undefined if the number of columns from the left factor does not equal the number of rows from the right factor.");

            var diffVectors = GetRows().Zip(matrix.GetRows(), (thisRow, thatRow) => thisRow.Subtract(thatRow));
            var resultMatrixRows = new List<IVector>(RowCount);

            foreach (var rowVector in GetRows())
            {
                // create a new complex vector by taking the dot product of the current row vector each column of the input matrix
                resultMatrixRows.Add(new Vector(
                    Enumerable.Range(1, matrix.ColumnCount)
                        .Select(thatColId => rowVector.InnerProduct(matrix.GetColumn(thatColId)))));
            }

            return new Matrix(resultMatrixRows);
        }

        public IMatrix MultiplyByScalar(double scalar)
        {
            var scaledMatrixRows = new List<IVector>(GetRows().Select(rowVector => rowVector.MultiplyByScalar(scalar)));

            return new Matrix(scaledMatrixRows);
        }

        IReadOnlyMatrix IReadOnlyMatrix.MultiplyByScalar(double scalar)
        {
            var scaledMatrixRows = new List<IVector>(GetRows().Select(rowVector => rowVector.MultiplyByScalar(scalar)));

            return new Matrix(scaledMatrixRows);
        }

        public bool Equals(IMatrix other)
        {
            // matrices must have consistent dimensions in order to be equal
            if (RowCount != other.RowCount || ColumnCount != other.ColumnCount)
                return false;

            // test the row vectors, one by one, for equality
            var zippedSequence = _matrixRows.Values.Zip(other.GetRows(), (thisVector, thatVector) => thisVector.Equals(thatVector));

            foreach (var equalityTest in zippedSequence)
            {
                if (!equalityTest)
                    return false;
            }

            // if all rows are equal, return true
            return true;
        }

        public bool Equals(IReadOnlyMatrix other)
        {
            // matrices must have consistent dimensions in order to be equal
            if (RowCount != other.RowCount || ColumnCount != other.ColumnCount)
                return false;

            // test the row vectors, one by one, for equality
            var zippedSequence = _matrixRows.Values.Zip(other.GetRows(), (thisVector, thatVector) => thisVector.Equals(thatVector));

            foreach (var equalityTest in zippedSequence)
            {
                if (!equalityTest)
                    return false;
            }

            // if all rows are equal, return true
            return true;
        }

        public override string ToString()
        {
            return String.Join(Environment.NewLine, _matrixRows.Values);
        }
    }
}
