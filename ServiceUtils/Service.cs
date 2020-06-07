using System;
using System.ComponentModel;
using System.ServiceProcess;

namespace ServiceUtils
{
    [DesignerCategory("Code")]
    public class Service<T> : ServiceBase where T : IService, new()
    {
        private readonly T _service = new T();

        public Service(string serviceName)
        {
            ServiceName = serviceName;
            CanStop = true;
            CanPauseAndContinue = false;
            AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {
            _service.OnStart(args);
        }

        protected override void OnStop()
        {
            _service.OnStop();
        }
    }
}
    
