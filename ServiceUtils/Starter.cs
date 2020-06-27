using System;
using System.IO;

namespace ServiceUtils
{
    /// <summary>
    /// Class that start the service
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class Starter<T> where T : IService, new()
    {
        /// <summary>
        /// function to start the service
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="args"></param>
        /// <param name="useCmdLineArgs">If this flag is set and args is empty, use cmd line args instead</param>
        public static void Start(string serviceName, string[] args, bool useCmdLineArgs)
        {
            if (Helpers.IsConsoleApp())
            {
                Console.WriteLine($"Start service of type {typeof(T)} in console mode...");
                var service = new T
                {
                    ConsoleMode = true
                };
                service.OnStart(args);
                Console.WriteLine("Press 'q' to quit...");
                while (Console.ReadKey().KeyChar != 'q') ;
                service.OnStop();
            }
            else
                System.ServiceProcess.ServiceBase.Run(new Service<T>(serviceName, useCmdLineArgs));
        }
    }
}
