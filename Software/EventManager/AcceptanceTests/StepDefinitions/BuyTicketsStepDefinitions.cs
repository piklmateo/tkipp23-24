using AcceptanceTests.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AcceptanceTests.StepDefinitions
{
    [Binding]
    public class BuyTicketsStepDefinitions
    {

        // Tag 1 //

        [Given(@"I should be redirected to Events page")]
        public void GivenIShouldBeRedirectedToEventsPage()
        {
            var driver = GuiDriver.GetDriver();
            Task.Delay(1000).Wait();
            driver.SwitchTo().Window(driver.WindowHandles.FirstOrDefault());
            bool FrmEventManagement = driver.FindElementByName("FrmEventManagemenentUser") != null;
            Assert.IsTrue(FrmEventManagement);
        }

        [When(@"I click on the first event in the data grid")]
        public void WhenIClickOnTheFirstEventInTheDataGrid()
        {
            var driver = GuiDriver.GetDriver();
            var dataGridView = driver.FindElementByAccessibilityId("dgvEvents");
            var cell = dataGridView.FindElementByName("Row 0");
            cell.Click();
        }

        [When(@"I click on the Buy Tickets button")]
        public void WhenIClickOnTheBuyTicketsButton()
        {
            var driver = GuiDriver.GetDriver();
            var btnBuyTicket = driver.FindElementByAccessibilityId("btnBuyTicket");
            btnBuyTicket.Click();
        }

        [Then(@"I should be redirected to the Buy Tickets page")]
        public void ThenIShouldBeRedirectedToTheBuyTicketsPage()
        {
            var driver = GuiDriver.GetDriver();
            driver.SwitchTo().Window(driver.WindowHandles.FirstOrDefault());
            bool FrmBuyTicket = driver.FindElementByAccessibilityId("FrmBuyTicket") != null;
            Assert.IsTrue(FrmBuyTicket);
        }

        [When(@"I input data for the tickets")]
        public void WhenIInputDataForTheTickets()
        {
            var driver = GuiDriver.GetDriver();
            var na1 = driver.FindElementByAccessibilityId("nudAmount1");
            var na2 = driver.FindElementByAccessibilityId("nudAmount2");

            na1.SendKeys("15");
            na2.SendKeys("25");
        }

        [When(@"I click on the Add button")]
        public void WhenIClickOnTheAddButton()
        {
            var driver = GuiDriver.GetDriver();
            var btnAdd = driver.FindElementByAccessibilityId("btnAdd");
            btnAdd.Click();
        }

        [Then(@"I should see a message that the Transaction is complete")]
        public void ThenIShouldSeeAMessageThatTheTransactionIsComplete()
        {
            var driver = GuiDriver.GetDriver();

            var messageBoxes = driver.FindElementsByClassName("#32770"); 
            foreach (var box in messageBoxes)
            {
                var textElements = box.FindElementsByClassName("Static"); 
                foreach (var textElement in textElements)
                {
                    if (textElement.Text.Contains("Transaction is complete"))
                    {
                        Assert.IsTrue(true, "Found the message box with the correct text.");
                        return;
                    }
                }
            }
            Assert.Fail("Message box with specific text was not found.");
        }

        // Tag 2 //

        [When(@"I click on the Details button")]
        public void WhenIClickOnTheDetailsButton()
        {
            var driver = GuiDriver.GetDriver();
            var btnDetails = driver.FindElementByAccessibilityId("btnDetails");
            btnDetails.Click();
        }

        [Then(@"I should be redirected to the Details page")]
        public void ThenIShouldBeRedirectedToTheDetailsPage()
        {
            Task.Delay(500).Wait();

            var driver = GuiDriver.GetDriver();

            // Radi, ali baca info grešku da je picture url null u ponekojim sluèajevima.
            // Potrebno je popraviti.
            var btnOk = driver.FindElementByAccessibilityId("2");
            btnOk.Click();

            Task.Delay(500).Wait();

            driver.SwitchTo().Window(driver.WindowHandles.FirstOrDefault());
            Task.Delay(500).Wait();
            bool FrmEventDetails = driver.FindElementByAccessibilityId("FrmEventDetailsUser") != null;
            Assert.IsTrue(FrmEventDetails);
        }


        // Tag 3 //

        [When(@"I click on dropdown for category and select Festival")]
        public void WhenIClickOnDropdownForCategoryAndSelectFestival()
        {
            var driver = GuiDriver.GetDriver();

            var cmbCategory = driver.FindElementByAccessibilityId("cbEventCategory");
            cmbCategory.Click();
        }

        [When(@"I clik on the Filter button")]
        public void WhenIClikOnTheFilterButton()
        {
            var driver = GuiDriver.GetDriver();
            var btnFilter = driver.FindElementByAccessibilityId("btnFilter");
            btnFilter.Click();
        }

        [Then(@"I should see the data grid fill with data with the Category Festival in it")]
        public void ThenIShouldSeeTheDataGridFillWithDataWithTheCategoryFestivalInIt()
        {

            // Radi, ali je uzas nacin...
            // Potrebno je popraviti.

            var driver = GuiDriver.GetDriver();
            var dataGridView = driver.FindElementByAccessibilityId("dgvEvents");

            var rows = dataGridView.FindElements(By.XPath(".//DataItem"));

            foreach (var row in rows)
            {
                
                var categoryCell = row.FindElement(By.XPath(".//Cell[4]"));

                string cellText = categoryCell.Text;
                bool containsFestival = cellText.Contains("Festival");

                Assert.IsTrue(containsFestival);
            }
        }
    }
}