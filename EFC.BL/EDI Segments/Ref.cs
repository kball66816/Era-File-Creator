﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC.BL.EDI_Segments
{
    class Ref
    {
        public string BuildRef()
        {
            var buildRef = new StringBuilder();

            buildRef.Append("REF" + "*");
            buildRef.Append("2U" + "*");
            buildRef.Append("20123");
            buildRef.Append("~");

            return buildRef.ToString();
        }

        public string BuildRefAdditionalPayee()
        {
            var buildRef = new StringBuilder();

            buildRef.Append("REF" + "*");
            buildRef.Append("PQ" + "*"); //Ref01 Additional Payee Identification Qualifier Exempt Provider
            buildRef.Append("1440054" + "~"); //Ref02 Reference Identification Code

            return buildRef.ToString();
        }

        public string BuildRefAdditionalPayeeTwo()
        {
            var buildRef = new StringBuilder();

            buildRef.Append("REF" + "*");
            buildRef.Append("TJ" + "*"); //Ref01 Additional Payee Identification Qualifier Non-Exempt
            buildRef.Append("122074233" + "~"); //Ref02 Additional reference Identification Code TaxId

            return buildRef.ToString();
        }

        public string BuildRef(Provider provider)
        {
            var buildRef = new StringBuilder();

            buildRef.Append("REF" + "*");
            buildRef.Append("G2" + "*");
            buildRef.Append("7570867");
            buildRef.Append("~");

            return buildRef.ToString();

        }

        //REF Service Identification 2110
        //REF01 Reference Identification Qualifier
        //REF02 Provider Identifier


        //REF Line Item Control Number 2110

        public string BuildRefControlNumber()
        {
            var buildRef = new StringBuilder();

            buildRef.Append("REF" + "*");
            buildRef.Append("6R" + "*"); //REF01 Reference Control Number identifier
            buildRef.Append("1"); //REF02 Reference Control Number submitted on claim
            buildRef.Append("~");

            return buildRef.ToString();
        }

        //REF Rendering Provider Information 2110
        //REF01 Reference Identification NUmber
        //REF02 Rendering Provider Federal ID
    }
}
