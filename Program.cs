using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using CsMathematics;
using CsMathematics.LinearAlgebra;
using CsMathematics.DifferentialEquations;

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

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, world!");
            var z = new Complex(12, 6);

            Console.WriteLine("The first complex number is: {0}", z);
            Console.WriteLine("The number z^2 is: {0}", (z*z));
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");



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
