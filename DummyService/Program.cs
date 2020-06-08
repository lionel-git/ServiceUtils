using System;
using ServiceUtils;

namespace DummyService
{
    class Program
    {
        static void Main(string[] args)
        {
            Starter<DummyService>.Start("DummyService", args);
        }
    }
}
