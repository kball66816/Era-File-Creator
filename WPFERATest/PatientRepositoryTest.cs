﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WPFERA.Services;
using EFC.BL;
using System.Linq;

namespace WPFERATest
{
    [TestClass]
    public class PatientRepositoryTest
    {
        [TestMethod]
        public void AddTest()
        {
            //Arrange
            PatientRepository Pr = new PatientRepository();

            //Act
            var patient = new Patient();
            patient.FirstName = "John";
            Pr.Add(patient);

            var expected = "John";
            var actual = Pr.GetAllPatients().Last().FirstName;
            //Assert
            Assert.AreEqual(expected, actual);


        }

        [TestMethod]
        public void DeleteTest()
        {
            //Arrange
            PatientRepository Pr = new PatientRepository();

            //Act
            var patient = new Patient();
            patient.FirstName = "John";
            Pr.Add(patient);
            Pr.Delete(patient);

            var expected = 0;
            var actual = Pr.GetAllPatients().Count;
            //Assert
            Assert.AreEqual(expected,actual);

        }
    }
}
