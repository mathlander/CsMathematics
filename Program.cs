using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using CsMathematics;
using CsMathematics.Calculus;
using CsMathematics.DifferentialEquations;
using CsMathematics.Functions;
using CsMathematics.LinearAlgebra;

namespace CsMathematics
{
    class Program
    {
        private static void TestTrapezoidIntegration()
        {
            Func<double, double> f = (t) => 3.14;
            var integral = NumericalIntegrator.TrapezoidScalar(f, 0.0, 1.0, 3);

            // expected: 3.14
            // actual: 3.14314000000003
            Console.WriteLine(String.Format(@"\int_0^1 f(t) = {0}", integral));
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        private static void TestTrapezoidVectorIntegration()
        {
            IVector initialPosition = new Vector(new[] { 1.0, 0.0 });
            Func<double, IVector, IVector> f_ty = (t, y) => new Vector(new[] { Math.Cos(t), Math.Sin(t) });
            var vectorIntegral = NumericalIntegrator.TrapezoidVector(f_ty, initialPosition, 0.0, 4.0 * Math.PI / 2.0, 1000);

            // expected: 3.14
            // actual: 3.14314000000003
            Console.WriteLine(String.Format(@"\int_0^1 f(t,y) = [{0}, {1}]", vectorIntegral[1], vectorIntegral[2]));
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        private static void TestPolynomial()
        {
            var poly = new Polynomial(new[] { 100.0, 20.0, 1.0 });
            var x = 4.0;

            Console.WriteLine("The polynomial is given by: f(x) = {0}", poly);
            Console.WriteLine("The polynomial evaluated at x={0} is f(x) = {1}", x, poly.Evaluate(x));
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        static void Main(string[] args)
        {
            ////////////////////////////////////////////////////////////////////////
            /////////////////////////    Test Polynomial    ////////////////////////
            ////////////////////////////////////////////////////////////////////////

            TestPolynomial();

            ////////////////////////////////////////////////////////////////////////
            ////////////////////    Test Trapezoid Integration    //////////////////
            ////////////////////////////////////////////////////////////////////////

            TestTrapezoidIntegration();

            ////////////////////////////////////////////////////////////////////////
            ////////////////    Test Trapezoid Vector Integration    ///////////////
            ////////////////////////////////////////////////////////////////////////

            TestTrapezoidVectorIntegration();

            Console.ReadKey();
        }
    }
}
