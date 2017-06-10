﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using WPFERA.ViewModel;
using EFC.BL;
using System.Linq;

namespace WPFERATest
{
    [TestClass]
    public class PatientViewModelTest
    {
        [TestMethod]
        public void SaveCommandTest()
        {
            //Arrange
            var Pvm = new PatientViewModel();

            //Act
            Pvm.SaveFileCommand.Execute(true);

           //Assert
           //Test passes. File Command Opens
        }

        [TestMethod]
        public void AddAddonCommandTest()
        {
            //Arrange
            var Pvm = new PatientViewModel();
            var Preference = new Preference();
            Preference.EnableAddonReusePrompt = false;
            Pvm.Addon.ChargeCost = 100;
                
            //Act
            Pvm.AddAddonCommand.Execute(true);
            var expected = 100;
            var actual = Pvm.Charge.AddonChargeList.Last().ChargeCost;
            //Assert

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddPatientCommandTest()
        {
            //Arrange
            
            var Pvm = new PatientViewModel();

            Pvm.Patient.FirstName = "Chuck";

            //Act
            Pvm.AddPatientCommand.Execute(true);
            var expected = "Chuck";
            var actual = Pvm.patientRepository.GetAllPatients().Last().FirstName;
            //Assert

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddChargeAdjustmentCommandTest()
        {
            //Arrange
            var Pvm = new PatientViewModel();

            Pvm.Adjustment.AdjustmentAmount = 100;

            //Act
            Pvm.AddChargeAdjustmentCommand.Execute(true);
            var expected = 100;
            var actual = Pvm.Charge.AdjustmentList.Last().AdjustmentAmount;
            //Assert

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddAddonChargeAdjustmentCommandTest()
        {
            //Arrange
            var pvm = new PatientViewModel();
            var preference = new Preference();
            preference.EnableAddonReusePrompt = false;
            pvm.AddonAdjustment.AdjustmentAmount = 100;

            //Act
            pvm.AddAddonCommand.Execute(true);
            pvm.AddAddonChargeAdjustmentCommand.Execute(true);
            var expected = 100;
            var actual = pvm.Charge.AddonChargeList.Last().AdjustmentList.Last().AdjustmentAmount;
            //Assert

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UpdateRenderingProviderCommandIsAlsoRenderingTrueTest()
        {
            //Arrange
            var Pvm = new PatientViewModel();

            Pvm.BillingProvider.FirstName = "John";
            Pvm.BillingProvider.IsAlsoRendering = true;
            //Act
            Pvm.UpdateRenderingProviderCommand.Execute(true);
            
            var expected = "John";
            var actual = Pvm.Patient.Provider.FirstName;
            //Assert

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UpdateRenderingProviderCommandIsAlsoRenderingFalseTest()
        {
            //Arrange
            var Pvm = new PatientViewModel();

            Pvm.BillingProvider.FirstName = "John";
            Pvm.BillingProvider.IsAlsoRendering = false;
            //Act
            Pvm.UpdateRenderingProviderCommand.Execute(true);

            string expected = null;
            var actual = Pvm.Patient.Provider.FirstName;
            //Assert

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddChargeToPatientTest()
        {
            //Arrange
            var Pvm = new PatientViewModel();

            Pvm.Patient.FirstName = "John";
            Pvm.Patient.LastName = "Smith";

            Pvm.Charge.ProcedureCode = "99215";
            Pvm.Charge.PlaceOfService.ServiceLocation = "11";
            //Act

            Charge chargeTest = Pvm.Charge;
            Patient patientTest = Pvm.Patient;
            Pvm.AddPatientCommand.Execute(true);

            var expected = chargeTest.Id;
            var actual = patientTest.Charge.Id;
            //Assert

            Assert.AreEqual(expected, actual);
        }
    }
}
