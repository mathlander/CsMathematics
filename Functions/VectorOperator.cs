using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsMathematics.LinearAlgebra;

namespace CsMathematics.Functions
{
    internal class VectorOperator : IVectorOperator
    {
        private readonly IDictionary<int, IFunctional> _elements;

        public VectorOperator(IEnumerable<IFunctional> elements)
        {
            _elements = new SortedDictionary<int, IFunctional>();
            var i = 1;

            foreach (var item in elements)
            {
                _elements.Add(i, item);
                i++;
            }
        }

        public IEnumerable<IFunctional> Components
        {
            get { return _elements.Values; }
        }

        public IVector Evaluate(IVector vector)
        {
            return new Vector(_elements.Values.Select(f => f.Evaluate(vector)));
        }

        public IEnumerator<IFunctional> GetEnumerator()
        {
            return _elements.Values.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
