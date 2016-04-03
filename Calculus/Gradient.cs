using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsMathematics.Functions;
using CsMathematics.LinearAlgebra;

namespace CsMathematics.Calculus
{
    internal class Gradient : IGradient
    {
        private readonly IVectorOperator _vectorOperator;

        public Gradient(IEnumerable<IFunctional> components)
        {
            _vectorOperator = new VectorOperator(components);
        }

        public IEnumerable<IFunctional> Components
        {
            get { throw new NotImplementedException(); }
        }

        public IVector Evaluate(IVector vector)
        {
            return _vectorOperator.Evaluate(vector);
        }

        public IEnumerator<IFunctional> GetEnumerator()
        {
            return _vectorOperator.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
