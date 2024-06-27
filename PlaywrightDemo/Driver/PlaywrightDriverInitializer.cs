using Microsoft.Playwright;
using PlaywrightDemo.Config;

namespace PlaywrightDemo.Driver;

public class PlaywrightDriverInitializer: IPlaywrightDriverInitializer
{
    private const float DefaultTimeout = 30f;
    public async Task<IBrowser> GetChromeDriverAsync(TestSettings testSettings)
    {
        var options = GetParameters(testSettings.Args, testSettings.Timeout, testSettings.Headless,
            testSettings.SlowMo);
        options.Channel = ChannelType.Chrome;
        return await GetBrowserAsync(DriverTypeEnum.Chrome, options);
    }
    
    public async Task<IBrowser> GetFirefoxDriverAsync(TestSettings testSettings)
    {
        var options = GetParameters(testSettings.Args, testSettings.Timeout, testSettings.Headless,
            testSettings.SlowMo);
        options.Channel = ChannelType.Firefox;
        return await GetBrowserAsync(DriverTypeEnum.Firefox, options);
    }
    
    public async Task<IBrowser> GetChromiumDriverAsync(TestSettings testSettings)
    {
        var options = GetParameters(testSettings.Args, testSettings.Timeout, testSettings.Headless,
            testSettings.SlowMo);
        options.Channel = ChannelType.Chromium;
        return await GetBrowserAsync(DriverTypeEnum.Chromium, options);
    }

    private async Task<IBrowser> GetBrowserAsync(DriverTypeEnum driverType, BrowserTypeLaunchOptions options)
    {
        var playwright = await Playwright.CreateAsync();
        return await playwright[driverType.ToString().ToLower()].LaunchAsync(options);
    }

    private BrowserTypeLaunchOptions GetParameters(string[]? args, float timeout = DefaultTimeout, bool headless = true, float? slowMo = null)
    {
        return new BrowserTypeLaunchOptions
        {
            Args = args,
            Timeout = ToMilliseconds(timeout),
            Headless = headless,
            SlowMo = slowMo
        };
    }

    private static float ToMilliseconds(float seconds)
    {
        return 1000 * seconds;
    }
}