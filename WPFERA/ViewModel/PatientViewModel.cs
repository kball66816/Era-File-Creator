﻿using Common.Common;
using EFC.BL;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WPFERA.Services;

namespace WPFERA.ViewModel
{
    public class PatientViewModel : INotifyPropertyChanged
    {
        public PatientViewModel()
        {
            Settings = new SettingsService();
            LoadInitialPatient();
            LoadBillingProvider();
            Addon = new AddonCharge();
            Adjustment = new Adjustment();
            AddonAdjustment = new Adjustment();
            LoadInsuranceCompany();

            patientRepository.Add(Patient);
            PatientList = patientRepository.GetAllPatients();
            PlacesOfService = Patient.Charge.PlaceOfService.PlacesOfService;
            LoadCommands();
            RefreshAllCounters();
        }

        private void LoadInsuranceCompany()
        {
            Insurance = new InsuranceCompany();
            Insurance = Settings.PullDefaultInsurance(Insurance);
            PaymentTypes = Insurance.PaymentTypes;
            InsuranceStates = Insurance.Address.States;
        }

        private void LoadBillingProvider()
        {
            BillingProvider = new BillingProvider();
            BillingProvider = Settings.PullDefaultBillingProvider(BillingProvider);
            ProviderStates = BillingProvider.Address.States;
        }

        private void LoadInitialPatient()
        {
            Patient = new Patient();
            Patient = Settings.PullDefaultPatient();
        }

        public PatientRepository patientRepository = new PatientRepository();

        SettingsService Settings { get; set; }

        public Dictionary<string, string> InsuranceStates { get; set; }

        public Dictionary<string, string> PaymentTypes { get; set; }

        public Dictionary<string, string> PlacesOfService { get; set; }

        private InsuranceCompany insurance;

        public InsuranceCompany Insurance
        {
            get { return insurance; }
            set
            {
                if (value != insurance)
                {
                    insurance = value;
                    RaisePropertyChanged("Insurance");
                }
            }
        }

        public Dictionary<string, string> ProviderStates { get; set; }

        private BillingProvider billingProvider;

        public BillingProvider BillingProvider
        {
            get { return billingProvider; }
            set
            {
                if (value != billingProvider)
                {
                    billingProvider = value;
                    RaisePropertyChanged("BillingProvider");
                }
            }
        }

        private Patient patient;

        public Patient Patient
        {
            get { return patient; }
            set
            {
                if (value != patient)
                {
                    patient = value;
                    RaisePropertyChanged("Patient");
                }
            }
        }

        public ICommand AddPatientCommand { get; private set; }

        private void AddPatient(object obj)
        {
            UpdateCheckAmount();
            RaisePropertyChanged("CheckAmount");

            if (Settings.ReuseSamePatientEnabled)
            {
                GetNewPatientDependentOnUserPromptPreference();
            }

            else if (Settings.ReuseSamePatientEnabled == false)
            {
                Patient = new Patient();

            }
            RaisePropertyChanged("Patient");
            patientRepository.Add(Patient);
            RefreshAllCounters();
        }

        private void GetNewPatientDependentOnUserPromptPreference()
        {
            if (Settings.PatientPromptEnabled)
            {
                PromptTypeOfNewPatient();
            }

            else if (Settings.PatientPromptEnabled == false)
            {
                CloneLastPatient();
            }
        }

        private Patient PromptTypeOfNewPatient()
        {
            var newPatientDialogResult = 
                MessageBox.Show("Do you want to reuse this Patient?", "Return new patient", MessageBoxButton.YesNo);
            {
                
                if (newPatientDialogResult == MessageBoxResult.Yes)
                {
                    CloneLastPatient();
                    return Patient;
                }

                else 
                {
                    Patient = new Patient();
                    return patient;
                }
            }
        }

        private void CloneLastAddon()
        {
            AddonCharge clone =  (AddonCharge)Patient.Charge.AddonChargeList.Last().Clone();
            Addon = clone;
            RaisePropertyChanged("Addon");
        }

