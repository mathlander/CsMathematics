using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CsMathematics.LinearAlgebra
{
    public class ComplexVectorException : Exception { public ComplexVectorException(string message) : base(message) { } }

    internal class ComplexVector : IComplexVector, IReadOnlyComplexVector
    {
        private readonly IDictionary<int, Complex> _elements = new SortedDictionary<int, Complex>();

        public ComplexVector(IEnumerable<Complex> elements)
        {
            var index = 0;

            foreach (var element in elements)
            {
                index++;
                _elements.Add(index, element);
            }

            if (index == 0)
                throw new ComplexVectorException("Cannot create a vector with zero elements.");

            Length = index;
        }

        public int Length { get; private set; }

        public Complex this[int index]
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

        public IComplexVector Add(IComplexVector vector)
        {
            if (Length != vector.Length)
                throw new ComplexVectorException("Vector addition for vectors of different lengths is undefined.");

            return new ComplexVector(this.Zip(vector, (leftSummand, rightSummand) => leftSummand + rightSummand));
        }

        public IComplexVector Add(IReadOnlyComplexVector vector)
        {
            if (Length != vector.Length)
                throw new ComplexVectorException("Vector addition for vectors of different lengths is undefined.");

            return new ComplexVector(this.Zip(vector, (leftSummand, rightSummand) => leftSummand + rightSummand));
        }

        public IComplexVector Add(IVector vector)
        {
            if (Length != vector.Length)
                throw new ComplexVectorException("Vector addition for vectors of different lengths is undefined.");

            return new ComplexVector(this.Zip(vector, (leftSummand, rightSummand) => leftSummand + rightSummand));
        }

        public IComplexVector Add(IReadOnlyVector vector)
        {
            if (Length != vector.Length)
                throw new ComplexVectorException("Vector addition for vectors of different lengths is undefined.");

            return new ComplexVector(this.Zip(vector, (leftSummand, rightSummand) => leftSummand + rightSummand));
        }

        IReadOnlyComplexVector IReadOnlyComplexVector.Add(IComplexVector vector)
        {
            if (Length != vector.Length)
                throw new ComplexVectorException("Vector addition for vectors of different lengths is undefined.");

            return new ComplexVector(this.Zip(vector, (leftSummand, rightSummand) => leftSummand + rightSummand));
        }

        IReadOnlyComplexVector IReadOnlyComplexVector.Add(IReadOnlyComplexVector vector)
        {
            if (Length != vector.Length)
                throw new ComplexVectorException("Vector addition for vectors of different lengths is undefined.");

            return new ComplexVector(this.Zip(vector, (leftSummand, rightSummand) => leftSummand + rightSummand));
        }

        IReadOnlyComplexVector IReadOnlyComplexVector.Add(IVector vector)
        {
            if (Length != vector.Length)
                throw new ComplexVectorException("Vector addition for vectors of different lengths is undefined.");

            return new ComplexVector(this.Zip(vector, (leftSummand, rightSummand) => leftSummand + rightSummand));
        }

        IReadOnlyComplexVector IReadOnlyComplexVector.Add(IReadOnlyVector vector)
        {
            if (Length != vector.Length)
                throw new ComplexVectorException("Vector addition for vectors of different lengths is undefined.");

            return new ComplexVector(this.Zip(vector, (leftSummand, rightSummand) => leftSummand + rightSummand));
        }

        public IComplexVector Subtract(IComplexVector vector)
        {
            if (Length != vector.Length)
                throw new ComplexVectorException("Vector subtraction for vectors of different lengths is undefined.");

            return new ComplexVector(this.Zip(vector, (leftItem, rightItem) => leftItem - rightItem));
        }

        public IComplexVector Subtract(IReadOnlyComplexVector vector)
        {
            if (Length != vector.Length)
                throw new ComplexVectorException("Vector subtraction for vectors of different lengths is undefined.");

            return new ComplexVector(this.Zip(vector, (leftItem, rightItem) => leftItem - rightItem));
        }

        public IComplexVector Subtract(IVector vector)
        {
            if (Length != vector.Length)
                throw new ComplexVectorException("Vector subtraction for vectors of different lengths is undefined.");

            return new ComplexVector(this.Zip(vector, (leftItem, rightItem) => leftItem - rightItem));
        }

        public IComplexVector Subtract(IReadOnlyVector vector)
        {
            if (Length != vector.Length)
                throw new ComplexVectorException("Vector subtraction for vectors of different lengths is undefined.");

            return new ComplexVector(this.Zip(vector, (leftItem, rightItem) => leftItem - rightItem));
        }

        IReadOnlyComplexVector IReadOnlyComplexVector.Subtract(IComplexVector vector)
        {
            if (Length != vector.Length)
                throw new ComplexVectorException("Vector subtraction for vectors of different lengths is undefined.");

            return new ComplexVector(this.Zip(vector, (leftItem, rightItem) => leftItem - rightItem));
        }

        IReadOnlyComplexVector IReadOnlyComplexVector.Subtract(IReadOnlyComplexVector vector)
        {
            if (Length != vector.Length)
                throw new ComplexVectorException("Vector subtraction for vectors of different lengths is undefined.");

            return new ComplexVector(this.Zip(vector, (leftItem, rightItem) => leftItem - rightItem));
        }

        IReadOnlyComplexVector IReadOnlyComplexVector.Subtract(IVector vector)
        {
            if (Length != vector.Length)
                throw new ComplexVectorException("Vector subtraction for vectors of different lengths is undefined.");

            return new ComplexVector(this.Zip(vector, (leftItem, rightItem) => leftItem - rightItem));
        }

        IReadOnlyComplexVector IReadOnlyComplexVector.Subtract(IReadOnlyVector vector)
        {
            if (Length != vector.Length)
                throw new ComplexVectorException("Vector subtraction for vectors of different lengths is undefined.");

            return new ComplexVector(this.Zip(vector, (leftItem, rightItem) => leftItem - rightItem));
        }

        public Complex InnerProduct(IComplexVector vector)
        {
            if (Length != vector.Length)
                throw new ComplexVectorException("Inner product is undefined for vectors of different length.");

            var sum = new Complex(0, 0);

            foreach (var product in this.Zip(vector, (leftFactor, rightFactor) => leftFactor * rightFactor))
                sum += product;

            return sum;
        }

        public Complex InnerProduct(IReadOnlyComplexVector vector)
        {
            if (Length != vector.Length)
                throw new ComplexVectorException("Inner product is undefined for vectors of different length.");

            var sum = new Complex(0, 0);

            foreach (var product in this.Zip(vector, (leftFactor, rightFactor) => leftFactor * rightFactor))
                sum += product;

            return sum;
        }

        public Complex InnerProduct(IVector vector)
        {
            if (Length != vector.Length)
                throw new ComplexVectorException("Inner product is undefined for vectors of different length.");

            var sum = new Complex(0, 0);

            foreach (var product in this.Zip(vector, (leftFactor, rightFactor) => leftFactor * rightFactor))
                sum += product;

            return sum;
        }

        public Complex InnerProduct(IReadOnlyVector vector)
        {
            if (Length != vector.Length)
                throw new ComplexVectorException("Inner product is undefined for vectors of different length.");

            var sum = new Complex(0, 0);

            foreach (var product in this.Zip(vector, (leftFactor, rightFactor) => leftFactor * rightFactor))
                sum += product;

            return sum;
        }

        public Complex SesquilinearInnerProduct(IComplexVector vector)
        {
            if (Length != vector.Length)
                throw new ComplexVectorException("Sesquilinear inner product is undefined for vectors of different length.");

            var sum = new Complex(0, 0);

            // conjugate each item in the current vector instance to create a conjugate vector, then perform the usual inner product
            foreach (var product in this.Select(z => new Complex(z.Real, -z.Imaginary))
                .Zip(vector, (leftFactor, rightFactor) => leftFactor * rightFactor))
                sum += product;

            return sum;
        }

        public Complex SesquilinearInnerProduct(IReadOnlyComplexVector vector)
        {
            if (Length != vector.Length)
                throw new ComplexVectorException("Sesquilinear inner product is undefined for vectors of different length.");

            var sum = new Complex(0, 0);

            // conjugate each item in the current vector instance to create a conjugate vector, then perform the usual inner product
            foreach (var product in this.Select(z => new Complex(z.Real, -z.Imaginary))
                .Zip(vector, (leftFactor, rightFactor) => leftFactor * rightFactor))
                sum += product;

            return sum;
        }

        public Complex SesquilinearInnerProduct(IVector vector)
        {
            if (Length != vector.Length)
                throw new ComplexVectorException("Sesquilinear inner product is undefined for vectors of different length.");

            var sum = new Complex(0, 0);

            // conjugate each item in the current vector instance to create a conjugate vector, then perform the usual inner product
            foreach (var product in this.Select(z => new Complex(z.Real, -z.Imaginary))
                .Zip(vector, (leftFactor, rightFactor) => leftFactor * rightFactor))
                sum += product;

            return sum;
        }

        public Complex SesquilinearInnerProduct(IReadOnlyVector vector)
        {
            if (Length != vector.Length)
                throw new ComplexVectorException("Sesquilinear inner product is undefined for vectors of different length.");

            var sum = new Complex(0, 0);

            // conjugate each item in the current vector instance to create a conjugate vector, then perform the usual inner product
            foreach (var product in this.Select(z => new Complex(z.Real, -z.Imaginary))
                .Zip(vector, (leftFactor, rightFactor) => leftFactor * rightFactor))
                sum += product;

            return sum;
        }

        public IComplexMatrix OuterProduct(IComplexVector vector)
        {
            var rowVectors = new List<IComplexVector>(Length);

            // the outer product has the effect of scaling the copies of the input vector by each of the
            // elements in the current vector instance
            foreach (var element in this)
                rowVectors.Add(new ComplexVector(vector.MultiplyByScalar(element)));

            return new ComplexMatrix(rowVectors);
        }

        public IComplexMatrix OuterProduct(IReadOnlyComplexVector vector)
        {
            var rowVectors = new List<IComplexVector>(Length);

            // the outer product has the effect of scaling the copies of the input vector by each of the
            // elements in the current vector instance
            foreach (var element in this)
                rowVectors.Add(new ComplexVector(vector.MultiplyByScalar(element)));

            return new ComplexMatrix(rowVectors);
        }

        public IComplexMatrix OuterProduct(IVector vector)
        {
            var rowVectors = new List<IComplexVector>(Length);

            // the outer product has the effect of scaling the copies of the input vector by each of the
            // elements in the current vector instance
            foreach (var thisElement in this)
                rowVectors.Add(new ComplexVector(vector.Select(thatElement => thisElement * thatElement)));

            return new ComplexMatrix(rowVectors);
        }

        public IComplexMatrix OuterProduct(IReadOnlyVector vector)
        {
            var rowVectors = new List<IComplexVector>(Length);

            // the outer product has the effect of scaling the copies of the input vector by each of the
            // elements in the current vector instance
            foreach (var thisElement in this)
                rowVectors.Add(new ComplexVector(vector.Select(thatElement => thisElement * thatElement)));

            return new ComplexMatrix(rowVectors);
        }

        IReadOnlyComplexMatrix IReadOnlyComplexVector.OuterProduct(IComplexVector vector)
        {
            var rowVectors = new List<IComplexVector>(Length);

            // the outer product has the effect of scaling the copies of the input vector by each of the
            // elements in the current vector instance
            foreach (var thisElement in this)
                rowVectors.Add(new ComplexVector(vector.Select(thatElement => thisElement * thatElement)));

            return new ComplexMatrix(rowVectors);
        }

        IReadOnlyComplexMatrix IReadOnlyComplexVector.OuterProduct(IReadOnlyComplexVector vector)
        {
            var rowVectors = new List<IComplexVector>(Length);

            // the outer product has the effect of scaling the copies of the input vector by each of the
            // elements in the current vector instance
            foreach (var thisElement in this)
                rowVectors.Add(new ComplexVector(vector.Select(thatElement => thisElement * thatElement)));

            return new ComplexMatrix(rowVectors);
        }

        IReadOnlyComplexMatrix IReadOnlyComplexVector.OuterProduct(IVector vector)
        {
            var rowVectors = new List<IComplexVector>(Length);

            // the outer product has the effect of scaling the copies of the input vector by each of the
            // elements in the current vector instance
            foreach (var thisElement in this)
                rowVectors.Add(new ComplexVector(vector.Select(thatElement => thisElement * thatElement)));

            return new ComplexMatrix(rowVectors);
        }

        IReadOnlyComplexMatrix IReadOnlyComplexVector.OuterProduct(IReadOnlyVector vector)
        {
            var rowVectors = new List<IComplexVector>(Length);

            // the outer product has the effect of scaling the copies of the input vector by each of the
            // elements in the current vector instance
            foreach (var thisElement in this)
                rowVectors.Add(new ComplexVector(vector.Select(thatElement => thisElement * thatElement)));

            return new ComplexMatrix(rowVectors);
        }

        public IComplexVector MultiplyByScalar(Complex scalar)
        {
            return new ComplexVector(this.Select(element => scalar * element));
        }

        public IComplexVector MultiplyByScalar(double scalar)
        {
            return new ComplexVector(this.Select(element => scalar * element));
        }

        IReadOnlyComplexVector IReadOnlyComplexVector.MultiplyByScalar(Complex scalar)
        {
            return new ComplexVector(this.Select(element => scalar * element));
        }

        IReadOnlyComplexVector IReadOnlyComplexVector.MultiplyByScalar(double scalar)
        {
            return new ComplexVector(this.Select(element => scalar * element));
        }

        public bool Equals(IComplexVector other)
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

        public bool Equals(IReadOnlyComplexVector other)
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

        public IEnumerator<Complex> GetEnumerator()
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
