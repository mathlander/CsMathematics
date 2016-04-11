using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsMathematics.LinearAlgebra;

namespace CsMathematics.Calculus
{
    /// <summary>
    /// Represents a function f: R^n -&gt; R and is differentiable with respect to all domain variables.
    /// </summary>
    public interface IDifferentiableTerm
    {
        IDifferentiableTerm DifferentiateWrtKthParameter(int k);

        //IDifferentiableTerm Differentiate();

        double Evaluate(IVector vector);
    }
}
