using Microsoft.Playwright;
using PlaywrightDemo.Config;

namespace PlaywrightDemo.Driver;

public class PlaywrightDriver
{
    public async Task<IPage> InitalizePlaywrightAsync(TestSettings testSettings)
    {
        var browser = await GetBrowserAsync(testSettings);
        var browserContext = await browser.NewContextAsync();
        var page = await browserContext.NewPageAsync();

        await page.GotoAsync("http://eaapp.somee.com");

        return page;
    }

    private async Task<IBrowser> GetBrowserAsync(TestSettings testSettings)
    {
        var playwrightDriver = await Playwright.CreateAsync();
        var browserOptions = new BrowserTypeLaunchOptions
        {
            Headless = testSettings.Headless,
            SlowMo = testSettings.SlowMo,
            Channel = testSettings.Channel,
        };
        
        return testSettings.DriverType switch
        {
            DriverTypeEnum.Chromium => await playwrightDriver.Chromium.LaunchAsync(browserOptions),
            DriverTypeEnum.Chrome => await playwrightDriver["chrome"].LaunchAsync(browserOptions),
            DriverTypeEnum.Edge => await playwrightDriver["edge"].LaunchAsync(browserOptions),
            DriverTypeEnum.Firefox => await playwrightDriver.Firefox.LaunchAsync(browserOptions),
            _ => await playwrightDriver.Chromium.LaunchAsync(browserOptions)
        };
    }
}