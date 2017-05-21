using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC.BL.EDI_Segments
{
    class NmOne
    {
        public string BuildNmOne(Patient patient)
        {
            var buildNmOne = new StringBuilder();
            //NM1 Patient Identifier 2100
            buildNmOne.Append("NM1" + "*");
           buildNmOne.Append("QC" + "*");  //NM101 Patient Identifier Code
           buildNmOne.Append("1" + "*"); //NM102 Entity Type Qualifier
           buildNmOne.Append(patient.LastName + "*");//NM103 Patient Last Name
           buildNmOne.Append(patient.FirstName + "*"); //NM104 Patient First Name
           buildNmOne.Append("*");
           buildNmOne.Append(patient.MiddleInitial + "*"); //NM105 Patient Middle Initial
           buildNmOne.Append("*"); //NM106 Name Prefix
           buildNmOne.Append("*"); //NM107 Patient Name Suffix
           buildNmOne.Append("MI" + "*");//NM108 Identification Code Qualifier
           buildNmOne.Append(patient.MemberId); //NM109 Patient Member Number
           buildNmOne.Append("~");
            if (patient.IncludeSubscriber == true)
            {
                //NM1 Insured Identifier 2100
                buildNmOne.Append("NM1" + "*");
                buildNmOne.Append("IL" + "*"); //NM101 Insured Name
                buildNmOne.Append("1" + "*"); //NM102 Insured Entity Type Qualifier
                buildNmOne.Append(patient.Subscriber.LastName + "*");//NM103 Insurance Last Name
                buildNmOne.Append(patient.Subscriber.FirstName + "*");
                buildNmOne.Append(patient.Subscriber.MiddleInitial + "*"); //NM105 Insured Middle Initial
                buildNmOne.Append("*"); //NM106 Insured Name Prefix
                buildNmOne.Append("*"); //NM107 Insured Name Suffix
                buildNmOne.Append("MI" + "*"); //NM108 Identification Code Qualifier
                buildNmOne.Append(patient.Subscriber.MemberId); //NM109 Insured Member Number
                buildNmOne.Append("~");
            }
            //NM1 Service Provider 2100
            buildNmOne.Append("NM1" + "*");
            buildNmOne.Append("82" + "*"); //NM101 Entity Identifier Code
            buildNmOne.Append("1" + "*"); //NM102 Entity Type Qualifier
            buildNmOne.Append(patient.Provider.LastName + "*"); //NM103 Rendering Provider Last Name
            buildNmOne.Append(patient.Provider.FirstName + "*");//NM104 Rendering Provider First Name
            buildNmOne.Append(patient.Provider.MiddleInitial + "*"); //NM105 Rendering Provider Middle Name
            buildNmOne.Append("*"); //NM106 Name Prefix
            buildNmOne.Append("*"); //NM107 Rendering Provider Name Suffix
            buildNmOne.Append("XX" + "*"); //NM108 Rendering Provider Identification Code Qualifier
            buildNmOne.Append(patient.Provider.Npi); //NM109 Rendering Provider Identifier
            buildNmOne.Append("~");

            //NM1 Crossover Carrier
            //NM1 Correct Priority Payer
            return buildNmOne.ToString();

        }
    }
}
