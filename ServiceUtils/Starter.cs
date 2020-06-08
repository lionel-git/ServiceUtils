using System;
using System.IO;

namespace ServiceUtils
{
    public static class Starter<T> where T : IService, new()
    {
        public static void Start(string serviceName, string[] args)
        {
            // Warning: Environment.UserInteractive always return true in .net core mode ?            
            bool isConsoleApp = Console.OpenStandardInput(1) != Stream.Null;
            if (isConsoleApp)
            {
                Console.WriteLine($"Start service of type {typeof(T)} in console mode...");
                var service = new T();
                service.OnStart(args);
                Console.WriteLine("Press 'q' to quit...");
                while (Console.ReadKey().KeyChar != 'q') ;
                service.OnStop();
            }
            else
                System.ServiceProcess.ServiceBase.Run(new Service<T>(serviceName));
        }
    }
}
