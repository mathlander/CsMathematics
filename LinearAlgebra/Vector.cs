using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsMathematics.LinearAlgebra
{
    public class VectorException : Exception { public VectorException(string message) : base(message) { } }

    public class Vector : IVector, IReadOnlyVector
    {
        private readonly IDictionary<int, double> _elements = new SortedDictionary<int, double>();

        public Vector(IEnumerable<double> elements)
        {
            var index = 0;

            foreach (var element in elements)
            {
                index++;
                _elements.Add(index, element);
            }

            if (index == 0)
                throw new VectorException("Cannot create a vector with zero elements.");

            Length = index;
        }

        public int Length { get; private set; }

        public double this[int index]
        {
            get
            {
                return _elements[index];
            }
            set
            {
                _elements[index] = value;
            }
        }

        public IVector Add(IVector vector)
        {
            if (Length != vector.Length)
                throw new VectorException("Vector addition for vectors of different lengths is undefined.");

            return new Vector(this.Zip(vector, (leftSummand, rightSummand) => leftSummand + rightSummand));
        }

        public IVector Add(IReadOnlyVector vector)
        {
            if (Length != vector.Length)
                throw new VectorException("Vector addition for vectors of different lengths is undefined.");

            return new Vector(this.Zip(vector, (leftSummand, rightSummand) => leftSummand + rightSummand));
        }

        IReadOnlyVector IReadOnlyVector.Add(IVector vector)
        {
            if (Length != vector.Length)
                throw new VectorException("Vector addition for vectors of different lengths is undefined.");

            return new Vector(this.Zip(vector, (leftSummand, rightSummand) => leftSummand + rightSummand));
        }

        IReadOnlyVector IReadOnlyVector.Add(IReadOnlyVector vector)
        {
            if (Length != vector.Length)
                throw new VectorException("Vector addition for vectors of different lengths is undefined.");

            return new Vector(this.Zip(vector, (leftSummand, rightSummand) => leftSummand + rightSummand));
        }

        public IVector Subtract(IVector vector)
        {
            if (Length != vector.Length)
                throw new VectorException("Vector subtraction for vectors of different lengths is undefined.");

            return new Vector(this.Zip(vector, (leftItem, rightItem) => leftItem - rightItem));
        }

        public IVector Subtract(IReadOnlyVector vector)
        {
            if (Length != vector.Length)
                throw new VectorException("Vector subtraction for vectors of different lengths is undefined.");

            return new Vector(this.Zip(vector, (leftItem, rightItem) => leftItem - rightItem));
        }

        IReadOnlyVector IReadOnlyVector.Subtract(IVector vector)
        {
            if (Length != vector.Length)
                throw new VectorException("Vector subtraction for vectors of different lengths is undefined.");

            return new Vector(this.Zip(vector, (leftItem, rightItem) => leftItem - rightItem));
        }

        IReadOnlyVector IReadOnlyVector.Subtract(IReadOnlyVector vector)
        {
            if (Length != vector.Length)
                throw new VectorException("Vector subtraction for vectors of different lengths is undefined.");

            return new Vector(this.Zip(vector, (leftItem, rightItem) => leftItem - rightItem));
        }

        public double InnerProduct(IVector vector)
        {
            if (Length != vector.Length)
                throw new VectorException("Inner product is undefined for vectors of different length.");

            var sum = 0.0;

            foreach (var product in this.Zip(vector, (leftFactor, rightFactor) => leftFactor * rightFactor))
                sum += product;

            return sum;
        }

        public double InnerProduct(IReadOnlyVector vector)
        {
            if (Length != vector.Length)
                throw new VectorException("Inner product is undefined for vectors of different length.");

            var sum = 0.0;

            foreach (var product in this.Zip(vector, (leftFactor, rightFactor) => leftFactor * rightFactor))
                sum += product;

            return sum;
        }

        public IMatrix OuterProduct(IVector vector)
        {
            var rowVectors = new List<IVector>(Length);

            // the outer product has the effect of scaling the copies of the input vector by each of the
            // elements in the current vector instance
            foreach (var element in this)
                rowVectors.Add(new Vector(vector.MultiplyByScalar(element)));

            return new Matrix(rowVectors);
        }

        public IMatrix OuterProduct(IReadOnlyVector vector)
        {
            var rowVectors = new List<IVector>(Length);

            // the outer product has the effect of scaling the copies of the input vector by each of the
            // elements in the current vector instance
            foreach (var element in this)
                rowVectors.Add(new Vector(vector.MultiplyByScalar(element)));

            return new Matrix(rowVectors);
        }

        IReadOnlyMatrix IReadOnlyVector.OuterProduct(IVector vector)
        {
            var rowVectors = new List<IVector>(Length);

            // the outer product has the effect of scaling the copies of the input vector by each of the
            // elements in the current vector instance
            foreach (var element in this)
                rowVectors.Add(new Vector(vector.MultiplyByScalar(element)));

            return new Matrix(rowVectors);
        }

        IReadOnlyMatrix IReadOnlyVector.OuterProduct(IReadOnlyVector vector)
        {
            var rowVectors = new List<IVector>(Length);

            // the outer product has the effect of scaling the copies of the input vector by each of the
            // elements in the current vector instance
            foreach (var element in this)
                rowVectors.Add(new Vector(vector.MultiplyByScalar(element)));

            return new Matrix(rowVectors);
        }

        public IVector MultiplyByScalar(double scalar)
        {
            return new Vector(this.Select(element => scalar * element));
        }

        IReadOnlyVector IReadOnlyVector.MultiplyByScalar(double scalar)
        {
            return new Vector(this.Select(element => scalar * element));
        }

        public double DotProduct(IVector vector)
        {
            return this.Zip(vector, (thisElement, thatElement) => thisElement * thatElement).Sum();
        }

        public double EuclideanNorm()
        {
            return Math.Sqrt( this.DotProduct(this) );
        }

        public IVector ToUnitVector()
        {
            return this.MultiplyByScalar(1 / this.EuclideanNorm());
        }

        public IVector ProjectOntoCoordinate(int ordinal)
        {
            // verify that the ordinal is valid
            if (ordinal < 1 || ordinal > Length)
                throw new VectorException("Projection ordinal must be between 1 and Vector.Length.");

            return new Vector(Enumerable.Range(1, Length).Select(index => index==ordinal ? this[ordinal] : 0.0));
        }

        public IVector ProjectOntoVector(IVector vector)
        {
            return vector.MultiplyByScalar(this.DotProduct(vector) / vector.DotProduct(vector));
        }

        public IVector Clone()
        {
            return new Vector(Enumerable.Range(1, Length).Select(i => this[i]));
        }

        public bool Equals(IVector other)
        {
            if (Length != other.Length)
                return false;

            var equalityTests = this.Zip(other, (thisElement, thatElement) => thisElement == thatElement);

            foreach (var test in equalityTests)
            {
                if (!test)
                    return false;
            }

            return true;
        }

        public bool Equals(IReadOnlyVector other)
        {
            if (Length != other.Length)
                return false;

            var equalityTests = this.Zip(other, (thisElement, thatElement) => thisElement == thatElement);

            foreach (var test in equalityTests)
            {
                if (!test)
                    return false;
            }

            return true;
        }

        public IEnumerator<double> GetEnumerator()
        {
            return _elements.Values.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _elements.Values.GetEnumerator();
        }

        public override string ToString()
        {
            return String.Join("\t", _elements.Values);
        }
    }
}
