using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC.BL.EDI_Segments
{
    class Lx
    {
        public string BuildLx()
        {
            var buildLx = new StringBuilder();

           buildLx.Append("LX*");
           buildLx.Append("1"); //Claim Sequence Number
           buildLx.Append("~");

            return buildLx.ToString();
        }
    }
}
