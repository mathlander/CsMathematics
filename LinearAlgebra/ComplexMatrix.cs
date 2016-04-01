using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CsMathematics.LinearAlgebra
{
    public class ComplexMatrixException : Exception { public ComplexMatrixException(string message) : base(message) { } }

    internal class ComplexMatrix : IComplexMatrix, IReadOnlyComplexMatrix
    {
        private readonly IDictionary<int, IComplexVector> _matrixRows = new SortedDictionary<int, IComplexVector>();

        public ComplexMatrix(IList<IComplexVector> rowVectors)
        {
            if (rowVectors.Count == 0)
                throw new ComplexMatrixException("Matrices with zero rows are not supported.");

            var numberOfColumns = rowVectors[0].Length;

            foreach (var rowIndex in Enumerable.Range(1, rowVectors.Count))
            {
                var vector = rowVectors[rowIndex-1];

                // enforce that all row vectors have the same length
                if (vector.Length == numberOfColumns)
                    _matrixRows.Add(rowIndex, vector);
                else
                    throw new ComplexMatrixException("All rows in the matrix must have the same number of columns.");
            }

            RowCount = rowVectors.Count;
            ColumnCount = numberOfColumns;
        }

        public static IComplexMatrix GenerateTranspose(IComplexMatrix matrix)
        {
            // the transpose of a matrix is simply when the column vectors or the original become the row vectors of the transpose
            var columnVectors = new List<IComplexVector>(matrix.GetColumns());

            return new ComplexMatrix(columnVectors);
        }

        public static IReadOnlyComplexMatrix GenerateTranspose(IReadOnlyComplexMatrix matrix)
        {
            // the transpose of a matrix is simply when the column vectors or the original become the row vectors of the transpose
            var columnVectors = new List<IComplexVector>(matrix.GetColumns().Select(readOnlyVector => new ComplexVector(readOnlyVector)));

            return new ComplexMatrix(columnVectors);
        }

        public static IComplexMatrix GenerateConjugate(IComplexMatrix matrix)
        {
            // copy each row vector from the original matrix, iterating over the vector's elements, applying the conjugation operator to each one
            var rowVectors = new List<IComplexVector>(
                matrix.GetRows()
                    .Select(vector => new ComplexVector(
                        vector.Select(item => new Complex(item.Real, -item.Imaginary)))));

            return new ComplexMatrix(rowVectors);
        }

        public static IReadOnlyComplexMatrix GenerateConjugate(IReadOnlyComplexMatrix matrix)
        {
            // copy each row vector from the original matrix, iterating over the vector's elements, applying the conjugation operator to each one
            var rowVectors = new List<IComplexVector>(
                matrix.GetRows()
                    .Select(vector => new ComplexVector(
                        vector.Select(item => new Complex(item.Real, -item.Imaginary)))));

            return new ComplexMatrix(rowVectors);
        }

        public static IComplexMatrix GenerateConjugateTranspose(IComplexMatrix matrix)
        {
            // copy each column vector from the original matrix, iterating over the vector's elements, applying the conjugation operator to each one
            var columnVectors = new List<IComplexVector>(
                matrix.GetColumns()
                    .Select(vector => new ComplexVector(
                        vector.Select(item => new Complex(item.Real, -item.Imaginary)))));

            return new ComplexMatrix(columnVectors);
        }

        public static IReadOnlyComplexMatrix GenerateConjugateTranspose(IReadOnlyComplexMatrix matrix)
        {
            // copy each column vector from the original matrix, iterating over the vector's elements, applying the conjugation operator to each one
            var columnVectors = new List<IComplexVector>(
                matrix.GetColumns()
                    .Select(vector => new ComplexVector(
                        vector.Select(item => new Complex(item.Real, -item.Imaginary)))));

            return new ComplexMatrix(columnVectors);
        }

        public int RowCount { get; private set; }
        public int ColumnCount { get; private set; }

        public Complex this[int row, int col]
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

        public void OverwriteRow(IComplexVector vector, int rowId)
        {
            if (vector.Length != ColumnCount)
                throw new ComplexMatrixException(String.Format("Cannot overwrite a matrix row vector of length [{0}] with values from a vector of length [{1}].", ColumnCount, vector.Length));
            else if (rowId > RowCount || rowId < 1)
                throw new ComplexMatrixException(String.Format("Index out of range.  Attempted to access row [{0}] in a matrix with [{1}] rows.  Row ID must be in the range [1,{1}].", rowId, RowCount));

            var rowVector = _matrixRows[rowId];

            foreach (var index in Enumerable.Range(1, vector.Length))
                rowVector[index] = vector[index];
        }

        public void OverwriteColumn(IComplexVector vector, int columnId)
        {
            if (vector.Length != RowCount)
                throw new ComplexMatrixException(String.Format("Cannot overwrite a matrix column vector of length [{0}] with values from a vector of length [{1}].", RowCount, vector.Length));
            else if (columnId > ColumnCount || columnId < 1)
                throw new ComplexMatrixException(String.Format("Index out of range.  Attempted to access column [{0}] in a matrix with [{1}] columns.  Column ID must be in the range [1,{1}].", columnId, ColumnCount));

            foreach (var index in Enumerable.Range(1, vector.Length))
                this[index, columnId] = vector[index];
        }

        public IComplexVector GetRow(int rowId)
        {
            return new ComplexVector(_matrixRows[rowId]);
        }

        IReadOnlyComplexVector IReadOnlyComplexMatrix.GetRow(int rowId)
        {
            return new ComplexVector(_matrixRows[rowId]);
        }

        public IComplexVector GetColumn(int columnId)
        {
            return new ComplexVector(Enumerable.Range(1, RowCount).Select(rowIndex => _matrixRows[rowIndex][columnId]));
        }

        IReadOnlyComplexVector IReadOnlyComplexMatrix.GetColumn(int columnId)
        {
            return new ComplexVector(Enumerable.Range(1, RowCount).Select(rowIndex => _matrixRows[rowIndex][columnId]));
        }

        public IEnumerable<IComplexVector> GetRows()
        {
            foreach (var rowId in Enumerable.Range(1, RowCount))
                yield return GetRow(rowId);
        }

        IEnumerable<IReadOnlyComplexVector> IReadOnlyComplexMatrix.GetRows()
        {
            foreach (var rowId in Enumerable.Range(1, RowCount))
                yield return ((IReadOnlyComplexMatrix)this).GetRow(rowId);
        }

        public IEnumerable<IComplexVector> GetColumns()
        {
            foreach (var columnId in Enumerable.Range(1, ColumnCount))
                yield return GetColumn(columnId);
        }

        IEnumerable<IReadOnlyComplexVector> IReadOnlyComplexMatrix.GetColumns()
        {
            foreach (var columnId in Enumerable.Range(1, ColumnCount))
                yield return ((IReadOnlyComplexMatrix)this).GetColumn(columnId);
        }

        public IComplexMatrix Add(IComplexMatrix matrix)
        {
            if (RowCount != matrix.RowCount || ColumnCount != matrix.ColumnCount)
                throw new ComplexMatrixException("Addition is undefined for matrices of different size.");

            var summedVectors = GetRows().Zip(matrix.GetRows(), (thisRow, thatRow) => thisRow.Add(thatRow));
            var resultMatrixRows = new List<IComplexVector>(summedVectors);

            return new ComplexMatrix(resultMatrixRows);
        }

        public IComplexMatrix Add(IMatrix matrix)
        {
            if (RowCount != matrix.RowCount || ColumnCount != matrix.ColumnCount)
                throw new ComplexMatrixException("Addition is undefined for matrices of different size.");

            var summedVectors = GetRows().Zip(matrix.GetRows(), (thisRow, thatRow) => thisRow.Add(thatRow));
            var resultMatrixRows = new List<IComplexVector>(summedVectors);

            return new ComplexMatrix(resultMatrixRows);
        }

        public IComplexMatrix Add(IReadOnlyComplexMatrix matrix)
        {
            if (RowCount != matrix.RowCount || ColumnCount != matrix.ColumnCount)
                throw new ComplexMatrixException("Addition is undefined for matrices of different size.");

            var summedVectors = GetRows().Zip(matrix.GetRows(), (thisRow, thatRow) => thisRow.Add(thatRow));
            var resultMatrixRows = new List<IComplexVector>(summedVectors);

            return new ComplexMatrix(resultMatrixRows);
        }

        public IComplexMatrix Add(IReadOnlyMatrix matrix)
        {
            if (RowCount != matrix.RowCount || ColumnCount != matrix.ColumnCount)
                throw new ComplexMatrixException("Addition is undefined for matrices of different size.");

            var summedVectors = GetRows().Zip(matrix.GetRows(), (thisRow, thatRow) => thisRow.Add(thatRow));
            var resultMatrixRows = new List<IComplexVector>(summedVectors);

            return new ComplexMatrix(resultMatrixRows);
        }

        IReadOnlyComplexMatrix IReadOnlyComplexMatrix.Add(IReadOnlyComplexMatrix matrix)
        {
            if (RowCount != matrix.RowCount || ColumnCount != matrix.ColumnCount)
                throw new ComplexMatrixException("Addition is undefined for matrices of different size.");

            var summedVectors = GetRows().Zip(matrix.GetRows(), (thisRow, thatRow) => thisRow.Add(thatRow));
            var resultMatrixRows = new List<IComplexVector>(summedVectors);

            return new ComplexMatrix(resultMatrixRows);
        }

        IReadOnlyComplexMatrix IReadOnlyComplexMatrix.Add(IReadOnlyMatrix matrix)
        {
            if (RowCount != matrix.RowCount || ColumnCount != matrix.ColumnCount)
                throw new ComplexMatrixException("Addition is undefined for matrices of different size.");

            var summedVectors = GetRows().Zip(matrix.GetRows(), (thisRow, thatRow) => thisRow.Add(thatRow));
            var resultMatrixRows = new List<IComplexVector>(summedVectors);

            return new ComplexMatrix(resultMatrixRows);
        }

        IReadOnlyComplexMatrix IReadOnlyComplexMatrix.Add(IComplexMatrix matrix)
        {
            if (RowCount != matrix.RowCount || ColumnCount != matrix.ColumnCount)
                throw new ComplexMatrixException("Addition is undefined for matrices of different size.");

            var summedVectors = GetRows().Zip(matrix.GetRows(), (thisRow, thatRow) => thisRow.Add(thatRow));
            var resultMatrixRows = new List<IComplexVector>(summedVectors);

            return new ComplexMatrix(resultMatrixRows);
        }

        IReadOnlyComplexMatrix IReadOnlyComplexMatrix.Add(IMatrix matrix)
        {
            if (RowCount != matrix.RowCount || ColumnCount != matrix.ColumnCount)
                throw new ComplexMatrixException("Addition is undefined for matrices of different size.");

            var summedVectors = GetRows().Zip(matrix.GetRows(), (thisRow, thatRow) => thisRow.Add(thatRow));
            var resultMatrixRows = new List<IComplexVector>(summedVectors);

            return new ComplexMatrix(resultMatrixRows);
        }

        public IComplexMatrix Subtract(IComplexMatrix matrix)
        {
            if (RowCount != matrix.RowCount || ColumnCount != matrix.ColumnCount)
                throw new ComplexMatrixException("Subtraction is undefined for matrices of different size.");

            var diffVectors = GetRows().Zip(matrix.GetRows(), (thisRow, thatRow) => thisRow.Subtract(thatRow));
            var resultMatrixRows = new List<IComplexVector>(diffVectors);

            return new ComplexMatrix(resultMatrixRows);
        }

        public IComplexMatrix Subtract(IMatrix matrix)
        {
            if (RowCount != matrix.RowCount || ColumnCount != matrix.ColumnCount)
                throw new ComplexMatrixException("Subtraction is undefined for matrices of different size.");

            var diffVectors = GetRows().Zip(matrix.GetRows(), (thisRow, thatRow) => thisRow.Subtract(thatRow));
            var resultMatrixRows = new List<IComplexVector>(diffVectors);

            return new ComplexMatrix(resultMatrixRows);
        }

        public IComplexMatrix Subtract(IReadOnlyComplexMatrix matrix)
        {
            if (RowCount != matrix.RowCount || ColumnCount != matrix.ColumnCount)
                throw new ComplexMatrixException("Subtraction is undefined for matrices of different size.");

            var diffVectors = GetRows().Zip(matrix.GetRows(), (thisRow, thatRow) => thisRow.Subtract(thatRow));
            var resultMatrixRows = new List<IComplexVector>(diffVectors);

            return new ComplexMatrix(resultMatrixRows);
        }

        public IComplexMatrix Subtract(IReadOnlyMatrix matrix)
        {
            if (RowCount != matrix.RowCount || ColumnCount != matrix.ColumnCount)
                throw new ComplexMatrixException("Subtraction is undefined for matrices of different size.");

            var diffVectors = GetRows().Zip(matrix.GetRows(), (thisRow, thatRow) => thisRow.Subtract(thatRow));
            var resultMatrixRows = new List<IComplexVector>(diffVectors);

            return new ComplexMatrix(resultMatrixRows);
        }

        IReadOnlyComplexMatrix IReadOnlyComplexMatrix.Subtract(IReadOnlyComplexMatrix matrix)
        {
            if (RowCount != matrix.RowCount || ColumnCount != matrix.ColumnCount)
                throw new ComplexMatrixException("Subtraction is undefined for matrices of different size.");

            var diffVectors = GetRows().Zip(matrix.GetRows(), (thisRow, thatRow) => thisRow.Subtract(thatRow));
            var resultMatrixRows = new List<IComplexVector>(diffVectors);

            return new ComplexMatrix(resultMatrixRows);
        }

        IReadOnlyComplexMatrix IReadOnlyComplexMatrix.Subtract(IReadOnlyMatrix matrix)
        {
            if (RowCount != matrix.RowCount || ColumnCount != matrix.ColumnCount)
                throw new ComplexMatrixException("Subtraction is undefined for matrices of different size.");

            var diffVectors = GetRows().Zip(matrix.GetRows(), (thisRow, thatRow) => thisRow.Subtract(thatRow));
            var resultMatrixRows = new List<IComplexVector>(diffVectors);

            return new ComplexMatrix(resultMatrixRows);
        }

        IReadOnlyComplexMatrix IReadOnlyComplexMatrix.Subtract(IComplexMatrix matrix)
        {
            if (RowCount != matrix.RowCount || ColumnCount != matrix.ColumnCount)
                throw new ComplexMatrixException("Subtraction is undefined for matrices of different size.");

            var diffVectors = GetRows().Zip(matrix.GetRows(), (thisRow, thatRow) => thisRow.Subtract(thatRow));
            var resultMatrixRows = new List<IComplexVector>(diffVectors);

            return new ComplexMatrix(resultMatrixRows);
        }

        IReadOnlyComplexMatrix IReadOnlyComplexMatrix.Subtract(IMatrix matrix)
        {
            if (RowCount != matrix.RowCount || ColumnCount != matrix.ColumnCount)
                throw new ComplexMatrixException("Subtraction is undefined for matrices of different size.");

            var diffVectors = GetRows().Zip(matrix.GetRows(), (thisRow, thatRow) => thisRow.Subtract(thatRow));
            var resultMatrixRows = new List<IComplexVector>(diffVectors);

            return new ComplexMatrix(resultMatrixRows);
        }

        public IComplexMatrix Multiply(IComplexMatrix matrix)
        {
            if (ColumnCount != matrix.RowCount)
                throw new ComplexMatrixException("Matrix multiplication is undefined if the number of columns from the left factor does not equal the number of rows from the right factor.");

            var diffVectors = GetRows().Zip(matrix.GetRows(), (thisRow, thatRow) => thisRow.Subtract(thatRow));
            var resultMatrixRows = new List<IComplexVector>(RowCount);

            foreach (var rowVector in GetRows())
            {
                // create a new complex vector by taking the dot product of the current row vector each column of the input matrix
                resultMatrixRows.Add(new ComplexVector(
                    Enumerable.Range(1, matrix.ColumnCount)
                        .Select(thatColId => rowVector.InnerProduct(matrix.GetColumn(thatColId)))));
            }

            return new ComplexMatrix(resultMatrixRows);
        }

        public IComplexMatrix Multiply(IMatrix matrix)
        {
            if (ColumnCount != matrix.RowCount)
                throw new ComplexMatrixException("Matrix multiplication is undefined if the number of columns from the left factor does not equal the number of rows from the right factor.");

            var diffVectors = GetRows().Zip(matrix.GetRows(), (thisRow, thatRow) => thisRow.Subtract(thatRow));
            var resultMatrixRows = new List<IComplexVector>(RowCount);

            foreach (var rowVector in GetRows())
            {
                // create a new complex vector by taking the dot product of the current row vector each column of the input matrix
                resultMatrixRows.Add(new ComplexVector(
                    Enumerable.Range(1, matrix.ColumnCount)
                        .Select(thatColId => rowVector.InnerProduct(matrix.GetColumn(thatColId)))));
            }

            return new ComplexMatrix(resultMatrixRows);
        }

        public IComplexMatrix Multiply(IReadOnlyComplexMatrix matrix)
        {
            if (ColumnCount != matrix.RowCount)
                throw new ComplexMatrixException("Matrix multiplication is undefined if the number of columns from the left factor does not equal the number of rows from the right factor.");

            var diffVectors = GetRows().Zip(matrix.GetRows(), (thisRow, thatRow) => thisRow.Subtract(thatRow));
            var resultMatrixRows = new List<IComplexVector>(RowCount);

            foreach (var rowVector in GetRows())
            {
                // create a new complex vector by taking the dot product of the current row vector each column of the input matrix
                resultMatrixRows.Add(new ComplexVector(
                    Enumerable.Range(1, matrix.ColumnCount)
                        .Select(thatColId => rowVector.InnerProduct(matrix.GetColumn(thatColId)))));
            }

            return new ComplexMatrix(resultMatrixRows);
        }

        public IComplexMatrix Multiply(IReadOnlyMatrix matrix)
        {
            if (ColumnCount != matrix.RowCount)
                throw new ComplexMatrixException("Matrix multiplication is undefined if the number of columns from the left factor does not equal the number of rows from the right factor.");

            var diffVectors = GetRows().Zip(matrix.GetRows(), (thisRow, thatRow) => thisRow.Subtract(thatRow));
            var resultMatrixRows = new List<IComplexVector>(RowCount);

            foreach (var rowVector in GetRows())
            {
                // create a new complex vector by taking the dot product of the current row vector each column of the input matrix
                resultMatrixRows.Add(new ComplexVector(
                    Enumerable.Range(1, matrix.ColumnCount)
                        .Select(thatColId => rowVector.InnerProduct(matrix.GetColumn(thatColId)))));
            }

            return new ComplexMatrix(resultMatrixRows);
        }

        IReadOnlyComplexMatrix IReadOnlyComplexMatrix.Multiply(IReadOnlyComplexMatrix matrix)
        {
            if (ColumnCount != matrix.RowCount)
                throw new ComplexMatrixException("Matrix multiplication is undefined if the number of columns from the left factor does not equal the number of rows from the right factor.");

            var diffVectors = GetRows().Zip(matrix.GetRows(), (thisRow, thatRow) => thisRow.Subtract(thatRow));
            var resultMatrixRows = new List<IComplexVector>(RowCount);

            foreach (var rowVector in GetRows())
            {
                // create a new complex vector by taking the dot product of the current row vector each column of the input matrix
                resultMatrixRows.Add(new ComplexVector(
                    Enumerable.Range(1, matrix.ColumnCount)
                        .Select(thatColId => rowVector.InnerProduct(matrix.GetColumn(thatColId)))));
            }

            return new ComplexMatrix(resultMatrixRows);
        }

        IReadOnlyComplexMatrix IReadOnlyComplexMatrix.Multiply(IReadOnlyMatrix matrix)
        {
            if (ColumnCount != matrix.RowCount)
                throw new ComplexMatrixException("Matrix multiplication is undefined if the number of columns from the left factor does not equal the number of rows from the right factor.");

            var diffVectors = GetRows().Zip(matrix.GetRows(), (thisRow, thatRow) => thisRow.Subtract(thatRow));
            var resultMatrixRows = new List<IComplexVector>(RowCount);

            foreach (var rowVector in GetRows())
            {
                // create a new complex vector by taking the dot product of the current row vector each column of the input matrix
                resultMatrixRows.Add(new ComplexVector(
                    Enumerable.Range(1, matrix.ColumnCount)
                        .Select(thatColId => rowVector.InnerProduct(matrix.GetColumn(thatColId)))));
            }

            return new ComplexMatrix(resultMatrixRows);
        }

        IReadOnlyComplexMatrix IReadOnlyComplexMatrix.Multiply(IComplexMatrix matrix)
        {
            if (ColumnCount != matrix.RowCount)
                throw new ComplexMatrixException("Matrix multiplication is undefined if the number of columns from the left factor does not equal the number of rows from the right factor.");

            var diffVectors = GetRows().Zip(matrix.GetRows(), (thisRow, thatRow) => thisRow.Subtract(thatRow));
            var resultMatrixRows = new List<IComplexVector>(RowCount);

            foreach (var rowVector in GetRows())
            {
                // create a new complex vector by taking the dot product of the current row vector each column of the input matrix
                resultMatrixRows.Add(new ComplexVector(
                    Enumerable.Range(1, matrix.ColumnCount)
                        .Select(thatColId => rowVector.InnerProduct(matrix.GetColumn(thatColId)))));
            }

            return new ComplexMatrix(resultMatrixRows);
        }

        IReadOnlyComplexMatrix IReadOnlyComplexMatrix.Multiply(IMatrix matrix)
        {
            if (ColumnCount != matrix.RowCount)
                throw new ComplexMatrixException("Matrix multiplication is undefined if the number of columns from the left factor does not equal the number of rows from the right factor.");

            var diffVectors = GetRows().Zip(matrix.GetRows(), (thisRow, thatRow) => thisRow.Subtract(thatRow));
            var resultMatrixRows = new List<IComplexVector>(RowCount);

            foreach (var rowVector in GetRows())
            {
                // create a new complex vector by taking the dot product of the current row vector each column of the input matrix
                resultMatrixRows.Add(new ComplexVector(
                    Enumerable.Range(1, matrix.ColumnCount)
                        .Select(thatColId => rowVector.InnerProduct(matrix.GetColumn(thatColId)))));
            }

            return new ComplexMatrix(resultMatrixRows);
        }

        public IComplexMatrix MultiplyByScalar(System.Numerics.Complex scalar)
        {
            var scaledMatrixRows = new List<IComplexVector>(GetRows().Select(rowVector => rowVector.MultiplyByScalar(scalar)));

            return new ComplexMatrix(scaledMatrixRows);
        }

        public IComplexMatrix MultiplyByScalar(double scalar)
        {
            var scaledMatrixRows = new List<IComplexVector>(GetRows().Select(rowVector => rowVector.MultiplyByScalar(scalar)));

            return new ComplexMatrix(scaledMatrixRows);
        }

        IReadOnlyComplexMatrix IReadOnlyComplexMatrix.MultiplyByScalar(Complex scalar)
        {
            var scaledMatrixRows = new List<IComplexVector>(GetRows().Select(rowVector => rowVector.MultiplyByScalar(scalar)));

            return new ComplexMatrix(scaledMatrixRows);
        }

        IReadOnlyComplexMatrix IReadOnlyComplexMatrix.MultiplyByScalar(double scalar)
        {
            var scaledMatrixRows = new List<IComplexVector>(GetRows().Select(rowVector => rowVector.MultiplyByScalar(scalar)));

            return new ComplexMatrix(scaledMatrixRows);
        }

        public bool Equals(IComplexMatrix other)
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

        public bool Equals(IReadOnlyComplexMatrix other)
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
