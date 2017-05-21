using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EFC.BL;
using System.Collections.Generic;
using System.Linq;

namespace PatientTest
{
    [TestClass]
    public class PatientTest
    {
        [TestMethod]
        public void PatientWithPlatformId()
        {
            //arrange
            var patient = new Patient
            {
                UsePlatformId = true,
                FirstName = "John",
                LastName = "Smith",
                BillId = "100",
            };


            //act
            string actual = "100-1";
            string expected = patient.FormattedBillId;
            //assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void PatientWithClassicId()
        {
            //arrange
            var patient = new Patient
            {
                UsePlatformId = false,
                FirstName = "John",
                LastName = "Smith",
                BillId = "100",
            };


            //act
            string actual = "10000000100SMIJOH";
            //assert
            Assert.AreEqual(actual, patient.FormattedBillId);
        }
        [TestMethod]
        public void PatientWithConcatenatedNameIfMoreThanThreeCharactersInFirstAndLastName()
        {
            //arrange
            var patient = new Patient()
            {
                UsePlatformId = false,
                FirstName = "John",
                LastName = "Smith",
                BillId = "100",
            };


            //act
            string actual = "10000000100SMIJOH";
            //assert
            Assert.AreEqual(actual, patient.FormattedBillId);

        }
        [TestMethod]
        public void PatientWithConcatenatedNameIfLessThanThreeCharactersInFirstAndLastName()
        {
            //arrange
            var patient = new Patient
            {
                UsePlatformId = false,
                FirstName = "Ha",
                LastName = "Vo",
                BillId = "100",
            };


            //act
            string actual = "10000000100VOHA";
            //assert
            Assert.AreEqual(actual, patient.FormattedBillId);

        }

        [TestMethod]
        public void ReturnPatientList()
        {
            //arrange
            string expected = "1";
            var patient = new Patient()
            {
                UsePlatformId = true,
                FirstName = "Ha",
                LastName = "Vo",
                BillId = "100",
            };
            var charge = new Charge
            {
               
                PaymentAmount = 50
            };
            patient.Charge = charge;

            //act
            var retrievePatients = new RetrievePatients();
            retrievePatients.AddPatient(patient);
            var actual = retrievePatients.CountPatients;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CopyPatient()
        {
            //arrange
            var patient = new Patient()
            {
                UsePlatformId = true,
                FirstName = "Ha",
                LastName = "Vo",
                BillId = "100",
            };

            var patient2 = patient.CopyPatient();
            //act
            patient2.BillId = "105";
            var actual = patient.BillId;
            var expected = "105";

            //assert
            Assert.AreNotEqual(expected, actual);
        }
    }
}
