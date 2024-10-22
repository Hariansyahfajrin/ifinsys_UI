namespace Config
{
  public static class AppConfig
  {
    public static readonly string MODULE = "IFINSYS";
    public static readonly string VERSION = Environment.GetEnvironmentVariable("APP_VERSION") ?? "6.0.0";
    public static readonly string BASE_PATH = "/";
    public static readonly string LOGIN_PATH = "/login";
    public static readonly int MaximumReceiveMessageSize = 1024 * 100000; // 10 MB

  }
}