using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC.BL.EDI_Segments
{
    class NFour
    {
        public string BuildNFour(InsuranceCompany insurance)
        {
            var buildNFour = new StringBuilder();

           buildNFour.Append("N4" + "*");
           buildNFour.Append(insurance.Address.City + "*"); //N401 Payer City Line
           buildNFour.Append(insurance.Address.State + "*");     //N402 Payer City Name
           buildNFour.Append(insurance.Address.ZipCode); // N403 Payer City Zip
           buildNFour.Append("~");

            return buildNFour.ToString();
        }
        public string BuildNFour(BillingProvider billingProvider)
        {
            var buildNFour = new StringBuilder();

            buildNFour.Append("N4" + "*");
            buildNFour.Append(billingProvider.Address.City + "*"); //N401 Payee City Name
            buildNFour.Append(billingProvider.Address.State + "*"); //N402 Payee State Name
            buildNFour.Append(billingProvider.Address.ZipCode); //N403 Payee Payee Postal Zone or Zip Code
            buildNFour.Append("~");

            return buildNFour.ToString();
        }
    }
}
