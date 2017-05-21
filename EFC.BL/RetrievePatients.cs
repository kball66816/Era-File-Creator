using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace EFC.BL
{
    /// <summary>
    /// Store and Retrieve Patient data
    /// </summary>
    public class RetrievePatients : INotifyPropertyChanged
    {
        public RetrievePatients()
        {
            patientList = new List<Patient>();
        }


        private static List<Patient> patientList { get; set; }

        private static List<Patient> getPatientList = patientList;

        public void AddPatient(Patient patient)
        {
            patientList.Add(patient);
        }

        public static List<Patient> barb { get { return patientList; } }
        private string countPatients;

        public string CountPatients
        {
            get
            {
                return patientList.Count.ToString();
            }

            set
            {
                if (value != countPatients)
                {
                    countPatients = value;
                }
            }
        }

        public List<Patient> GetPatientList()
        {
            return getPatientList;
        }



        public Patient NextPatient(Patient patient)
        {
            int index = Index(patient);

            if (index == EndOfList())
            {
                return patientList[0];
            }
            else
            {
                return patientList[index + 1];
            }
        }

        public Patient PreviousPatient(Patient patient)
        {
            int index = Index(patient);

            if (index == 0)
            {
                return patientList[EndOfList()];
            }
            else
            {
                return patientList[index - 1];
            }
        }

        private int Index(Patient patient)
        {
            return patientList.IndexOf(patient);
        }

        private int EndOfList()
        {
            return patientList.Count - 1;
        }

        public Patient LastPatient()
        {
            return patientList.Last();
        }

        public Charge ReturnLastPatientsCharge()
        {
            return patientList.Last().Charge;
        }


       
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)

        {
            if (propertyName != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        } 
    }

}
