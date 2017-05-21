﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EFC.BL;
using Common.Common;

namespace EFC.BLTests
{
    [TestClass]
    public class NpiValidatorTest
    {
        [TestMethod]
        public void ValidProviderNpi()
        {
            var provider = new RenderingProvider
            {
                FirstName = "John",
                LastName = "Smith",
                Npi = "1234567893"
            };

            var npiValidator = new NpivalidationRule();
            var expected = false;
            npiValidator.ParseNpi(provider.Npi);
            var actual = npiValidator.InvalidNPI;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void InvalidProviderNpi()
        {
            var provider = new RenderingProvider
            {
            };

            try
            {
                provider.Npi = "12345678";
            }
            catch (ArgumentException)
            {
                string npi = "1234567893";
                provider.Npi = npi;
                var expected = "1234567893";
                var actual = npi;
                Assert.AreEqual(actual, expected);
            }

        }
        [TestMethod]
        public void ShortProviderNpi()
        {
            var provider = new RenderingProvider
            {
            };
            try
            {
                provider.Npi = "12345678";
            }
            catch (ArgumentException)
            {
                string npi = "1234567893";
                provider.Npi = npi;
                var expected = "1234567893";
                var actual = npi;
                Assert.AreEqual(actual, expected);
            }

        }
    }
}
