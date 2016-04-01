using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsMathematics.AbstractAlgebra.NumberFields
{
    internal class RationalMultiplication : IFieldOperation
    {
        public bool IsAbelian { get { return true; } }

        public bool IsAssociative { get { return true; } }

        public IFieldMember Operate(IFieldMember a, IFieldMember b)
        {
            return a.Add(b);
        }
    }
}