        private void GetNewAddonDependentOnUserPromptPreference()
        {
            if (Settings.AddonPromptEnabled)
            {
                PromptTypeOfNewAddon();
            }

            else if (Settings.AddonPromptEnabled == false)
            {
                CloneLastAddon();
            }
        }

        private void CloneLastPatient()
        {
            Patient = patientRepository.GetAllPatients().Last().CopyPatient();
            RaisePropertyChanged("Patient");
        }

        private AddonCharge PromptTypeOfNewAddon()
        {
            var newAddonDialogResult =
                MessageBox.Show("Do you want to reuse this Addon?", "Return new Addon", MessageBoxButton.YesNo);
            {

                if (newAddonDialogResult == MessageBoxResult.Yes)
                {
                    CloneLastAddon();

                }

                else
                {
                    Addon = new AddonCharge();
                }

                return Addon;
            }
        }

        
        private ObservableCollection<Patient> patientList;

        public ObservableCollection<Patient> PatientList
        {
            get { return patientList; }
            private set
            {
                patientList = value;
                RaisePropertyChanged("PatientList");
            }
        }

        private bool CanAddPatient(object obj)
        {
            if (!string.IsNullOrEmpty(Patient.FirstName) && !string.IsNullOrEmpty(patient.BillId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Adjustment adjustment;

        public Adjustment Adjustment
        {
            get { return adjustment; }
            set
            { if (value != adjustment) { adjustment = value; RaisePropertyChanged("Adjustment"); } }
        }

        private Adjustment addonAdjustment;

        public Adjustment AddonAdjustment
        {
            get { return addonAdjustment; }
            set
            { if (value != addonAdjustment) { addonAdjustment = value; RaisePropertyChanged("AddonAdjustment"); } }
        }

        public ICommand AddChargeAdjustmentCommand { get; private set; }

        public ICommand AddAddonChargeAdjustmentCommand { get; private set; }

        private void AddAddonAdjustment(object obj)
        {
            patient.Charge.AddonChargeList.Last().AdjustmentList.Add(AddonAdjustment);
            AddonAdjustment = new Adjustment();
            RaisePropertyChanged("Adjustment");
            RefreshAllCounters();
        }

        private void AddChargeAdjustment(object obj)
        {
            patient.Charge.AdjustmentList.Add(Adjustment);
            Adjustment = new Adjustment();
            RaisePropertyChanged("Adjustment");
        }

        private bool CheckIfAddonIsNull()
        {
            bool b = false;
            if (patient.Charge.AddonChargeList.Count > 0)
            {
                if (patient.Charge.AddonChargeList.Last() != null)
                {
                    b = true;
                }
            }
            return b;
        }

        private bool CanAddAddonAdjustment(object obj)
        {
            if (!string.IsNullOrEmpty(addonAdjustment.AdjustmentReasonCode)
                && !string.IsNullOrEmpty(addonAdjustment.AdjustmentType))
            {
                return CheckIfAddonIsNull();
            }
            else
            {
                return false;
            }
        }

        private bool CanAddAdjustment(object obj)
        {
            if (Adjustment.AdjustmentReasonCode != null && Adjustment.AdjustmentType != null)
            { return true; }
            else { return false; }
        }

        private AddonCharge addon;

        public AddonCharge Addon
        {
            get { return addon; }
            set { if (value != addon)
                { addon = value; RaisePropertyChanged("Addon"); } }
        }

        public ICommand AddAddonCommand { get; private set; }

        private void AddAddon(object obj)
        {
            patient.Charge.AddonChargeList.Add(addon);

            if (Settings.ReuseSameAddonEnabled)
            {
                GetNewAddonDependentOnUserPromptPreference();
            }

            else if (Settings.ReuseSameAddonEnabled == false)
            {
                Addon = new AddonCharge();

            }
            RaisePropertyChanged("Addon");
            UpdateCheckAmount();
            RaisePropertyChanged("CheckAmount");
            RefreshAllCounters();
        }

        private bool CanAddAddon(object obj)
        {
            if (!string.IsNullOrEmpty(Addon.ProcedureCode))
            { return true; }
            else { return false; }
        }

        public ICommand SaveFileCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void LoadCommands()
        {
            AddPatientCommand = new Command(AddPatient, CanAddPatient);
            AddChargeAdjustmentCommand = new Command(AddChargeAdjustment, CanAddAdjustment);
            AddAddonChargeAdjustmentCommand = new Command(AddAddonAdjustment, CanAddAddonAdjustment);
            AddAddonCommand = new Command(AddAddon, CanAddAddon);
            SaveFileCommand = new Command(Save, CanSave);
            UpdateRenderingProviderCommand = new Command(UpdateRenderingProvider);
        }

        public ICommand UpdateRenderingProviderCommand { get; private set; }

        private void UpdateRenderingProvider(object obj)
        {
            if(BillingProvider.IsAlsoRendering)
            {
                patient.Provider.FirstName = BillingProvider.FirstName;
                patient.Provider.LastName = BillingProvider.LastName;
                patient.Provider.Npi = BillingProvider.Npi;
                RaisePropertyChanged("Patient");
            }

            else if (billingProvider.IsAlsoRendering == false)
            {
                return;
            }
        }
        private bool CanSave(object obj)
        {
            return true;
        }

        private void SaveSettings()
        {
            Settings.SetDefaultBillingProvider(billingProvider);
            Settings.SetDefaultInsurance(insurance);
            Settings.SetDefaultPatient(patient);
        }

        private void Save(object obj)
        {
            SaveSettings();
            var edi = new ElectronicDataInterchange();

            var save = new SaveToFile();
            save.SaveFile(edi.BuildEdi(patientList.ToList(), insurance, billingProvider));
        }

        private void UpdateCheckAmount()
        {

            decimal chargepaid = 0;
            decimal calc = 0;
            foreach (Patient patient in patientRepository.GetAllPatients())
            {
                chargepaid += patient.Charge.PaymentAmount;
                calc += patient.Charge.AddonChargeList.Sum(a => a.PaymentAmount);
                insurance.CheckAmount = chargepaid + calc;
            }

        }

        public decimal PatientCount { get; private set;}

        private void RefreshAllCounters()
        {
            UpdatePatientCount();
            UpdateAddonCount();
            UpdateChargeAdjustmentCount();
            UpdateAddonAdjustmentCount();
        }

        private void UpdatePatientCount()
        {
            PatientCount = PatientList.Count();
            RaisePropertyChanged("PatientCount");
        }

        public decimal AddonChargeCount { get; private set; }

        private void UpdateAddonAdjustmentCount()
        {
            if (patient.Charge.AddonChargeList.Count == 0)
            {
                AddonChargeAdjustmentCount = 0;
            }

            else if (patient.Charge.AddonChargeList == null)
            {
                AddonChargeAdjustmentCount = 0;
            }

            else if (patient.Charge.AddonChargeList.Last().AdjustmentList == null)
            {
                AddonChargeAdjustmentCount = 0;
            }

            else
            {
                AddonChargeAdjustmentCount = patient.Charge.AddonChargeList.Last().AdjustmentList.Count();
                RaisePropertyChanged("AddonChargeAdjustmentCount");
            }
        }

        public int ChargeAdjustmentCount { get; private set; }

        private void UpdateChargeAdjustmentCount()
        {
            ChargeAdjustmentCount = Patient.Charge.AdjustmentList.Count();
            RaisePropertyChanged("ChargeAdjustmentCount");
        }

        public int AddonChargeAdjustmentCount { get; private set; }

        private void UpdateAddonCount()
        {
            AddonChargeCount = patient.Charge.AddonChargeList.Count;
            RaisePropertyChanged("AddonChargeCount");
        }


    }
}
