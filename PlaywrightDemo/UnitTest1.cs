using Microsoft.Playwright;
using PlaywrightDemo.Config;
using PlaywrightDemo.Driver;

namespace PlaywrightDemo;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task Test1()
    {
        TestSettings testSettings = new TestSettings
        {
            Headless = false,
            DriverType = DriverTypeEnum.Chromium
        };
        
        PlaywrightDriver driver = new PlaywrightDriver();
        IPage page = await driver.InitalizePlaywrightAsync(testSettings);

        await page.ClickAsync("text=Login");
    }
}