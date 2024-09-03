using System;
using System.Linq;
using AcceptanceTests.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace AcceptanceTests.StepDefinitions
{
    [Binding]
    public class ReminderStepDefinitions
    {
        [Given(@"I click buy ticket button")]
        public void GivenIClickBuyTicketButton()
        {
            var driver = GuiDriver.GetDriver();
            var btnBuyTicket = driver.FindElementByAccessibilityId("btnBuyTicket");
            btnBuyTicket.Click();
        }

        [Given(@"I click (.*) vip ticket")]
        public void GivenIClickVipTicket(string vipTicket)
        {
            var driver = GuiDriver.GetDriver();
            var spinVipTicket = driver.FindElementByAccessibilityId("nudAmount1");
            spinVipTicket.SendKeys(vipTicket);
        }

        [Given(@"I fill email with (.*)")]
        public void GivenIFillEmailWithTmodricdrtestGmail_Com(string email)
        {
            var driver = GuiDriver.GetDriver();
            var txtEmail = driver.FindElementByAccessibilityId("txtEmail");

            txtEmail.SendKeys(email);
        }


        [Given(@"I click Add button")]
        public void WhenIClickAddButton()
        {
            var driver = GuiDriver.GetDriver();
            var btnAdd = driver.FindElementByAccessibilityId("btnAdd");
            btnAdd.Click();
        }

        [Given(@"I should see message box (.*)")]
        public void GivenIShouldSeeMessageBoxTransactionIsComplete(string expectedMessage)
        {
            var driver = GuiDriver.GetDriver();
            var lblErrorMessage = driver.FindElementByAccessibilityId("65535");
            var actualMessage = lblErrorMessage.Text;
            Assert.AreEqual(actualMessage, expectedMessage);
        }

        [Then(@"I should get toast reminder - OVJDE TEST PADA JER NE VIDI REMINDER")]
        public void ThenIShouldGetToastReminder_OVJDETESTPADAJERNEVIDIREMINDER()
        {
            var driver = GuiDriver.GetDriver();
            driver.SwitchTo().Window(driver.WindowHandles.First());
            bool NormalToastView = driver.FindElementByAccessibilityId("ToastCenterScrollViewer") != null;
            Assert.IsTrue(NormalToastView);
        }
    }
}
