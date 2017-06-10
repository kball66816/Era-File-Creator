﻿using System;
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
    
    [Serializable]
    public class PlaceOfService : INotifyPropertyChanged
    {
        private string serviceLocation;

        public string ServiceLocation
        {
            get { return serviceLocation; }
            set
            {
                if (value != serviceLocation)
                {
                    serviceLocation = value;
                    RaisePropertyChanged("ServiceLocation");
                }
            }
        }

        public Dictionary<string, string> PlacesOfService = new Dictionary<string, string>
        {
            {"01","Pharmacy" },
            {"02","TeleHealth" },
            {"03","School" },
            {"04","Homeless Shelter" },
            {"05","Indian Health Service Free-standing Facility" },
            {"06","Indian Health Service Provider-based Facility" },
            {"07" ,"Tribal 638 Free-standing Facility"},
            {"08","Tribal 638 Provider-based Facility" },
            {"09","Prison/Correctional Facility"},
            {"11","Office" },
            {"12","Home" },
            {"13","Assisted Living Facility" },
            {"14","Group Home" },
            {"15","Mobile Unit" },
            {"16","Temporary Loding" },
            {"17","Walk-in Retail Health Clinic" },
            {"18" ,"Place of Employment - Worksite"},
            {"19","Off Campus-Outpatient Hospital" },
            {"20","Urgent Care Facility" },
            {"21","Inpatient Hospital" },
            {"22" ,"On Campus-Outpatient Hospital"},
            {"23","Emergency Room - Hospital" },
            {"24","Ambulatory Surgical Center" },
            {"25","Birthing Center" },
            {"26","Military Treatment Facility" },
            {"31","Skilled Nursing Facility" },
            {"33","Custodial Care Facility" },
            {"34","Hospice" },
            {"41" ,"Ambulance - Land"},
            {"42","Ambulance - Air or Water" },
            {"49","Independent Clinic" },
            {"50" ,"Federally Qualified Health Center"},
            {"51","Inpatient Psychiatric Facility" },
            {"52","Psychiatric Facility - Partial Hospitalization" },
            {"53","Community Mental Health Center" },
            {"54","Intermediate Care Facility/Individuals with Intellectual Disabilities" },
            {"55","Residential Substance Abuse Treatment" },
            {"56","Psychiatric Residential Treatment Center" },
            {"57","Non-Residential Substance Abuse Treatment Facility" },
            {"60","Mass Immunization Center" },
            {"61","Comprehensive Inpatient Rehabilitation Facility"},
            {"62","Comprehensive Outpatient Rehabilitation Facility" },
            {"65","End-Stage Renal Disease Treatment Facility" },
            {"71" ,"Public Health Clinic"},
            {"72","Rural Health Clinic"},
            {"81","Independent Laboratory" },
            {"99","Other Place of Service" }
        };

        [field: NonSerialized]
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
