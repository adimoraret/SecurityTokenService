using System;
using Microsoft.Owin.Hosting;

namespace SelfHostWindowsAuthentication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Title = Application.Title;

            using (WebApp.Start<Startup>(Application.StsUrl))
            {
                Console.WriteLine("\n\nServer listening at {0}. Press enter to stop", 
                    Application.StsUrl);
                Console.ReadLine();
            }
        }
    }
}
