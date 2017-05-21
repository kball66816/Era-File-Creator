using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC.BL
{
    /// <summary>
    /// Base properties of a Rendering Provider
    /// </summary>
    public class RenderingProvider: Provider
    {
        public string FullName()
        {
            string fullName = FirstName;

            if (!string.IsNullOrEmpty(LastName))
            {
                fullName = fullName += " " + LastName;
            }
            return fullName;
        }

 
    }
}
