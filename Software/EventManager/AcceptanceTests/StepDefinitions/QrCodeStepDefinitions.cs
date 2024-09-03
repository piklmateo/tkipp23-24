using System;
using System.Linq;
using AcceptanceTests.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace AcceptanceTests.StepDefinitions
{
    [Binding]
    public class QrCodeStepDefinitions
    {
        [Given(@"I launch the application")]
        public void WhenILaunchTheApplication()
        {
            var driver = GuiDriver.GetOrCreateDriver();
        }

        [Given(@"I should see the login form")]
        public void ThenIShouldSeeTheLoginForm()
        {
            var driver = GuiDriver.GetDriver();
            bool isFormOpened = driver.FindElementByAccessibilityId("FrmLogin") != null;
            Assert.IsTrue(isFormOpened);
        }

        [Given(@"I am on the login form")]
        public void GivenIAmOnTheLoginForm()
        {
            var driver = GuiDriver.GetOrCreateDriver();
        }

        [Given(@"I enter username (.*) and password (.*)")]
        public void WhenIEnterUsernameKorisnikAndPassword(string username, string password)
        {
            var driver = GuiDriver.GetDriver();
            var txtUsername = driver.FindElementByAccessibilityId("txtUsername");
            var txtPassword = driver.FindElementByAccessibilityId("txtPassword");

            txtUsername.SendKeys(username);
            txtPassword.SendKeys(password);
        }

        [Given(@"I click on the Login button")]
        public void WhenIClickOnTheLoginButton()
        {
            var driver = GuiDriver.GetDriver();
            var btnLogin = driver.FindElementByAccessibilityId("btnSignIn");
            btnLogin.Click();
        }

        [Given(@"I click ok")]
        public void WhenIClickOk()
        {
            var driver = GuiDriver.GetDriver();
            var btnOk = driver.FindElementByAccessibilityId("2");
            btnOk.Click();
        }


        [Given(@"I should be redirected to Home moderator page")]
        public void ThenIShouldBeRedirectedToHomeModeratorPage()
        {
            var driver = GuiDriver.GetDriver();
            driver.SwitchTo().Window(driver.WindowHandles.First());
            bool MainForm = driver.FindElementByAccessibilityId("MainForm") != null;
            Assert.IsTrue(MainForm);
        }

        [Given(@"I click profile")]
        public void WhenIClickProfile()
        {
            var driver = GuiDriver.GetDriver();
            var btnProfile = driver.FindElementByAccessibilityId("btnProfile");
            btnProfile.Click();
        }

        [Given(@"I should be redirected to profile page")]
        public void ThenIShouldBeRedirectedToProfilePage()
        {
            var driver = GuiDriver.GetDriver();
            driver.SwitchTo().Window(driver.WindowHandles.First());
            bool FrmProfile = driver.FindElementByAccessibilityId("FrmProfile") != null;
            Assert.IsTrue(FrmProfile);
        }

        [Given(@"I click on my events button")]
        public void WhenIClickOnMyEventsButton()
        {
            var driver = GuiDriver.GetDriver();
            var btnEvents = driver.FindElementByAccessibilityId("btnEvents");
            btnEvents.Click();
        }

        [Given(@"I should see the My events page")]
        public void ThenIShouldSeeTheMyEventsPage()
        {
            var driver = GuiDriver.GetDriver();
            driver.SwitchTo().Window(driver.WindowHandles.First());
            bool FrmUserEvents = driver.FindElementByAccessibilityId("FrmUserEvents") != null;
            Assert.IsTrue(FrmUserEvents);
        }

        [Given(@"I click item on dataGrid")]
        public void WhenIClickItemOnDataGrid()
        {
            var driver = GuiDriver.GetDriver();
            var dataGridView = driver.FindElementByAccessibilityId("dgvUserEvents");
            var cell = dataGridView.FindElementByName("Row 1");
            cell.Click();
        }

        [Given(@"I click Show details of event button")]
        public void WhenIClickShowDetailsOfEventButton()
        {
            var driver = GuiDriver.GetDriver();
            var btnSelectedEvent = driver.FindElementByAccessibilityId("btnSelectedEvent");
            btnSelectedEvent.Click();
        }


        [When(@"I should be redirected to FrmEvent page")]
        public void ThenIShouldBeRedirectedToFrmEventPage()
        {
            var driver = GuiDriver.GetDriver();
            driver.SwitchTo().Window(driver.WindowHandles.First());
            bool FrmEvent = driver.FindElementByAccessibilityId("FrmEvent") != null;
            Assert.IsTrue(FrmEvent);
        }

        [Then(@"I should see QrCode with picture")]
        public void ThenIShouldSeeQrCodeWithPicture()
        {
            var driver = GuiDriver.GetDriver();
            bool picQr = driver.FindElementByAccessibilityId("picQr") != null;
            Assert.IsTrue(picQr);
        }


        [Given(@"I click events button")]
        public void GivenIClickEventsButton()
        {
            var driver = GuiDriver.GetDriver();
            var btnEvents = driver.FindElementByAccessibilityId("btnEvents");
            btnEvents.Click();
        }

        [Given(@"I am at events managment form")]
        public void GivenIAmAtEventsManagmentForm()
        {
            var driver = GuiDriver.GetDriver();
            driver.SwitchTo().Window(driver.WindowHandles.First());
            bool FrmEventManagement = driver.FindElementByAccessibilityId("FrmEventManagement") != null;
            Assert.IsTrue(FrmEventManagement);
        }

        [When(@"I click check tickets")]
        public void WhenIClickCheckTickets()
        {
            var driver = GuiDriver.GetDriver();
            var btnEventCheck = driver.FindElementByAccessibilityId("btnEventCheck");
            btnEventCheck.Click();
        }

        [Then(@"I should see form with users that bought tickets for that event")]
        public void ThenIShouldSeeFormWithUsersThatBoughtTicketsForThatEvent()
        {
            var driver = GuiDriver.GetDriver();
            driver.SwitchTo().Window(driver.WindowHandles.First());
            bool FrmEventCheck = driver.FindElementByAccessibilityId("FrmEventCheck") != null;
            Assert.IsTrue(FrmEventCheck);
        }


        [Given(@"I should be redirected to Home page")]
        public void ThenIShouldBeRedirectedToHomePage()
        {
            var driver = GuiDriver.GetDriver();
            driver.SwitchTo().Window(driver.WindowHandles.First());
            bool MainFormUser = driver.FindElementByAccessibilityId("MainFormUser") != null;
            Assert.IsTrue(MainFormUser);
        }

        [Then(@"I should see the error (.*)")]
        public void ThenIShouldSeeTheErrorThatNoEventsWereSelected(string expectedMessage)
        {
            var driver = GuiDriver.GetDriver();
            var lblErrorMessage = driver.FindElementByAccessibilityId("65535");
            var actualMessage = lblErrorMessage.Text;
            Assert.AreEqual(actualMessage, expectedMessage);
        }

        [AfterScenario]
        public void CloseApplication()
        {
            GuiDriver.Dispose();
        }
    }
}
