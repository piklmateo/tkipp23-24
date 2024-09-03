using AcceptanceTests.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace AcceptanceTests.StepDefinitions
{
    [Binding]
    public class LocationSearchStepDefinitions
    {

        // Tag 1 //

        [When(@"I click on button Filter By Location")]
        public void WhenIClickOnButtonFilterByLocation()
        {
            var driver = GuiDriver.GetDriver();
            var btnBuyTicket = driver.FindElementByAccessibilityId("btnLocation");
            btnBuyTicket.Click();
        }

        [Then(@"I should click yes on the message If I want to use my current location")]
        public void ThenIShouldClickYesOnTheMessageIfIWantToUseMyCurrentLocation()
        {
            var driver = GuiDriver.GetDriver();
            var yesButton = driver.FindElementByName("Yes");
            yesButton.Click();
        }

        [Then(@"I should not get message Lokacija nije uspiješno dohvaćena")]
        public void ThenIShouldNotGetMessageLokacijaNijeUspijesnoDohvacena()
        {
            // Nikada ne radi iz prve. Problem je do koda...

            var driver = GuiDriver.GetDriver();

            var messageBoxes = driver.FindElementsByClassName("#32770");
            foreach (var box in messageBoxes)
            {
                var textElements = box.FindElementsByClassName("Static");
                foreach (var textElement in textElements)
                {
                    if (textElement.Text.Contains("nije"))
                    {

                        // U trenutnoj implementaciji uvijek padne, makar radi,
                        // ali ne iz prve...

                        Assert.IsTrue(false, "Location is not found!");
                        return;
                    }
                }
            }
            Assert.IsTrue(true, "Location found!");
        }

        // Tag 2 //


        [Then(@"I should click on no the message If I want to use my current location")]
        public void ThenIShouldClickOnNoTheMessageIfIWantToUseMyCurrentLocation()
        {
            // Ne radi. Baca exception u produkciji.

            var driver = GuiDriver.GetDriver();
            var noButton = driver.FindElementByName("No");
            try
            {
                noButton.Click();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, "Exception: ", ex);
            }
            Assert.IsTrue(true);
        }


        // Tag 3 //

        [Then(@"I should get message Lokacija nije uspiješno dohvaćena")]
        public void ThenIShouldGetMessageLokacijaNijeUspijesnoDohvacena()
        {
            var driver = GuiDriver.GetDriver();

            var messageBoxes = driver.FindElementsByClassName("#32770");
            foreach (var box in messageBoxes)
            {
                var textElements = box.FindElementsByClassName("Static");
                foreach (var textElement in textElements)
                {
                    if (textElement.Text.Contains("nije"))
                    {
                        Assert.IsTrue(true, "Location is not found!");
                        return;
                    }
                }
            }
            Assert.IsTrue(false, "Location found!");
        }


    }
}
