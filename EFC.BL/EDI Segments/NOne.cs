﻿using System.Text;

namespace EFC.BL.EDI_Segments
{
    public class NOne
    {
        public string BuildNOne(InsuranceCompany insurance)
        {
            var buildNOne = new StringBuilder();

            buildNOne.Append("N1" + "*");
            buildNOne.Append("PR" + "*");//N101 Payer Identifier Code
            buildNOne.Append(insurance.Name + "*"); //N102 Payer Name
            buildNOne.Append("XV" + "*"); //N103 Identification Code Qualifier
            buildNOne.Append("20123"); //N104 Payer Identification Code
            buildNOne.Append("~");

            return buildNOne.ToString();

        }

        public string BuildNOne(BillingProvider billingProvider)
        {
            var buildNOne = new StringBuilder();

            buildNOne.Append("N1" + "*");
            buildNOne.Append("PE" + "*"); //N101 Payer Identifier Code
            buildNOne.Append(billingProvider.Name + "*"); //N102 Payee Name
            buildNOne.Append("XX" + "*"); //N103 Payee Identification Qualifier
            buildNOne.Append(billingProvider.Npi); //N104 Payee Identification Code
            buildNOne.Append("~");

            return buildNOne.ToString();
        }
    }
}
