
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using PlaywrightCategory.Configuration;

namespace PlaywrightCategory.Tests;

[Category("RadioAndCheckbox")]
public class RadioAndCheckboxTests : PageTest
{
    // Male Radio button
    [Test]
    public async Task MaleRadioButton_ShouldBeVisible()
    {
        await Page.GotoAsync(TestConfig.SimpleElementsPageUrl);

        var maleRadioButton = Page.GetByRole(
            AriaRole.Radio);

        await Expect(maleRadioButton.Nth(0)).ToBeVisibleAsync();
    }

    // Female Radio button
    
    [Test]
    public async Task FemaleRadioButton_ShouldBeVisible()
    {
        await Page.GotoAsync(TestConfig.SimpleElementsPageUrl);

        var radioButtons = Page.GetByRole(AriaRole.Radio);

        await Expect(radioButtons.Nth(1)).ToBeVisibleAsync();
    }

    // verify bike checkbox is visible
    
    [Test]
    public async Task BikeCheckbox_ShouldBeVisible()
    {
        await Page.GotoAsync(TestConfig.SimpleElementsPageUrl);

        var bikeCheckbox = Page.GetByRole(
            AriaRole.Checkbox).Nth(0);

        await Expect(bikeCheckbox).ToBeVisibleAsync();
    }

    // Bike checkbox should be checked when clicked
    
    [Test]
    public async Task BikeCheckbox_ShouldBeChecked()
    {
        await Page.GotoAsync(TestConfig.SimpleElementsPageUrl);

        var bikeCheckbox = Page.Locator(
            "input[type='checkbox'][value='Bike']");

        Console.WriteLine(
            $"Before: {await bikeCheckbox.IsCheckedAsync()}");

        Console.WriteLine(
            $"HTML: {await bikeCheckbox.EvaluateAsync<string>(
                "element => element.parentElement.outerHTML")}");

        await bikeCheckbox.ClickAsync();

        Console.WriteLine(
            $"After: {await bikeCheckbox.IsCheckedAsync()}");

        Console.WriteLine(
            $"After click HTML: {await bikeCheckbox.EvaluateAsync<string>(
                "element => element.outerHTML")}");
    }

    [Test]
    public async Task BikeCheckbox_ShouldBeCheckedFinal()
    {
        await Page.GotoAsync(TestConfig.SimpleElementsPageUrl);

        var bikeCheckbox = Page.Locator(
            "input[type='checkbox'][value='Bike']");

        await bikeCheckbox.ClickAsync();

        await Expect(bikeCheckbox).ToBeCheckedAsync();
    }

    // Verify the car checkbox is visible
    
    [Test]
    public async Task CarCheckbox_ShouldBeVisible()
    {
        await Page.GotoAsync(TestConfig.SimpleElementsPageUrl);

        var carCheckbox = Page.Locator(
            "input[type='checkbox'][value='Car']");

        await Expect(carCheckbox).ToBeVisibleAsync();
    }

    // Radio button should be selected only one at a time
    
    [Test]
    public async Task RadioButton_ShouldAllowOnlyOneSelection()
    {
        await Page.GotoAsync(TestConfig.SimpleElementsPageUrl);

        var maleRadio = Page.Locator(
            "input[type='radio'][value='male']");

        var femaleRadio = Page.Locator(
            "input[type='radio'][value='female']");

        await maleRadio.ClickAsync();
        Console.WriteLine(
            $"Male checked: {await maleRadio.IsCheckedAsync()}");

        await femaleRadio.ClickAsync();
        Console.WriteLine(
            $"Female checked: {await femaleRadio.IsCheckedAsync()}");

        Console.WriteLine(
            $"Male checked after selecting female: {await maleRadio.IsCheckedAsync()}");
    }



}
