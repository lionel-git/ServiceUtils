using System;
using ServiceUtils;

namespace DummyService
{
    class Program
    {
        static void Main(string[] args)
        {
            Starter<DumbService>.Start("DummyService", args);
        }
    }
}
