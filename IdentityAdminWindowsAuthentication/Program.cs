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
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>(Application.IdentityAdminUrl))
            {
                Console.WriteLine("\n\nServer listening at {0}. Press enter to stop",
                    Application.IdentityAdminUrl);
                Console.ReadLine();
            }
        }
    }
}
