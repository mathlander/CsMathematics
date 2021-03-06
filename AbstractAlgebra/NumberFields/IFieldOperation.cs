﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsMathematics.AbstractAlgebra.NumberFields
{
    internal interface IFieldOperation : IBinaryOperation
    {
        IFieldMember Operate(IFieldMember a, IFieldMember b);
    }
}
