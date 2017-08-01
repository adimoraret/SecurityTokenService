using System;
using Microsoft.Owin.Hosting;

namespace SelfHostWindowsAuthentication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Title = "IdentityServer3 SelfHost with windows authentication";

            const string url = "https://localhost:44333";
            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine("\n\nServer listening at {0}. Press enter to stop", url);
                Console.ReadLine();
            }
        }
    }
}
