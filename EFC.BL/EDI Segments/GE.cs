using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC.BL.EDI_Segments
{
    class Ge
    {
        public string BuildGe()
        {
            var buildGe = new StringBuilder();
           buildGe.Append("GE*");
           buildGe.Append("1*");
           buildGe.Append("201541257");
           buildGe.Append("~");
            return buildGe.ToString();
        }
    }
}
