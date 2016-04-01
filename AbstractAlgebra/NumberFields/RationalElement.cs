using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CsMathematics.AbstractAlgebra.NumberFields
{
    public class RationalElementException : Exception { public RationalElementException(string message) : base(message) { } }

    /// <summary>
    /// An enhancement to the BigInt struct provided by the base class library.  The class
    /// uses the field axioms which define the rational numbers to represent rational numbers
    /// of arbitrary size, by considering them field members.
    /// </summary>
    internal class RationalElement : IFieldMember, IComparable<RationalElement>, IComparable<int>, IComparable<long>, IEquatable<RationalElement>, IEquatable<int>, IEquatable<long>
    {
        private static readonly RationalElement _additiveIdentity;
        private static readonly RationalElement _multiplicativeIdentity;

        private readonly BigInteger _integer;
        private readonly BigInteger _remainder;
        private readonly BigInteger _denominator;

        static RationalElement()
        {
            _additiveIdentity = new RationalElement(true);
            _multiplicativeIdentity = new RationalElement(false);
        }

        private RationalElement(bool isAdditiveIdentity)
        {
            // private constructor used to create additive and multiplicative identities
            IsAdditiveIdentity = isAdditiveIdentity;
            IsMultiplicativeIdentity = !isAdditiveIdentity;
            IsInteger = true;
        }

        public RationalElement(BigInteger integer)
        {
            _integer = integer;
            _remainder = 0;
            _denominator = 1;
        }

        public RationalElement(BigInteger integer, BigInteger remainder, BigInteger denominator)
        {
            _integer = integer;
            _remainder = remainder;
            _denominator = denominator;

            if (denominator == 0)
                throw new RationalElementException("Cannot create a rational number whose denominator is zero.");
        }

        public static RationalElement AdditiveIdentity { get { return _additiveIdentity; } }
        public static RationalElement MultiplicativeIdentity { get { return _multiplicativeIdentity; } }

        public bool IsAdditiveIdentity { get; private set; }
        public bool IsMultiplicativeIdentity { get; private set; }
        public bool IsInteger { get; private set; }

        public BigInteger IntegralPart { get { return _integer; } }
        public BigInteger Remainder { get { return _remainder; } }
        public BigInteger Denominator { get { return _denominator; } }

        public IField ParentField
        {
            get { return RationalField.Instance; }
        }

        public RationalElement Add(RationalElement right)
        {
            var integralPart = this.IntegralPart + right.IntegralPart;
            var numerator = (this.Remainder * right.Denominator) + (this.Denominator * right.Remainder);
            var denominator = this.Denominator * right.Denominator;

            // if the fractional part has become an improper fraction, reduct to a proper fraction
            // and add the whole number to integralPart
            if (numerator >= denominator)
            {
                BigInteger remainder;
                BigInteger integer = BigInteger.DivRem(numerator, denominator, out remainder);

                numerator = remainder;
                integralPart += integer;
            }

            return new RationalElement(integralPart, numerator, denominator);
        }

        public IFieldMember Add(IFieldMember fieldElement)
        {
            if (ParentField != fieldElement.ParentField)
                throw new RationalElementException("Rational addition is undefined for any other fields.");

            return Add((RationalElement)fieldElement);
        }

        public RationalElement Multiply(RationalElement right)
        {
            var leftNumerator = (this.IntegralPart * this.Denominator) + this.Remainder;
            var rightNumerator = (right.IntegralPart * right.Denominator) + right.Remainder;
            var numerator = leftNumerator * rightNumerator;
            var commonDenominator = this.Denominator * right.Denominator;

            // this re-evaluation is always necessary after multiplication
            BigInteger remainder;
            BigInteger integralPart = BigInteger.DivRem(numerator, commonDenominator, out remainder);

            return new RationalElement(integralPart, remainder, commonDenominator);
        }

        public IFieldMember Multiply(IFieldMember fieldElement)
        {
            return Multiply((RationalElement)fieldElement);
        }

        public int CompareTo(RationalElement other)
        {
            if (this.IntegralPart != other.IntegralPart)
                return this.IntegralPart.CompareTo(other.IntegralPart);

            var left = this.Remainder * other.Denominator;
            var right = other.Remainder * this.Denominator;

            return left.CompareTo(right);
        }

        public int CompareTo(int other)
        {
            if (this.IntegralPart != other)
                return this.IntegralPart.CompareTo(other);

            // if the remainder is non-zero, then the current rational element is greater than the input
            return Remainder == 0 ? 0 : 1;
        }

        public int CompareTo(long other)
        {
            if (this.IntegralPart != other)
                return this.IntegralPart.CompareTo(other);

            // if the remainder is non-zero, then the current rational element is greater than the input
            return Remainder == 0 ? 0 : 1;
        }

        public bool Equals(RationalElement other)
        {
            if (this.IntegralPart != other.IntegralPart)
                return false;

            var left = this.Remainder * other.Denominator;
            var right = other.Remainder * this.Denominator;

            return left.Equals(right);
        }

        public bool Equals(int other)
        {
            if (this.IntegralPart != other)
                return false;

            return this.Remainder == 0;
        }

        public bool Equals(long other)
        {
            if (this.IntegralPart != other)
                return false;

            return this.Remainder == 0;
        }

        /*
        public string ToString(int significantDigits)
        {
            var sb = new StringBuilder(this.IntegralPart.ToString());
            //var loopIterations = 

            // use binary search to iteratively approximate decimal, i.e.
            //      if ((2*remainder) < denominator) => remainder < 0.5;
            //
            // the stream of 'n' tests will produce a new fraction in base 2
            // the numerator will be have a 1 for tests (2*reaminder) >= denominator and 0 otherwise
            // the denominator will be 2^n



            return sb.ToString();
        }
        */

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
