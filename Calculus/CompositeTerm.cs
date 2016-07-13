using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsMathematics.LinearAlgebra;

namespace CsMathematics.Calculus
{
    /// <summary>
    /// An exception custom to CsMathematics.LinearAlgebra.CompositeTerm.
    /// </summary>
    public class CompositeTermExecption : Exception { public CompositeTermExecption(string message) : base(message) { } }

    /// <summary>
    /// A chain of terms where the output of the inner term becomes the input to the outer term.
    /// For example, let f(x) = g(h(x)).  Then, f'(x) = g'(h(x))*h'(x)*dx.
    /// </summary>
    public class CompositeTerm : IDifferentiableTerm
    {
        private readonly double _scalar;
        private readonly double _power;
        private readonly CompositeTermType _type;
        private readonly IDifferentiableTerm _innerTerm;

        public CompositeTerm(CompositeTermType type, double scalar, double power, IDifferentiableTerm innerTerm)
        {
            _type = type;
            _scalar = scalar;
            _power = power;
            _innerTerm = innerTerm;
        }

        public IDifferentiableTerm DifferentiateWrtKthParameter(int k)
        {
            var newScalar = _scalar * _power;
            var newPower = _power-1;
            var hPrime = _innerTerm.DifferentiateWrtKthParameter(k);

            IDifferentiableTerm firstFactor;
            IDifferentiableTerm secondFactor;
            IDifferentiableTerm firstProduct;
            IDifferentiableTerm constTerm;
            IDifferentiableTerm hSquared;
            IDifferentiableTerm innerSum;
            IDifferentiableTerm sqrtTerm;
            IDifferentiableTerm denominator;

            switch (_type)
            {
                case CompositeTermType.General:
                    // let f(x) = g(h(x)), then f'(x) = g'(h(x))*h'(x)
                    var gPrime = new CompositeTerm(CompositeTermType.General, newScalar, newPower, _innerTerm);
                    return new ProductTerm(gPrime, hPrime);
                case CompositeTermType.Sin:
                    // let f(x) = sin^n(h(x)), then f'(x) = n*sin^{n-1}(h(x))*cos(h(x))*h'(x)
                    if (_power == 1.0)
                    {
                        var cosTerm = new CompositeTerm(CompositeTermType.Cos, _scalar, 1.0, _innerTerm);
                        return new ProductTerm(cosTerm, hPrime);
                    }

                    firstFactor = new CompositeTerm(CompositeTermType.Sin, newScalar, newPower, _innerTerm);
                    secondFactor = new CompositeTerm(CompositeTermType.Cos, 1.0, 1.0, _innerTerm);
                    firstProduct = new ProductTerm(firstFactor, secondFactor);
                    return new ProductTerm(firstProduct, hPrime);
                case CompositeTermType.Cos:
                    // let f(x) = cos^n(h(x)), then f'(x) = -n*cos^{n-1}(h(x))*sin(h(x))*h'(x)
                    if (_power == 1.0)
                    {
                        var sinTerm = new CompositeTerm(CompositeTermType.Sin, _scalar, 1.0, _innerTerm);
                        return new ProductTerm(sinTerm, hPrime);
                    }

                    firstFactor = new CompositeTerm(CompositeTermType.Cos, -newScalar, newPower, _innerTerm);
                    secondFactor = new CompositeTerm(CompositeTermType.Sin, 1.0, 1.0, _innerTerm);
                    firstProduct = new ProductTerm(firstFactor, secondFactor);
                    return new ProductTerm(firstProduct, hPrime);
                case CompositeTermType.Tan:
                    // let f(x) = tan^n(h(x)), then f'(x) = n*tan^{n-1}(h(x))*sec^2(h(x))*h'(x)
                    if (_power == 1.0)
                    {
                        var secTerm = new CompositeTerm(CompositeTermType.Cos, _scalar, -2.0, _innerTerm);
                        return new ProductTerm(secTerm, hPrime);
                    }

                    firstFactor = new CompositeTerm(CompositeTermType.Tan, newScalar, newPower, _innerTerm);
                    secondFactor = new CompositeTerm(CompositeTermType.Cos, 1.0, -2.0, _innerTerm);
                    firstProduct = new ProductTerm(firstFactor, secondFactor);
                    return new ProductTerm(firstProduct, hPrime);
                case CompositeTermType.Arcsin:
                    // let f(x) = arcsin^n(h(x)), then f'(x) = n*arcsin^{n-1}(h(x))*h'(x) / \sqrt{ 1 - h^2(x) }
                    constTerm = new ConstantTerm(1.0);
                    hSquared = new CompositeTerm(CompositeTermType.General, -1.0, 2.0, _innerTerm);
                    innerSum = new SumTerm(constTerm, hSquared);
                    sqrtTerm = new CompositeTerm(CompositeTermType.General, 1.0, -0.5, innerSum);

                    if (_power == 1.0)
                    {
                        return new ProductTerm(hPrime, sqrtTerm);
                    }

                    firstFactor = new CompositeTerm(CompositeTermType.Arcsin, newScalar, newPower, _innerTerm);
                    firstProduct = new ProductTerm(firstFactor, sqrtTerm);
                    return new ProductTerm(firstProduct, hPrime);
                case CompositeTermType.Arccos:
                    // let f(x) = arccos^n(h(x)), then f'(x) = -n*arccos^{n-1}(h(x))*h'(x) / \sqrt{ 1 - h^2(x) }
                    constTerm = new ConstantTerm(1.0);
                    hSquared = new CompositeTerm(CompositeTermType.General, -1.0, 2.0, _innerTerm);
                    innerSum = new SumTerm(constTerm, hSquared);
                    sqrtTerm = new CompositeTerm(CompositeTermType.General, -1.0, -0.5, innerSum);

                    if (_power == 1.0)
                    {
                        return new ProductTerm(hPrime, sqrtTerm);
                    }

                    firstFactor = new CompositeTerm(CompositeTermType.Arccos, newScalar, newPower, _innerTerm);
                    firstProduct = new ProductTerm(firstFactor, sqrtTerm);
                    return new ProductTerm(firstProduct, hPrime);
                case CompositeTermType.Arctan:
                    // let f(x) = arctan^n(h(x)), then f'(x) = n*arctan^{n-1}(h(x))*h'(x) / (1 + h^2(x))
                    constTerm = new ConstantTerm(1.0);
                    hSquared = new CompositeTerm(CompositeTermType.General, 1.0, 2.0, _innerTerm);
                    innerSum = new SumTerm(constTerm, hSquared);
                    denominator = new CompositeTerm(CompositeTermType.General, 1.0, -1.0, innerSum);

                    if (_power == 1.0)
                    {
                        return new ProductTerm(hPrime, denominator);
                    }

                    firstFactor = new CompositeTerm(CompositeTermType.Arctan, newScalar, newPower, _innerTerm);
                    firstProduct = new ProductTerm(firstFactor, denominator);
                    return new ProductTerm(firstProduct, hPrime);
                case CompositeTermType.Exp:
                    // let f(x) = exp^{n*h(x)}, then f'(x) = n*exp^{n*h(x)}*h'(x)
                    var compositTerm = new CompositeTerm(CompositeTermType.Exp, newScalar, _power, _innerTerm);
                    return new ProductTerm(compositTerm, hPrime);
                case CompositeTermType.Ln:
                    // let f(x) = ln^n(h(x)), then f'(x) = n*ln^{n-1} (h(x)}) * h'(x) / h(x)

                    if (_power == 1.0)
                    {
                        firstFactor = new CompositeTerm(CompositeTermType.Ln, newScalar, newPower, _innerTerm);
                        denominator = new CompositeTerm(CompositeTermType.General, 1.0, -1.0, _innerTerm);
                        firstProduct = new ProductTerm(firstFactor, denominator);
                        return new ProductTerm(firstProduct, hPrime);
                    }

                    denominator = new CompositeTerm(CompositeTermType.General, _scalar, -1.0, _innerTerm);
                    return new ProductTerm(denominator, hPrime);
                default:
                    throw new CompositeTermExecption("The specified CompositeTermType is undefined.");
            }
        }

