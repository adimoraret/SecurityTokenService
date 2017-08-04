using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace IdentityAdminWindowsAuthentication
{
    class Program
    {
        public static string IdentityAdminUrl => "https://localhost:44333";

        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>(IdentityAdminUrl))
            {
                Console.WriteLine("\n\nServer listening at {0}. Press enter to stop",
                    IdentityAdminUrl);
                Console.ReadLine();
            }
        }
    }
}
