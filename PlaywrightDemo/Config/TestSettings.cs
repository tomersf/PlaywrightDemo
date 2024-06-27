namespace PlaywrightDemo.Config;

public class TestSettings
{
    public string[]? Args { get; set; }
    public float Timeout { get; set; }
    public bool Headless { get; init; }
    public int SlowMo { get; init; }
    public DriverTypeEnum DriverType { get; set; }
}

public enum DriverTypeEnum
{
    Chromium,
    Firefox,
    Edge,
    Chrome,
}

public static class ChannelType
{
    public const string Chrome = "chrome";
    public const string Firefox = "firefox";
    public const string Chromium = "chromium";
}