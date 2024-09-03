using AcceptanceTests.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace AcceptanceTests.StepDefinitions
{
    [Binding]
    public class EventsStepDefinitions
    {
        [Given(@"I click the Login button")]
        public void WhenIClickTheLoginButton()
        {
            var driver = GuiDriver.GetDriver();
            var btnLogin = driver.FindElementByAccessibilityId("btnSignIn");
            btnLogin.Click();
        }

        [Given(@"I click button ok")]
        public void GivenIClickButtonOk()
        {
            var driver = GuiDriver.GetDriver();
            var btnOk = driver.FindElementByAccessibilityId("2");
            btnOk.Click();
        }

        [Given(@"I click event")]
        public void GivenIClickEvent()
        {
            var driver = GuiDriver.GetDriver();
            var btnEvents = driver.FindElementByAccessibilityId("btnEvents");
            btnEvents.Click();
        }

        [Given(@"I am redirected to event page")]
        public void GivenIAmRedirectedToEventPage()
        {
            var driver = GuiDriver.GetDriver();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            bool FrmEvents = driver.FindElementByAccessibilityId("FrmEventManagement") != null;
            Assert.IsTrue(FrmEvents);
        }

        [Given(@"I click add event button")]
        public void GivenIClickAddEventButton()
        {
            var driver = GuiDriver.GetDriver();
            var btnAddEvent = driver.FindElementByAccessibilityId("btnAdd");
            btnAddEvent.Click();
        }

        [Given(@"I am redirected to add event page")]
        public void GivenIAmRedirectedToAddEventPage()
        {
            var driver = GuiDriver.GetDriver();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            bool FrmAddEvent = driver.FindElementByAccessibilityId("FrmAddEvent") != null;
            Assert.IsTrue(FrmAddEvent);
        }

        [Given(@"i enter event name (.*)")]
        public void GivenIEnterEventNameTest(string name)
        {
            var driver = GuiDriver.GetDriver();
            var txtEventName = driver.FindElementByAccessibilityId("txtEventName");
            txtEventName.SendKeys(name);
        }

        [Given(@"I click button add")]
        public void GivenIClickButtonAdd()
        {
            var driver = GuiDriver.GetDriver();
            var btnAdd = driver.FindElementByAccessibilityId("btnAdd");
            btnAdd.Click();
        }

        [Given(@"I should remain on add event page")]
        public void GivenIShouldRemainOnAddEventPage()
        {
            var driver = GuiDriver.GetDriver();
            bool FrmAddEvent = driver.FindElementByAccessibilityId("FrmAddEvent") != null;
            Assert.IsTrue(FrmAddEvent);
        }

        [Then(@"I am redirected to event page")]
        public void ThenIAmRedirectedToEventPage()
        {
            var driver = GuiDriver.GetDriver();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            bool FrmEvents = driver.FindElementByAccessibilityId("FrmEventManagement") != null;
            Assert.IsTrue(FrmEvents);
        }


        [Given(@"i leave event name field blank")]
        public void GivenILeaveEventNameFieldBlank()
        {
            var driver = GuiDriver.GetDriver();
            var txtEventName = driver.FindElementByAccessibilityId("txtEventName");
            txtEventName.SendKeys("");
        }

        [Then(@"I should remain on add event page")]
        public void ThenIShouldRemainOnAddEventPage()
        {
            var driver = GuiDriver.GetDriver();
            bool FrmAddEvent = driver.FindElementByAccessibilityId("FrmAddEvent") != null;
            Assert.IsTrue(FrmAddEvent);
        }

        

        [Then(@"I enter past date")]
        public void ThenIEnterPastDate()
        {
            var driver = GuiDriver.GetDriver();
            var dtpEventDate = driver.FindElementByAccessibilityId("dtpEventDate");

            DateTime today = DateTime.Today;
            DateTime pastDate = today.AddDays(-1);

            int pastDay = pastDate.Day;
            string value = pastDay.ToString();

            dtpEventDate.SendKeys(value);
        }

        [Given(@"I select event with name test188 from the datagridview")]
        public void GivenISelectTheFourthRowFromTheDatagridview()
        {
            var driver = GuiDriver.GetDriver();
            var rows = driver.FindElementByAccessibilityId("421032124");
            rows.Click();
        }

        [Given(@"I click button delete")]
        public void GivenIClickButtonDelete()
        {
            var driver = GuiDriver.GetDriver();
            var btnDelete = driver.FindElementByAccessibilityId("btnDelete");
            btnDelete.Click();
        }
    }
}
