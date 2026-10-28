# PlaywrightCategory

A C# UI automation testing project built with **Playwright for .NET**,
**NUnit**, and **.NET 10**. The project automates practice scenarios on
the Ultimate QA website, covering page navigation, buttons, links, form
fields, checkboxes, radio buttons, and dropdowns.

This repository is also a learning project for building reliable browser
automation tests, organizing configuration, running tests from the
terminal, and generating test reports.

## Table of Contents

-   [Project Overview](#project-overview)
-   [Technology Stack](#technology-stack)
-   [Project Structure](#project-structure)
-   [Test Coverage](#test-coverage)
-   [Configuration](#configuration)
-   [Prerequisites](#prerequisites)
-   [Initial Setup](#initial-setup)
-   [Run the Tests](#run-the-tests)
-   [Test Reports](#test-reports)
-   [Useful Terminal Commands](#useful-terminal-commands)
-   [Troubleshooting](#troubleshooting)
-   [Current Notes and Known
    Limitations](#current-notes-and-known-limitations)

## Project Overview

The purpose of this project is to practise browser automation using
Playwright with C# and NUnit.

The tests interact with pages on Ultimate QA, including:

-   `https://ultimateqa.com/automation`
-   `https://ultimateqa.com/simple-html-elements-for-automation/`
-   `https://ultimateqa.com/consulting/`

The contact form flow also references a hosted form URL configured in
the project.

> These are practice tests against external websites. The pages and
> embedded forms are outside this repository's control, so a website
> change, network issue, or third-party form change may affect test
> results.

## Technology Stack

  Technology                   Purpose
  ---------------------------- -----------------------------------------
  C#                           Test implementation language
  .NET 10                      Target framework
  Playwright for .NET          Browser automation
  NUnit                        Test framework and assertions
  Microsoft.Playwright.NUnit   Playwright integration for NUnit
  Chromium                     Browser used for test execution
  TRX                          Structured test-run results
  TrxToExtentReport 0.0.4      Converts a TRX file into an HTML report

## Project Structure

The main files and folders used by the workflow are:

``` text
PlaywrightCategory/
├── Configuration/
│   └── TestConfig.cs
├── Tests/
│   └── ... C# NUnit test classes
├── TestResults/
│   ├── TestResults.trx
│   └── TestReport.html
├── PlaywrightCategory.csproj
├── RunTests.bat
└── README.md
```

`TestResults/` contains generated output and may not exist until tests
have been run. The exact test-class filenames depend on the current
contents of the repository.

### Key files

-   **`PlaywrightCategory.csproj`** --- defines the .NET project and its
    package dependencies.
-   **`Configuration/TestConfig.cs`** --- centralizes the URLs used by
    the tests.
-   **`Tests/`** --- contains the NUnit test cases.
-   **`RunTests.bat`** --- runs the test suite and saves a TRX report.
-   **`TestResults/TestResults.trx`** --- structured results from the
    latest run.
-   **`TestResults/TestReport.html`** --- HTML report generated from the
    TRX file.

## Test Coverage

The suite contains tests in these areas.

### 1. Page navigation and page content

-   Verify the automation page loads.
-   Verify the page title and main heading.
-   Check that practice links are visible.
-   Verify selected links navigate to their expected destinations.
-   Check navigation to the Consulting page and the success page.

### 2. Buttons and links

-   Check that buttons such as Button 1, Button 2, Raise, and Click Me
    are visible or clickable.
-   Check links such as "Click Using ID," "Click This," and "Click Me."
-   Verify the expected navigation or effect for applicable
    interactions.

### 3. Form fields

-   Enter values into name, email, role, and company-name fields.
-   Check whether the name field is required.
-   Check acceptance of a valid email value.
-   Check email-field value entry.
-   Inspect the contact form's message field and CAPTCHA-response field.

### 4. Checkboxes, radio buttons, and dropdowns

-   Check checkbox visibility.
-   Check checkbox selection behavior.
-   Check radio-button visibility and selection behavior.
-   Check that selecting a radio option updates the selected state.
-   Select an option from a dropdown.

The test names include scenarios such as
`AutomationPage_ShouldLoadSuccessfully`,
`AutomationPage_ShouldDisplayMainHeading`,
`ContactForm_NameField_ShouldBeRequired`,
`ContactForm_EmailField_ShouldAcceptValidEmail`,
`Dropdown_ShouldAllowSelectingOption`,
`RadioButton_ShouldAllowOnlyOneSelection`, and
`ClickMeLink_ShouldNavigateToSuccessPage`.

> A test appearing as **Passed** means its implemented assertions
> completed successfully. Diagnostic-only tests that merely print
> element state or HTML need assertions added before they can be treated
> as verified behavioral tests. See [Current Notes and Known
> Limitations](#current-notes-and-known-limitations).

## Configuration

The project uses `Configuration/TestConfig.cs` to keep URLs in one
place. The configuration currently includes:

``` csharp
namespace PlaywrightCategory.Configuration;

public static class TestConfig
{
    public const string BaseUrl = "https://ultimateqa.com";
    public const string AutomationPageUrl = $"{BaseUrl}/automation";
    public const string SimpleElementsPageUrl =
        $"{BaseUrl}/simple-html-elements-for-automation/";
    public const string ConsultingPageUrl = $"{BaseUrl}/consulting/";
    public const string ConsultingFormUrl =
        "https://40m40a.share-na2.hsforms.com/23I1BOSbZSkmmb1UP2OzAjw";
}
```

When adding a test for one of these pages, reuse the appropriate
constant instead of repeating the URL in the test. If a URL changes,
update it centrally here.

## Prerequisites

Install or have access to:

1.  **Windows** with PowerShell.
2.  **.NET 10 SDK** to restore, build, and run the project.
3.  **Playwright Chromium browser binaries**.
4.  **.NET 8 Runtime** for the currently installed `TrxToExtentReport`
    version (`0.0.4`). The test project targets .NET 10; installing the
    .NET 8 runtime is only needed by this report tool.
5.  Internet access to reach the practice website and hosted form.

Check installed .NET runtimes:

``` powershell
dotnet --list-runtimes
```

The output should include `Microsoft.NETCore.App 10.0.x` for the project
and `Microsoft.NETCore.App 8.0.x` for the report tool.

## Initial Setup

Run the following commands in PowerShell.

### 1. Navigate to the project folder

``` powershell
cd "C:\Users\HariharanP\Documents\Learning\Playwright\PlaywrightBAT\PlaywrightCategory"
```

This is the current local path used during development. If you clone the
repository to a different directory, replace it with your own path.

### 2. Restore dependencies

``` powershell
dotnet restore "PlaywrightCategory.csproj"
```

### 3. Build the project

``` powershell
dotnet build "PlaywrightCategory.csproj"
```

### 4. Install Chromium for Playwright

After the project has built, run:

``` powershell
powershell.exe -ExecutionPolicy Bypass -File ".\bin\Debug\net10.0\playwright.ps1" install chromium
```

If you build using a different configuration or target framework, the
generated script may be located in a different output directory.

### 5. Install the HTML report tool (one-time setup)

The tool was installed globally with:

``` powershell
dotnet tool install --global TrxToExtentReport --version 0.0.4
```

If it is already installed, do not install it again. Check that the
command works:

``` powershell
TrxToExtentReport --help
```

If the command reports that .NET 8 is missing, install the **.NET 8
Runtime for Windows x64** from the official [.NET 8 download
page](https://dotnet.microsoft.com/en-us/download/dotnet/8.0). Keep .NET
10 installed for this project.

## Run the Tests

### Option A --- Run with the batch file

From the project directory:

``` powershell
.\RunTests.bat
```

The current `RunTests.bat` runs:

``` powershell
dotnet test "PlaywrightCategory.csproj" --logger "trx;LogFileName=TestResults.trx" --results-directory "TestResults"
```

It writes the test results to:

``` text
TestResults/TestResults.trx
```

Wait until the test run finishes before generating the HTML report.

### Option B --- Run directly with `dotnet test`

``` powershell
dotnet test "PlaywrightCategory.csproj" --logger "trx;LogFileName=TestResults.trx" --results-directory "TestResults"
```

Use this option when you want to run tests without using the batch file.

## Test Reports

The project uses two report formats.

### TRX report

The TRX file is produced by the test run. Its location is:

``` text
TestResults/TestResults.trx
```

It contains machine-readable test results, including test outcomes and
execution information.

### HTML report

The HTML report is generated from the TRX file by `TrxToExtentReport`.

Run this command **after the tests finish**:

``` powershell
TrxToExtentReport --trx "TestResults\TestResults.trx" --output "TestResults\TestReport.html"
```

The generated report is saved at:

``` text
TestResults/TestReport.html
```

Open the HTML report in the default browser:

``` powershell
Invoke-Item "TestResults\TestReport.html"
```

Check whether the report exists:

``` powershell
Test-Path "TestResults\TestReport.html"
```

If the command returns `False`, generate the report again and check for
any errors in the terminal.

### Full run-and-report sequence

These commands can be run one after another from the project folder:

``` powershell
.\RunTests.bat
TrxToExtentReport --trx "TestResults\TestResults.trx" --output "TestResults\TestReport.html"
Invoke-Item "TestResults\TestReport.html"
```

**Important:** The current batch file creates the TRX file, but HTML
generation is a separate command. Run the report-generation command
after every test run to refresh the HTML report.

## Useful Terminal Commands

  ------------------------------------------------------------------------------------------------------------------------------------------------------------
  Task                                Command
  ----------------------------------- ------------------------------------------------------------------------------------------------------------------------
  Navigate to the project             `cd "C:\Users\HariharanP\Documents\Learning\Playwright\PlaywrightBAT\PlaywrightCategory"`

  Check .NET runtimes                 `dotnet --list-runtimes`

  Restore dependencies                `dotnet restore "PlaywrightCategory.csproj"`

  Build                               `dotnet build "PlaywrightCategory.csproj"`

  Run the batch file                  `.\RunTests.bat`

  Run tests directly                  `dotnet test "PlaywrightCategory.csproj" --logger "trx;LogFileName=TestResults.trx" --results-directory "TestResults"`

  Install Chromium                    `powershell.exe -ExecutionPolicy Bypass -File ".\bin\Debug\net10.0\playwright.ps1" install chromium`

  Generate HTML report                `TrxToExtentReport --trx "TestResults\TestResults.trx" --output "TestResults\TestReport.html"`

  Open HTML report                    `Invoke-Item "TestResults\TestReport.html"`

  Check whether TRX exists            `Test-Path "TestResults\TestResults.trx"`

  Check whether HTML exists           `Test-Path "TestResults\TestReport.html"`
  ------------------------------------------------------------------------------------------------------------------------------------------------------------

## Troubleshooting

### `TrxToExtentReport` says .NET 8 is missing

The report tool requires the .NET 8 runtime, while the test project
targets .NET 10.

1.  Install the .NET 8 Runtime (Windows x64) from the [official .NET 8
    download
    page](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).

2.  Open a new PowerShell terminal.

3.  Check the installed runtimes:

    ``` powershell
    dotnet --list-runtimes
    ```

4.  Retry:

    ``` powershell
    TrxToExtentReport --help
    ```

### Playwright cannot find Chromium

Build the project and install the browser binaries again:

``` powershell
dotnet build "PlaywrightCategory.csproj"
powershell.exe -ExecutionPolicy Bypass -File ".\bin\Debug\net10.0\playwright.ps1" install chromium
```

### The TRX file is missing

Confirm the test run completed and check:

``` powershell
Test-Path "TestResults\TestResults.trx"
```

If it returns `False`, run the tests again:

``` powershell
.\RunTests.bat
```

### The HTML report is missing or out of date

Generate it from the latest TRX file:

``` powershell
TrxToExtentReport --trx "TestResults\TestResults.trx" --output "TestResults\TestReport.html"
```

### PowerShell cannot find `TrxToExtentReport`

Verify the tool installation:

``` powershell
dotnet tool list --global
```

If it is installed but the command is not recognized, close and reopen
the terminal so an updated PATH can be loaded. The tool can be
reinstalled using the installation command in the setup section if
necessary.

## Current Notes and Known Limitations

-   The most recent recorded full test run discovered **29 tests: 29
    passed and 0 failed**, with a duration of approximately 60 seconds.
    This is a historical run result, not a guarantee that future runs
    will have the same outcome.
-   Some tests were used to inspect page structure and print diagnostic
    information to the test output. A test can pass while printing that
    an interaction did not work if it contains no assertion for the
    expected state.
-   In one checkbox diagnostic, the checkbox was `False` before clicking
    and remained `False` afterward. That behavior needs investigation
    and a meaningful assertion; a passing diagnostic test alone does not
    prove the checkbox works.
-   The contact form is hosted by a third-party form service. Its
    embedded fields and frame behavior may differ from ordinary page
    textboxes and textareas.
-   Some scenarios have similar names or overlapping coverage. Review
    the assertions before treating all test cases as independent
    behavioral verification.
-   The current workflow produces the TRX file automatically through
    `RunTests.bat`; HTML report generation remains a separate manual
    step.

## Suggested Workflow for Each Session

1.  Open PowerShell.
2.  Change to the `PlaywrightCategory` directory.
3.  Run `.\RunTests.bat`.
4.  Review the terminal output for failed tests.
5.  Generate the HTML report from `TestResults\TestResults.trx`.
6.  Open `TestResults\TestReport.html` and review the results.
7.  Investigate any test that passes without verifying the expected
    behavior, and add appropriate Playwright or NUnit assertions.
