
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using PlaywrightCategory.Configuration;

namespace PlaywrightCategory.Tests;

[Category("Dropdown")]
public class DropdownTests : PageTest
{
    [Test]
    public async Task Dropdown_ShouldAllowSelectingOption()
    {
        await Page.GotoAsync(TestConfig.SimpleElementsPageUrl);

        var dropdown = Page.GetByRole(AriaRole.Combobox);

        await dropdown.SelectOptionAsync(
            new SelectOptionValue { Label = "Audi" });

        await Expect(dropdown).ToHaveValueAsync("audi");
    }
}
