using PlaywrightDemo.Config;
using PlaywrightDemo.Driver;

namespace PlaywrightDemo;

public class Tests
{
    private PlaywrightDriver _driver;
    private PlaywrightDriverInitializer _playwrightDriverInitializer;
    
    [SetUp]
    public void Setup()
    {
        TestSettings testSettings = new TestSettings
        {
            Headless = false,
            DriverType = DriverTypeEnum.Chromium
        };
        
        _playwrightDriverInitializer = new PlaywrightDriverInitializer();
        _driver = new PlaywrightDriver(testSettings, _playwrightDriverInitializer);
    }

    [Test]
    public async Task Test1()
    {
        var page = await _driver.Page;
        await page.GotoAsync("http://eaapp.somee.com");
        await page.ClickAsync("text=Login");
    }
    
    [TearDown]
    public async Task TearDown()
    {
        await _driver.TearDown();
    }
}