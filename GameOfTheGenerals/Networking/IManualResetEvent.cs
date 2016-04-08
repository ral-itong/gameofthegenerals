using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GameOfTheGenerals
{
    interface IManualResetEvent
    {
        bool Reset();
        bool WaitOne();
        bool Set();
    }
}
