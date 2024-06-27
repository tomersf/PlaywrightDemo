using Microsoft.Playwright;
using PlaywrightDemo.Config;

namespace PlaywrightDemo.Driver;

public interface IPlaywrightDriverInitializer
{
    Task<IBrowser> GetChromeDriverAsync(TestSettings testSettings);
    Task<IBrowser> GetFirefoxDriverAsync(TestSettings testSettings);
    Task<IBrowser> GetChromiumDriverAsync(TestSettings testSettings);
}