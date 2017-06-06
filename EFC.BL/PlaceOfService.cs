using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC.BL
{
    /// <summary>
    /// Places of Service are codified defined locations that a medical or healthcare service is rendered
    /// </summary>
    public class PlaceOfService:INotifyPropertyChanged
    {
        private string serviceLocation;

        public string ServiceLocation
        {
            get { return serviceLocation; }
            set
            {
                if(value!=serviceLocation)
                {
                    serviceLocation = value;
                    RaisePropertyChanged("ServiceLocation");
                }
            }
        }

        public Dictionary<string, string> PlacesOfService = new Dictionary<string, string>
        {
            { "Pharmacy","01" },
            {"TeleHealth","02" },
            {"School","03" },
            {"Homeless Shelter","04" },
            {"Indian Health Service Free-standing Facility","05" },
            {"Indian Health Service Provider-based Facility","06" },
            {"Tribal 638 Free-standing Facility","07" },
            {"Tribal 638 Provider-based Facility","08" },
            {"Prison/Correctional Facility","09" },
            {"Office","11" },
            {"Home","12" },
            {"Assisted Living Facility","13" },
            {"Group Home","14" },
            {"Mobile Unit","15" },
            {"Temporary Loding","16" },
            {"Walk-in Retail Health Clinic","17" },
            {"Place of Employment - Worksite","18" },
            {"Off Campus-Outpatient Hospital","19" },
            {"Urgent Care Facility","20" },
            {"Inpatient Hospital","21" },
            {"On Campus-Outpatient Hospital","22" },
            {"Emergency Room - Hospital","23" },
            {"Ambulatory Surgical Center","24" },
            {"Birthing Center","25" },
            {"Military Treatment Facility","26" },
            {"Skilled Nursing Facility","31" },
            {"Custodial Care Facility", "33" },
            {"Hospice","34" },
            {"Ambulance - Land","41" },
            {"Ambulance - Air or Water","42" },
            {"Independent Clinic","49" },
            {"Federally Qualified Health Center","50" },
            {"Inpatient Psychiatric Facility","51" },
            {"Psychiatric Facility - Partial Hospitalization","52" },
            {"Community Mental Health Center","53" },
            {"Intermediate Care Facility/Individuals with Intellectual Disabilities","54" },
            {"Residential Substance Abuse Treatment","55" },
            {"Psychiatric Residential Treatment Center","56" },
            {"Non-Residential Substance Abuse Treatment Facility","57" },
            {"Mass Immunization Center","60" },
            {"Comprehensive Inpatient Rehabilitation Facility","61"},
            {"Comprehensive Outpatient Rehabilitation Facility","62" },
            {"End-Stage Renal Disease Treatment Facility","65" },
            {"Public Health Clinic","71" },
            {"Rural Health Clinic","72" },
            {"Independent Laboratory","81" },
            {"Other Place of Service","99" }
        };

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
