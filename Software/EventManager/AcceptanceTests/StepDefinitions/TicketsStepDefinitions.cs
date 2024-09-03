using AcceptanceTests.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Diagnostics;
using System.Linq;
using TechTalk.SpecFlow;

namespace AcceptanceTests.StepDefinitions
{
    [Binding]
    public class TicketsStepDefinitions
    {
        [Given(@"I click ticket")]
        public void GivenIClickTicket()
        {
            var driver = GuiDriver.GetDriver();
            var btnTickets = driver.FindElementByAccessibilityId("btnTickets");
            btnTickets.Click();
        }

        [Given(@"I am redirected to ticket page")]
        public void GivenIAmRedirectedToTicketPage()
        {
            var driver = GuiDriver.GetDriver();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            bool FrmTickets = driver.FindElementByAccessibilityId("FrmTickets") != null;
            Assert.IsTrue(FrmTickets);
        }

        [Given(@"I click update button")]
        public void GivenIClickUpdateButton()
        {
            var driver = GuiDriver.GetDriver();
            var btnUpdate = driver.FindElementByAccessibilityId("btnUpdate");
            btnUpdate.Click();
        }

        [Given(@"I am redirected to edit ticket page")]
        public void GivenIAmRedirectedToEditTicketPage()
        {
            var driver = GuiDriver.GetDriver();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            bool FrmUpdateTicket = driver.FindElementByAccessibilityId("FrmUpdateTicket") != null;
            Assert.IsTrue(FrmUpdateTicket);
        }

        [Given(@"I leave event empty and enter price (.*) amount (.*)")]
        public void GivenILeaveEventEmptyAndEnterPriceAmount(string price, string amount)
        {
            var driver = GuiDriver.GetDriver();
            var cbEvent = driver.FindElementByAccessibilityId("1001");

            cbEvent.Click();
            cbEvent.SendKeys(Keys.Backspace);

            var txtPrice = driver.FindElementByAccessibilityId("txtPrice");
            var txtAmount = driver.FindElementByAccessibilityId("txtAmount");
            txtPrice.SendKeys(price);
            txtAmount.SendKeys(amount);
        }

        [Given(@"I should remain on edit ticket page")]
        public void GivenIShouldRemainOnEditTicketPage()
        {
            var driver = GuiDriver.GetDriver();
            bool FrmUpdateTicket = driver.FindElementByAccessibilityId("FrmUpdateTicket") != null;
            Assert.IsTrue(FrmUpdateTicket);
        }


        [Then(@"I should see MessageBox with message (.*)")]
        public void ThenIShouldSeeMessageBoxWithMessageEventNijeOdabranIliJeNeispravan_(string expectedMessage)
        {
            var driver = GuiDriver.GetDriver();
            var message = driver.FindElementByAccessibilityId("65535");
            bool correctMessage = message.Text == expectedMessage;
            Assert.IsTrue(correctMessage);
            var btnOk = driver.FindElementByAccessibilityId("2");
            btnOk.Click();
        }

        [Given(@"I enter price (.*) and amount (.*)")]
        public void GivenIEnterPriceAAndAmount(string price, string amount)
        {
            var driver = GuiDriver.GetDriver();

            var txtPrice = driver.FindElementByAccessibilityId("txtPrice");
            var txtAmount = driver.FindElementByAccessibilityId("txtAmount");
            txtPrice.SendKeys(price);
            txtAmount.SendKeys(amount);
        }
    }
}
