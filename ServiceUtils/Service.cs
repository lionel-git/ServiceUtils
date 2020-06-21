using System;
using System.ComponentModel;
using System.IO;
using System.ServiceModel.Security;
using System.ServiceProcess;

#pragma warning disable CS1591

namespace ServiceUtils
{
    [DesignerCategory("Code")]
    public class Service<T> : ServiceBase where T : IService, new()
    {
        private readonly T _service = new T();

        private bool _useCmdLineArgs;

        public Service(string serviceName, bool useCmdLineArgs)
        {
            ServiceName = serviceName;
            CanStop = true;
            CanPauseAndContinue = false;
            AutoLog = true;
            _useCmdLineArgs = useCmdLineArgs;
        }

        protected override void OnStart(string[] args)
        {
            // Warning, here args is test args from service
            // prg args can be retrieved from Environment.GetCommandLineArgs() (start with prgname)
            var cmdLineArgs = Environment.GetCommandLineArgs();
            if (_useCmdLineArgs && args.Length == 0 && cmdLineArgs.Length > 1)
            {                
                var cmdLineArgsCut = new string[cmdLineArgs.Length - 1];
                Array.Copy(cmdLineArgs, 1, cmdLineArgsCut, 0, cmdLineArgsCut.Length);
                _service.OnStart(cmdLineArgsCut);
            }
            else
                _service.OnStart(args);
        }

        protected override void OnStop()
        {
            _service.OnStop();
        }
    }
}
    
