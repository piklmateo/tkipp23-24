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
    public class ProfileStepDefinitions
    {

        // TAG 1 //

        [Given(@"I enter username (.*) and surname (.*)")]
        public void GivenIEnterUsernameKorisnikkAndSurnameKorisnikk(string name, string surname)
        {
            var driver = GuiDriver.GetDriver();
            var txtName = driver.FindElementByAccessibilityId("txtName");
            var txtSurname = driver.FindElementByAccessibilityId("txtSurname");

            txtName.SendKeys(name);
            txtSurname.SendKeys(surname);
        }

        [When(@"I click on Save button")]
        public void WhenIClickOnSaveButton()
        {
            var driver = GuiDriver.GetDriver();
            var btnSave = driver.FindElementByAccessibilityId("btnSave");
            btnSave.Click();
        }

        [Then(@"I should get Message User info is updated!")]
        public void ThenIShouldGetMessageUserInfoIsUpdated()
        {
            var driver = GuiDriver.GetDriver();
            var btnOk = driver.FindElementByAccessibilityId("2");
            var messageText = btnOk.Text;
            Assert.AreEqual("OK", messageText);
        }

        // TAG 2 //

        [When(@"I click on row of first event")]
        public void WhenIClickOnRowOfFirstEvent()
        {
            var driver = GuiDriver.GetDriver();
            var dataGridView = driver.FindElementByAccessibilityId("dgvUserEvents");
            var cell = dataGridView.FindElementByName("Row 0");
            cell.Click();
        }

        [When(@"I click on Show details of event")]
        public void WhenIClickOnShowDetailsOfEvent()
        {
            var driver = GuiDriver.GetDriver();
            var btnSelectedEvent = driver.FindElementByAccessibilityId("btnSelectedEvent");
            btnSelectedEvent.Click();
        }

        [Then(@"I should see details of event")]
        public void ThenIShouldSeeDetailsOfEvent()
        {
            var driver = GuiDriver.GetDriver();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            bool FrmEvent = driver.FindElementByAccessibilityId("FrmEvent") != null;
            Assert.IsTrue(FrmEvent);
        }

        // Tag 3 //

        [When(@"I click on calendar button")]
        public void WhenIClickOnCalendarButton()
        {
            var driver = GuiDriver.GetDriver();
            var btnCalendar = driver.FindElementByAccessibilityId("btnCalendar");
            btnCalendar.Click();
        }

        [When(@"I traverse the calendar to a specific date")]
        public void WhenITraverseTheCalendarToASpecificDateAsync()
        {
            var dateText = "28";
            var driver = GuiDriver.GetDriver();
            var btnPrevious = driver.FindElementByAccessibilityId("btnPrevious");
            btnPrevious.Click();
            btnPrevious.Click();
            btnPrevious.Click();

            Task.Delay(1000);

            var calendarPane = driver.FindElementByAccessibilityId("flpCalendar");
            var dayElement = calendarPane.FindElements(By.XPath($"//*[contains(@Name, '{dateText}')]")).FirstOrDefault();

            if (dayElement == null)
                Assert.Fail($"No element containing '{dateText}' was found in the calendar.");

            Actions actions = new Actions(driver);

      
            actions.MoveToElement(dayElement)
                   .MoveByOffset(15, 15)  // Moves the mouse 10 pixels right and 10 pixels down from the center of the element
                   .Click()
                   .Perform();
        }

        [Then(@"I should see events for that date")]
        public void ThenIShouldSeeEventsForThatDate()
        {
            var driver = GuiDriver.GetDriver();

            Task.Delay(3000).Wait();

            var dataGridView = driver.FindElementByAccessibilityId("dgvEvents");
            var cell = dataGridView.FindElementByName("Row 0");
            
            if(cell != null)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.Fail("Nema dogaðaja za ovaj datum.");
            }
        }

        // Tag 4 //

        [When(@"I click on transactions button")]
        public void WhenIClickOnTransactionsButton()
        {
            var driver = GuiDriver.GetDriver();
            var btnTransactions = driver.FindElementByAccessibilityId("btnTransactions");
            btnTransactions.Click();
        }

        [Then(@"I should see all transactions of user")]
        public void ThenIShouldSeeAllTransactionsOfUser()
        {
            var driver = GuiDriver.GetDriver();
            bool isFormOpened = driver.FindElementByAccessibilityId("FrmUserTransactions") != null;
            Assert.IsTrue(isFormOpened);
        }

    }
}
