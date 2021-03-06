﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ServiceUtils;

namespace DummyServiceFw
{
    public class DummyServiceFw : IService
    {
        private StreamWriter _streamWriter;
        private Task _runner;
        private bool _stop;

        public bool ConsoleMode { get; set; }

        public DummyServiceFw()
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
            _streamWriter = File.CreateText(@"c:\tmp\DummyServiceFw.log");
            AddLine($"ConsoleMode: {ConsoleMode}");
            AddLine($"args: '{string.Join(" ", args)}'");
            AddLine($"Prg args: '{string.Join(" ", Environment.GetCommandLineArgs())}'");
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
