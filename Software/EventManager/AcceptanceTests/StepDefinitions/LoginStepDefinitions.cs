using AcceptanceTests.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace AcceptanceTests.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        [Given(@"I ensure that the login form is displayed")]
        public void GivenIEnsureThatTheLoginFormIsDisplayed()
        {
            var driver = GuiDriver.GetOrCreateDriver();
            bool isFormOpened = driver.FindElementByAccessibilityId("FrmLogin") != null;
            Assert.IsTrue(isFormOpened);
        }

        [When(@"I click the Login button")]
        public void WhenIClickTheLoginButton()
        {
            var driver = GuiDriver.GetDriver();
            var btnLogin = driver.FindElementByAccessibilityId("btnSignIn");
            btnLogin.Click();
        }

        [Then(@"I expect to remain on the login form")]
        public void ThenIExpectToRemainOnTheLoginForm()
        {
            var driver = GuiDriver.GetDriver();
            bool isFormOpened = driver.FindElementByAccessibilityId("FrmLogin") != null;
            Assert.IsTrue(isFormOpened);
        }

        [When(@"I enter the username (.*) and the password (.*)")]
        public void WhenIEnterTheUsernameAndThePassword(string username, string password)
        {
            var driver = GuiDriver.GetDriver();
            var txtUsername = driver.FindElementByAccessibilityId("txtUsername");
            var txtPassword = driver.FindElementByAccessibilityId("txtPassword");

            txtUsername.SendKeys(username);
            txtPassword.SendKeys(password);
        }

        [When(@"I enter the password (.*) without the username")]
        public void WhenIEnterThePassword123123WithoutTheUsername(string password)
        {
            var driver = GuiDriver.GetDriver();
            var txtUsername = driver.FindElementByAccessibilityId("txtUsername");
            var txtPassword = driver.FindElementByAccessibilityId("txtPassword");

            txtUsername.SendKeys("");
            txtPassword.SendKeys(password);
        }
        

        [When(@"I enter the username (.*) without the password")]
        public void WhenIEnterTheUsernameKorisnik2WithoutThePassword(string username)
        {
            var driver = GuiDriver.GetDriver();
            var txtUsername = driver.FindElementByAccessibilityId("txtUsername");
            var txtPassword = driver.FindElementByAccessibilityId("txtPassword");

            txtUsername.SendKeys(username);
            txtPassword.SendKeys("");
        }
    }
}
