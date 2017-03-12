using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleHttpServer;
using SimpleMVC;

namespace GameStore.App
{
    class AppStart
    {
        static void Main()
        {
            HttpServer server=new HttpServer(8081,RoutesTable.Routes);
            MvcEngine.Run(server,"GameStore.App");
        }
    }
}
