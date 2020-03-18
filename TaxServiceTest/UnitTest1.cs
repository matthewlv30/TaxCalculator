using System;
using NUnit.Framework;
using TaxServiceProject;

namespace TaxServiceTest
{
    public class Tests
    {
        string token;
        [SetUp]
        public void Setup()
        {
            token = ""; //TO BE Filled IN BY TESTER
        }

        [Test]
        public void GetRateLocation_ValidRequest()
        {
            TaxService taxService = new TaxService(new TaxJarClient(token));

            var result = taxService.GetTaxRateLocation("90404-3370");

            Assert.That(!String.IsNullOrEmpty(result));

            Assert.That(result.Length > 0);
        }

        [Test]
        public void GetRateLocationWithParams_ValidRequest()
        {
            TaxService taxService = new TaxService(new TaxJarClient(token));

            var result = taxService.GetTaxRateLocation("05495-2086", new
            {
                street = "312 Hurricane Lane",
                city = "Williston",
                state = "VT",
                country = "US"
            });

            Assert.That(!String.IsNullOrEmpty(result));

            Assert.That(result.Length > 0);
        }


        [Test]
        public void GetRateLocation_InvalidRequest()
        {
            TaxService taxService = new TaxService(new TaxJarClient(token));

            var result = taxService.GetTaxRateLocation("05");

            Assert.That(result.Contains("error"));
        }



        [Test]
        public void CalculateTaxOrder_ValidRequest()
        {
            TaxService taxService = new TaxService(new TaxJarClient(token));

            var result = taxService.CalculateTaxOrder(new
            {
                from_country = "US",
                from_zip = "92093",
                from_state = "CA",
                from_city = "La Jolla",
                from_street = "9500 Gilman Drive",
                to_country = "US",
                to_zip = "90002",
                to_state = "CA",
                to_city = "Los Angeles",
                to_street = "1335 E 103rd St",
                amount = 15,
                shipping = 1.5,
                nexus_addresses = new[] {
                    new {
                      id = "Main Location",
                      country = "US",
                      zip = "92093",
                      state = "CA",
                      city = "La Jolla",
                      street = "9500 Gilman Drive",
                    }
                  },
                line_items = new[] {
                    new {
                      id = "1",
                      quantity = 1,
                      product_tax_code = "20010",
                      unit_price = 15,
                      discount = 0
                    }
                  }
            });

            Assert.That(!String.IsNullOrEmpty(result));

            Assert.That(result.Length > 0);
        }
    }
}