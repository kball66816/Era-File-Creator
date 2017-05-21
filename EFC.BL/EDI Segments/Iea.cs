using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC.BL.EDI_Segments
{
    class Iea
    {
        public string BuildIea()
        {
            var buildIea = new StringBuilder();
            
                buildIea.Append("IEA*");
                buildIea.Append("1*");
                buildIea.Append("201541257");
                buildIea.Append("~");

            return buildIea.ToString();

        }
    }
}
