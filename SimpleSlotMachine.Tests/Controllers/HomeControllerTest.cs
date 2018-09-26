using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleSlotMachine;
using SimpleSlotMachine.UI.Controllers;
using SimpleSlotMachine.Repositories.Interfaces;
using SimpleSlotMachine.Models;
using SimpleSlotMachine.Repositories;

namespace SimpleSlotMachine.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private ISymbolRepository repository;

        [TestInitialize]
        public void Initalize()
        {
            this.repository = new SymbolRepository();
        }

        [TestMethod]
        public void ShouldReturnListOfRows()
        {
            // Get result rows from repository
            List<Row> rows = repository.GetResultRows();

            // Check if null
            Assert.IsNotNull(rows);

            // Check if count is 4
            Assert.IsTrue(rows.Count == 4);
        }

        [TestMethod]
        public void ShouldReturnTotalCoefficient()
        {
            // Create a list of rows with the default set of symbols
            List<Row> rows = new List<Row> { new Row(true), new Row(true), new Row(true), new Row(true) };

            // Pass the rows to the repository and get the total coefficient
            decimal coefficient = repository.CalculateTotal(rows);

            // Check if null
            Assert.IsNotNull(coefficient);

            // Check if coefficient is 0
            Assert.IsTrue(coefficient == 0);
        }


    }
}
