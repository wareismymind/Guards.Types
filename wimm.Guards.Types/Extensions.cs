using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wimm.Guards.Types
{
    public static class Extensions
    {
        /// <summary>
        /// Method for converting types into definitely types. Mostly for interfaces.
        /// </summary>
        /// <remarks> Generally this should only be necessary for interface classes to ensure they aren't null
        /// the C# language doesn't allow implicit conversions to or from interfaces other than up the 
        /// inheritance heirarchy and we don't want to have to expose a public constructor (for now). 
        /// [Conditional](PublicConstructor)
        /// </remarks>
        /// <returns> A <see cref="Definitely{T}"/> containing the object <paramref name="toConvert"/> </returns>
        public static Definitely<T> ToDefinitely<T>(this T toConvert) where T : class
        {
            return new Definitely<T>(toConvert);
        }
    }
}
