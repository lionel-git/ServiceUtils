using System;

namespace ServiceUtils
{
    public static class Starter<T> where T : IService, new()
    {
        public static void Start(string serviceName, string[] args)
        {
            if (Environment.UserInteractive)
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