        public double Evaluate(IVector vector)
        {
            switch (_type)
            {
                case CompositeTermType.General:
                    // let f(x) = g(h(x))
                    return _scalar * Math.Pow(_innerTerm.Evaluate(vector), _power);
                case CompositeTermType.Sin:
                    // let f(x) = sin^n(h(x))
                    return _scalar * Math.Pow(Math.Sin(_innerTerm.Evaluate(vector)), _power);
                case CompositeTermType.Cos:
                    // let f(x) = cos^n(h(x))
                    return _scalar * Math.Pow(Math.Cos(_innerTerm.Evaluate(vector)), _power);
                case CompositeTermType.Tan:
                    // let f(x) = tan^n(h(x))
                    return _scalar * Math.Pow(Math.Tan(_innerTerm.Evaluate(vector)), _power);
                case CompositeTermType.Arcsin:
                    // let f(x) = arcsin^n(h(x))
                    return _scalar * Math.Pow(Math.Asin(_innerTerm.Evaluate(vector)), _power);
                case CompositeTermType.Arccos:
                    // let f(x) = arccos^n(h(x))
                    return _scalar * Math.Pow(Math.Acos(_innerTerm.Evaluate(vector)), _power);
                case CompositeTermType.Arctan:
                    // let f(x) = arctan^n(h(x))
                    return _scalar * Math.Pow(Math.Atan(_innerTerm.Evaluate(vector)), _power);
                case CompositeTermType.Exp:
                    // let f(x) = exp^{n*h(x)}
                    return _scalar * Math.Exp(_power * _innerTerm.Evaluate(vector));
                case CompositeTermType.Ln:
                    // let f(x) = ln^n(h(x))
                    return _scalar * Math.Pow(Math.Log(_innerTerm.Evaluate(vector)), _power);
                default:
                    throw new CompositeTermExecption("The specified CompositeTermType is undefined.");
            }
        }
    }
}
