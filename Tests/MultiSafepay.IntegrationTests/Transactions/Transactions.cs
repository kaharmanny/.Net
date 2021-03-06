﻿using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MultiSafepay.IntegrationTests.Transactions
{
    [TestClass]
    public class Transactions
    {
        [TestMethod]
        public void Transactions_RetrieveTransaction()
        {
            // Arrange
            var url = ConfigurationManager.AppSettings["MultiSafepayAPI"];
            var apiKey = ConfigurationManager.AppSettings["MultiSafepayAPIKey"];
            var client = new MultiSafepayClient(apiKey, url);

            // Act
            const string transactionId = "2242232";
            var result = client.GetTransaction(transactionId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(transactionId, result.TransactionId);
        }

        [TestMethod]
        public void Transactions_CreateARefund()
        {
            // Arrange
            var url = ConfigurationManager.AppSettings["MultiSafepayAPI"];
            var apiKey = ConfigurationManager.AppSettings["MultiSafepayAPIKey"];
            var client = new MultiSafepayClient(apiKey, url);

            // Act
            var result = client.CreateRefund("546dd9aeb49aa", 100, "EUR", "This is a refund");

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(String.IsNullOrEmpty(result.TransactionId));
        }
    }
}
