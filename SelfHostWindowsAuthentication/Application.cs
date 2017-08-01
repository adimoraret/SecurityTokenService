namespace SelfHostWindowsAuthentication
{
    internal static class Application
    {
        public static string Title => "IdentityServer3 SelfHost with windows authentication";
        public static string StsUrl => "https://localhost:44333";
        public static string StsWindowsUrl => "https://localhost:44333/windows";
        public static string StsWindowsAuth => "https://localhost:44333/was";
    }
}
