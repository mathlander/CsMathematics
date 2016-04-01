using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsMathematics.LinearAlgebra;

namespace CsMathematics.DifferentialEquations
{
    public static class NumericalIntegrator
    {
        public static Func<IVector, IVector> SolveSystemByRungeKutta()
        {
            // use the Runge-Kutta 4-step method to solve a system of differential equations numerically
            // the return value is a function F(x), represented by Func<IVector, IVector>
            // the input to F(x) = y, is a vector (x) and the output is also a vector (y)

            // this should be a C# port of the Runge-Kutta (4,5) formula used by ode45 of MATLAB
            // consider implementing their other solvers, ode113, ode15, and ode23
            return (vector => vector.MultiplyByScalar(2));
        }

        public static double TrapezoidScalar(Func<double, double> f_t, double t_0, double t_f, int steps = 100)
        {
            var stepSize = (t_f - t_0) / steps;
            var t_series = Enumerable.Range(1, steps)
                .Select(stepNumber => t_0 + (stepNumber * stepSize) );

            var sum = 0.0;
            var y_1 = f_t(t_0);

            foreach (var t_i in t_series)
            {
                var y_2 = f_t(t_i);
                sum += stepSize * (y_2 + y_1) / 2;

                // the area of each trapezoid is computed between successive measurements f(t_i)
                y_1 = y_2;
            }

            return sum;
        }

        public static IVector TrapezoidVector(Func<double, IVector, IVector> f_ty, IVector y_0, double t_0, double t_f, int steps = 100)
        {
            // consider a path on the euclidean plane
            // let the time series y_{i+1} = f(t_i, y_i), from t_0 = 0.0, t_f = 1.0
            // be the evaluations of a solution y to an IVP
            // then, the vector returned by this method represents a final state vector
            //
            // in 2-dim space, the function would map out a path on a flat surface (e.g. a kitchen floor)
            // taken by Pac-Man over the time interval [t_0, t_f]
            //
            // Pac-Man, fueled by a rage against yellow eggs, never stops moving
            // his position at t_f, depends both on where he started, and the path he chose
            // this path, is determined by f_ty, i.e. f_ty is you, my Pac-Man playing friend
            // and your game of Pac-Man, and over time (say, measured in Pac-Man game lengths {PGL's, for short})
            //
            // define:
            //      1 PGL = 1 Pac-Man Game Length
            //            := t_f - t_0
            //
            //
            var stepSize = (t_f - t_0) / steps;
            var t_series = Enumerable.Range(1, steps)
                .Select(stepNumber => t_0 + (stepNumber * stepSize));

            IVector currentPosition = f_ty(t_0, y_0);

            foreach (var t_i in t_series)
            {
                // prediction step
                IVector nextPositionPredictor = f_ty(t_i, currentPosition);
                // correction step
                currentPosition = f_ty(t_i, nextPositionPredictor.Add(currentPosition).MultiplyByScalar(1/2) );
            }

            return currentPosition;
        }

        public static IVector LineIntegrator(Func<double, IVector, IVector> f_ty, IVector y_0, double t_0, double t_f, int steps = 100)
        {
            var x_i = y_0[1];
            var y_i = y_0[2];
            var z_i = y_0[3];

            var stepSize = (t_f - t_0) / steps;
            var t_series = Enumerable.Range(1, steps)
                .Select(stepNumber => t_0 + (stepNumber * stepSize));

            IVector currentPosition = f_ty(t_0, y_0);

            foreach (var t_i in t_series)
            {
                // prediction step
                IVector nextPositionPredictor = f_ty(t_i, currentPosition);
                // correction step
                currentPosition = f_ty(t_i, nextPositionPredictor.Add(currentPosition).MultiplyByScalar(1 / 2));
            }

            return currentPosition;
        }
    }
}
