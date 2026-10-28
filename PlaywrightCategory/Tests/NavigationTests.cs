
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using PlaywrightCategory.Configuration;
using System.Text.RegularExpressions;

namespace PlaywrightCategory.Tests;

[Category("Navigation")]
public class NavigationTests : PageTest
{
    [Test]
    public async Task AutomationPage_ShouldLoadSuccessfully()
    {
        // Navigate using the centralised URL configuration
        await Page.GotoAsync(TestConfig.AutomationPageUrl);

        // Verify the actual page title
        await Expect(Page).ToHaveTitleAsync(
            new Regex("Automation Practice \\| Ultimate QA"));
    }

    [Test]
    public async Task AutomationPage_ShouldDisplayMainHeading()
    {
        await Page.GotoAsync(TestConfig.AutomationPageUrl);

        var heading = Page.GetByRole(
            Microsoft.Playwright.AriaRole.Heading,
            new() { Name = "Automation Practice" });

        await Expect(heading).ToBeVisibleAsync();
    }
}
