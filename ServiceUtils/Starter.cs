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
            // Warning: Environment.UserInteractive always return true in .net core mode ?
            bool isConsoleApp = Console.OpenStandardInput(1) != Stream.Null;
            if (isConsoleApp)
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
