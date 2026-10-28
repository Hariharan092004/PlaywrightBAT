
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using PlaywrightCategory.Configuration;

namespace PlaywrightCategory.Tests;

[Category("ButtonsAndLinks")]
public class ButtonsAndLinksTests : PageTest
{
    [Test]
    public async Task ClickMeButton_ShouldBeVisible()
    {
        await Page.GotoAsync(TestConfig.SimpleElementsPageUrl);

        var button = Page.GetByRole(
            AriaRole.Button,
            new() { Name = "Click Me" });

        await Expect(button).ToBeVisibleAsync();
    }

    [Test]
    public async Task RaiseButton_ShouldBeVisible()
    {
        await Page.GotoAsync(TestConfig.SimpleElementsPageUrl);

        var button = Page.GetByRole(
            AriaRole.Button,
            new() { Name = "Raise" });

        await Expect(button).ToBeVisibleAsync();
    }
 
    [Test]
    public async Task Button1_ShouldBeClickable()
    {
        await Page.GotoAsync(TestConfig.SimpleElementsPageUrl);

        var button = Page.GetByRole(
            AriaRole.Button,
            new() { Name = "Button 1" }).Nth(0);

        await Expect(button).ToBeVisibleAsync();
        await button.ClickAsync();
    }

    // Check button2 is clickable
    
    [Test]
    public async Task Button2_ShouldBeClickable()
    {
        await Page.GotoAsync(TestConfig.SimpleElementsPageUrl);

        var button = Page.GetByRole(
            AriaRole.Button,
            new() { Name = "Button 2" }).Nth(0);

        await Expect(button).ToBeVisibleAsync();
        await button.ClickAsync();
    }

    // Check for link
    
    [Test]
    public async Task ClickUsingIdLink_ShouldBeVisible()
    {
        await Page.GotoAsync(TestConfig.SimpleElementsPageUrl);

        var link = Page.GetByRole(
            AriaRole.Link,
            new() { Name = @"Click this button using ""ID""", Exact = false });

        await Expect(link).ToBeVisibleAsync();
    }

    // Service Link Test
    
    [Test]
    public async Task ServicesLink_ShouldBeVisible()
    {
        await Page.GotoAsync(TestConfig.AutomationPageUrl);

        var link = Page.GetByRole(
            AriaRole.Link,
            new() { Name = "Services", Exact = true });

        await Expect(link).ToBeVisibleAsync();
    }
    
  
    [Test]
    public async Task ServicesLink_ShouldNavigateToConsultingPage()
    {
        await Page.GotoAsync(TestConfig.AutomationPageUrl);

        var servicesLink = Page.GetByRole(
            AriaRole.Link,
            new() { Name = "Services", Exact = true });

        await servicesLink.ClickAsync();

        await Expect(Page).ToHaveURLAsync(
            "https://ultimateqa.com/consulting/");
    }

    // Link visibility test

    
    [Test]
    public async Task LinkTextNavigation_ShouldBeVisible()
    {
        await Page.GotoAsync(TestConfig.SimpleElementsPageUrl);

        var link = Page.GetByRole(
            AriaRole.Link,
            new() { Name = "Click me using this link text!", Exact = true });

        await Expect(link).ToBeVisibleAsync();
    }

    //Add the link navigation test
    
    [Test]
    public async Task ClickMeLink_ShouldNavigateToSuccessPage()
    {
        await Page.GotoAsync(TestConfig.SimpleElementsPageUrl);

        var link = Page.GetByRole(
            AriaRole.Link,
            new() { Name = "Click Me", Exact = true });

        await link.ClickAsync();

        await Expect(Page).ToHaveURLAsync(
            new System.Text.RegularExpressions.Regex(
                "/button-success/?"));
    }

    // Click this link is visible test
        
    [Test]
    public async Task ClickThisLink_ShouldBeVisible()
    {
        await Page.GotoAsync(TestConfig.SimpleElementsPageUrl);

        var link = Page.GetByRole(
            AriaRole.Link,
            new() { Name = "Click this link", Exact = true });

        await Expect(link).ToBeVisibleAsync();
    }

    
    [Test]
    public async Task ConsultingScheduleLink_ShouldOpenForm()
    {
        await Page.GotoAsync(TestConfig.ConsultingPageUrl);
        var link = Page.GetByRole(
            AriaRole.Link,
            new()
            {
                Name = "SCHEDULE A FREE DISCOVERY SESSION",
                Exact = true
            }).Nth(0);
        var newPage = await Page.RunAndWaitForPopupAsync(
            async () => await link.ClickAsync());
        await Expect(newPage).ToHaveURLAsync(
            TestConfig.ConsultingFormUrl);
    }

}
