using AcceptanceTests.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace AcceptanceTests.StepDefinitions
{
    [Binding]
    public class RegistrationStepDefinitions
    {
        

        [Given(@"I click on label Don't have an account\? Sign up")]
        public void GivenIClickOnLabelDontHaveAnAccountSignUp()
        {
            var driver = GuiDriver.GetDriver();
            var lblRegister = driver.FindElementByAccessibilityId("lblSwitchRegistration");
            lblRegister.Click();
        }

        [Given(@"I should be redirected to registration page")]
        public void GivenIShouldBeRedirectedToRegistrationPage()
        {
            var driver = GuiDriver.GetDriver();
            Task.Delay(2000).Wait();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            bool FrmRegistration = driver.FindElementByName("FrmRegistration") != null;
            Assert.IsTrue(FrmRegistration);
        }

        [Given(@"I enter name (.*) surname (.*) address (.*) phone (.*) username (.*) password (.*)")]
        public void GivenIEnterNameTestATSurnameTestATAddressTestATPhoneUsernameKorisnikPassword(string name, string surname, string address, string phone, string username, string password)
        {
            var driver = GuiDriver.GetDriver();
            var txtName = driver.FindElementByAccessibilityId("txtName");
            var txtSurname = driver.FindElementByAccessibilityId("txtSurname");
            var txtAddress = driver.FindElementByAccessibilityId("txtAddress");
            var txtPhone = driver.FindElementByAccessibilityId("txtPhone");
            var txtUsername = driver.FindElementByAccessibilityId("txtUsername");
            var txtPassword = driver.FindElementByAccessibilityId("txtPassword");

            txtName.SendKeys(name);
            txtSurname.SendKeys(surname);
            txtAddress.SendKeys(address);
            txtPhone.SendKeys(phone);
            txtUsername.SendKeys(username);
            txtPassword.SendKeys(password);
        }

        [Given(@"I enter surname (.*) address (.*) phone (.*) username (.*) password (.*) without entering the name")]
        public void GivenIEnterSurnameTestATAddressTestATPhoneUsernameKorisnikPasswordWithoutEnteringTheName(string surname, string address, string phone, string username, string password)
        {
            var driver = GuiDriver.GetDriver();
            var txtName = driver.FindElementByAccessibilityId("txtName");
            var txtSurname = driver.FindElementByAccessibilityId("txtSurname");
            var txtAddress = driver.FindElementByAccessibilityId("txtAddress");
            var txtPhone = driver.FindElementByAccessibilityId("txtPhone");
            var txtUsername = driver.FindElementByAccessibilityId("txtUsername");
            var txtPassword = driver.FindElementByAccessibilityId("txtPassword");

            txtName.SendKeys("");
            txtSurname.SendKeys(surname);
            txtAddress.SendKeys(address);
            txtPhone.SendKeys(phone);
            txtUsername.SendKeys(username);
            txtPassword.SendKeys(password);
        }


        [When(@"I should see MessageBox with message (.*)")]
        public void WhenIShouldSeeMessageBoxWithMessageUspjesnaRegistracija(string expectedMessage)
        {
            var driver = GuiDriver.GetDriver();
            var message = driver.FindElementByAccessibilityId("65535");
            bool correctMessage = message.Text == expectedMessage;
            Assert.IsTrue(correctMessage);
        }

        [When(@"I press ok button")]
        public void WhenIPressOkButton()
        {
            var driver = GuiDriver.GetDriver();
            var btnOk = driver.FindElementByAccessibilityId("2");
            btnOk.Click();
        }


        [When(@"I click button sign up")]
        public void WhenIClickButtonSignUp()
        {
            var driver = GuiDriver.GetDriver();
            var btnRegister = driver.FindElementByAccessibilityId("btnSignUp");
            btnRegister.Click();
        }

        [Then(@"I should remain on register page")]
        public void ThenIShouldRemainOnRegisterPage()
        {
            var driver = GuiDriver.GetDriver();
            bool isFormOpened = driver.FindElementByAccessibilityId("FrmRegistration") != null;
            Assert.IsTrue(isFormOpened);
        }

        [Then(@"I should be redirected to login form")]
        public void ThenIShouldBeRedirectedToLoginForm()
        {
            var driver = GuiDriver.GetDriver();
            Task.Delay(2000).Wait();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            bool FrmRegistration = driver.FindElementByName("FrmLogin") != null;
            Assert.IsTrue(FrmRegistration);
        }
    }
}
