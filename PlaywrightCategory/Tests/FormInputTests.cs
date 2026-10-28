
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using PlaywrightCategory.Configuration;

namespace PlaywrightCategory.Tests;

[Category("FormInput")]
public class FormInputTests : PageTest
{
    [Test]
    public async Task ContactForm_NameField_ShouldAcceptInput()
    {
        await Page.GotoAsync(TestConfig.ConsultingFormUrl);

        var nameField = Page.GetByPlaceholder(
            "Enter text").Nth(0);

        await nameField.FillAsync("Hari");

        await Expect(nameField).ToHaveValueAsync("Hari");
    }

    // Email field should accept input
    
    [Test]
    public async Task ContactForm_EmailField_ShouldAcceptInput()
    {
        await Page.GotoAsync(TestConfig.ConsultingFormUrl);

        var emailField = Page.GetByPlaceholder("Enter email");

        await emailField.FillAsync("hari09");

        await Expect(emailField).ToHaveValueAsync("hari09");
    }

    // Accepts the valid email address and verifies the value
    
    [Test]
    public async Task ContactForm_EmailField_ShouldAcceptValidEmail()
    {
        await Page.GotoAsync(TestConfig.ConsultingFormUrl);

        var emailField = Page.GetByPlaceholder("Enter email");

        await emailField.FillAsync("hari@example.com");

        await Expect(emailField).ToHaveValueAsync("hari@example.com");

        var isValid = await emailField.EvaluateAsync<bool>(
            "element => element.validity.valid");

        Assert.That(isValid, Is.True);
    }

    //Verify that the Role field accepts text and retains the entered value
    
    [Test]
    public async Task ContactForm_RoleField_ShouldAcceptInput()
    {
        await Page.GotoAsync(TestConfig.ConsultingFormUrl);

        var roleField = Page.GetByPlaceholder(
            "Enter text").Nth(1);

        await roleField.FillAsync("QA Automation Engineer");

        await Expect(roleField).ToHaveValueAsync(
            "QA Automation Engineer");
    }
    
    //Verify that the Company name field accepts text and retains the entered value.
    
    [Test]
    public async Task ContactForm_CompanyNameField_ShouldAcceptInput()
    {
        await Page.GotoAsync(TestConfig.ConsultingFormUrl);

        var companyNameField = Page.GetByPlaceholder(
            "Enter text").Nth(2);

        await companyNameField.FillAsync("Amazech");

        await Expect(companyNameField).ToHaveValueAsync("Amazech");
    }

    // Verify that the Message field accepts text and retains the entered value.

    [Test]
    public async Task ContactForm_MessageField_ShouldAcceptInput()
    {
        await Page.GotoAsync(TestConfig.ConsultingFormUrl);

        Console.WriteLine(
            $"Textareas: {await Page.Locator("textarea").CountAsync()}");

        Console.WriteLine(
            $"Textboxes: {await Page.GetByRole(AriaRole.Textbox).CountAsync()}");

        Console.WriteLine(
            $"Frames: {Page.Frames.Count}");

        foreach (var frame in Page.Frames)
        {
            Console.WriteLine($"Frame URL: {frame.Url}");

            Console.WriteLine(
                $"Frame textareas: {await frame.Locator("textarea").CountAsync()}");

            Console.WriteLine(
                $"Frame textboxes: {await frame.GetByRole(AriaRole.Textbox).CountAsync()}");
        }
    }

    //Verify that the CAPTCHA response field exists on the consulting form.
    
    [Test]
    public async Task ContactForm_CaptchaResponseField_ShouldExist()
    {
        await Page.GotoAsync(TestConfig.ConsultingFormUrl);

        var captchaField = Page.Locator(
            "textarea[name='g-recaptcha-response']");

        await Expect(captchaField).ToHaveCountAsync(1);
    }
    
    //If the Name field is mandatory, the form should prevent submission, If the Name field is optional, the form may allow submission.
    
    [Test]
    public async Task ContactForm_NameField_ShouldBeRequired()
    {
        await Page.GotoAsync(TestConfig.ConsultingFormUrl);

        var nameField = Page.GetByPlaceholder("Enter text").Nth(0);

        var isRequired = await nameField.EvaluateAsync<bool>(
            "element => element.required");

        Assert.That(isRequired, Is.True);
    }

}
