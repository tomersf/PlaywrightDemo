using Microsoft.Playwright;
using PlaywrightDemo.Config;

namespace PlaywrightDemo.Driver;

public class PlaywrightDriver
{
    private readonly TestSettings _testSettings;
    private readonly IPlaywrightDriverInitializer _playwrightDriverInitializer;
    private readonly AsyncTask<IBrowser> _browser;
    private readonly AsyncTask<IBrowserContext> _browserContext;
    private readonly AsyncTask<IPage> _page;

    public Task<IPage> Page => _page.Value;
    public Task<IBrowser> Browser => _browser.Value;
    public Task<IBrowserContext> BrowserContext => _browserContext.Value;
    

    public PlaywrightDriver(TestSettings testSettings, IPlaywrightDriverInitializer playwrightDriverInitializer)
    {
        _testSettings = testSettings;
        _playwrightDriverInitializer = playwrightDriverInitializer;

        _browser = new AsyncTask<IBrowser>(InitializePlaywrightAsync);
        _browserContext = new AsyncTask<IBrowserContext>(CreateBrowserContext);
        _page = new AsyncTask<IPage>(CreatePageAsync);
    }
    
    private async Task<IBrowser> InitializePlaywrightAsync()
    {
        return _testSettings.DriverType switch
        {
            DriverTypeEnum.Chromium => await _playwrightDriverInitializer.GetChromiumDriverAsync(_testSettings),
            DriverTypeEnum.Firefox => await _playwrightDriverInitializer.GetFirefoxDriverAsync(_testSettings),
            _ => await _playwrightDriverInitializer.GetChromeDriverAsync(_testSettings)
        };
    }

    private async Task<IBrowserContext> CreateBrowserContext()
    {
        return await (await _browser).NewContextAsync();
    }

    private async Task<IPage> CreatePageAsync()
    {
        return await (await _browserContext).NewPageAsync();
    }
    
    public async Task TearDown()
    {
        var browser = await _browser;
        await browser.CloseAsync();
        await browser.DisposeAsync();
    }
}