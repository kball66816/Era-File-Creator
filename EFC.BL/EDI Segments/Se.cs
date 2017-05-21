using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC.BL.EDI_Segments
{
    class Se
    {
        public string BuildSe()
        {
            var buildSe = new StringBuilder();

            buildSe.Append("SE" + "*");
            buildSe.Append("74" + "*");
            buildSe.Append("000000001");
            buildSe.Append("~");
           return buildSe.ToString();
        }
    }
}
