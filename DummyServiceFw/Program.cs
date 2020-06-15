using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceUtils;

namespace DummyServiceFw
{
    class Program
    {
        static void Main(string[] args)
        {
            Starter<DummyServiceFw>.Start("DummyServiceFw", args);
        }
    }
}
