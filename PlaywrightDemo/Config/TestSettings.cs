namespace PlaywrightDemo.Config;

public class TestSettings
{
    public bool Headless { get; init; }
    public string Channel { get; set; } = string.Empty;
    public int SlowMo { get; init; }
    public DriverTypeEnum DriverType { get; set; }
}

public enum DriverTypeEnum
{
    Chromium,
    Firefox,
    Edge,
    Chrome,
    WebKit
}