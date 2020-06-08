using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ServiceUtils;

namespace DummyService
{
    public class DumbService : IService
    {
        private StreamWriter _streamWriter;
        private Task _runner;
        private bool _stop;

        public DumbService()
        {
        }

        private void AddLine(string message)
        {
            _streamWriter.WriteLine($"{DateTime.Now}: {message}");
            _streamWriter.Flush();
        }

        private void Run()
        {
            while (!_stop)
            {
                AddLine("running");
                Thread.Sleep(1000);
            }
        }

        public void OnStart(string[] args)
        {
            _streamWriter = File.CreateText(@"g:\tmp\DumbService.log");
            _runner = Task.Run(() => Run());
        }


        public void OnStop()
        {
            AddLine("stop requested...");
            _stop = true;
            _runner.Wait();
            AddLine("stopped.");
            _streamWriter.Close();
        }
    }
}
