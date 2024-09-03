using System;
using System.Linq;
using AcceptanceTests.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace AcceptanceTests.StepDefinitions
{
    [Binding]
    public class FacebookStepDefinitions
    {
        [Given(@"I click on event in dataGrid")]
        public void GivenIClickOnEventInDataGrid()
        {
            var driver = GuiDriver.GetDriver();
            var dgvEvents = driver.FindElementByAccessibilityId("dgvEvents");
            var cell = dgvEvents.FindElementByName("Row 2");
            cell.Click();
        }

        [Given(@"I click details button")]
        public void GivenIClickDetailsButton()
        {
            var driver = GuiDriver.GetDriver();
            var btnEventDetails = driver.FindElementByAccessibilityId("btnEventDetails");
            btnEventDetails.Click();
        }

        [When(@"I should see form with details of event")]
        public void WhenIShouldSeeFormWithDetailsOfEvent()
        {
            var driver = GuiDriver.GetDriver();
            driver.SwitchTo().Window(driver.WindowHandles.FirstOrDefault());
            bool FrmEventDetails = driver.FindElementByAccessibilityId("FrmEventDetails") != null;
            Assert.IsTrue(FrmEventDetails);
        }


        [Given(@"I am at events managment user form")]
        public void GivenIAmAtEventsManagmentUserForm()
        {
            var driver = GuiDriver.GetDriver();
            driver.SwitchTo().Window(driver.WindowHandles.FirstOrDefault());
            bool FrmEventManagemenentUser = driver.FindElementByAccessibilityId("FrmEventManagemenentUser") != null;
            Assert.IsTrue(FrmEventManagemenentUser);

        }
        [Given(@"I click user details button")]
        public void GivenIClickUserDetailsButton()
        {
            var driver = GuiDriver.GetDriver();
            var btnDetails = driver.FindElementByAccessibilityId("btnDetails");
            btnDetails.Click();
        }

        [When(@"I should see users form with details of event")]
        public void WhenIShouldSeeUsersFormWithDetailsOfEvent()
        {
            var driver = GuiDriver.GetDriver();
            driver.SwitchTo().Window(driver.WindowHandles.FirstOrDefault());
            bool FrmEventDetailsUser = driver.FindElementByAccessibilityId("FrmEventDetailsUser") != null;
            Assert.IsTrue(FrmEventDetailsUser);
        }

        [Then(@"I should not see button to share to Facebook")]
        public void ThenIShouldNotSeeButtonToShareToFacebook()
        {
            var driver = GuiDriver.GetDriver();
            bool btnShare = driver.FindElementsByAccessibilityId("btnShare").Count() == 0;
            Assert.IsTrue(btnShare);
        }



        [Then(@"I should see button to share to Facebook")]
        public void ThenIShouldSeeButtonToShareToFacebook()
        {
            var driver = GuiDriver.GetDriver();
            bool btnShare = driver.FindElementByAccessibilityId("btnShare") != null;
            Assert.IsTrue(btnShare);
        }
    }
}
