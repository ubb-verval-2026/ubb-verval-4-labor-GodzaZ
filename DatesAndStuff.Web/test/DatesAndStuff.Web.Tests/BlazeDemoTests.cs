using System;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DatesAndStuff.Web.Tests;

[TestFixture]
public class BlazeDemoTests
{
    private IWebDriver driver;

    [SetUp]
    public void SetupTest()
    {
        driver = new ChromeDriver();
    }

    [TearDown]
    public void TeardownTest()
    {
        try
        {
            driver.Quit();
            driver.Dispose();
        }
        catch (Exception)
        {
        
        }
    }

    [Test]
    public void FindFlights_FromMexicoCityToDublin_ShouldHaveAtLeastThreeFlights()
    {
        // Arrange
        driver.Navigate().GoToUrl("https://blazedemo.com/");

        driver.FindElement(By.XPath("//select[@name='fromPort']/option[@value='Mexico City']")).Click();

        driver.FindElement(By.XPath("//select[@name='toPort']/option[@value='Dublin']")).Click();

        // Act
        var submitButton = driver.FindElement(By.CssSelector("input[type='submit']"));
        submitButton.Click();

        // Assert
        var flightRows = driver.FindElements(By.CssSelector("table.table tbody tr"));

        flightRows.Count.Should().BeGreaterThanOrEqualTo(3, "legalabb 3 jarat");
    }
}