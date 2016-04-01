using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsMathematics.AbstractAlgebra.NumberFields
{
    internal interface IFieldMember
    {
        bool IsAdditiveIdentity { get; }
        bool IsMultiplicativeIdentity { get; }

        IField ParentField { get; }


        /// <summary>
        /// Adds the current instance of IFieldMember to the input.
        /// </summary>
        /// <param name="fieldElement">The right element in the binary addition operation.</param>
        /// <returns>A new IFieldMember instance which is the sum of the current instance and the input.</returns>
        IFieldMember Add(IFieldMember fieldElement);

        /// <summary>
        /// Multiplies the current instance of IFieldMember with the input.
        /// </summary>
        /// <param name="fieldElement">The right element in the binary multiplication operation.</param>
        /// <returns>A new IFieldMember instance which is the sum of the current instance and the input.</returns>
        IFieldMember Multiply(IFieldMember fieldElement);
    }
}
