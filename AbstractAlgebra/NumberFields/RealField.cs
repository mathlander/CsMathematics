using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsMathematics.AbstractAlgebra.NumberFields
{
    internal class RealField : IField
    {
        public IBinaryOperation AdditiveOperator
        {
            get { throw new NotImplementedException(); }
        }

        public IBinaryOperation MultiplicativeOperator
        {
            get { throw new NotImplementedException(); }
        }

        public IFieldMember Add(IFieldMember member)
        {
            throw new NotImplementedException();
        }

        public IFieldMember Multiply(IFieldMember member)
        {
            throw new NotImplementedException();
        }
    }
}
