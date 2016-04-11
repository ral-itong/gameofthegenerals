using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfTheGenerals
{
    public interface ICallback
    {
        void Callback(IAsyncResult ar);
    }
}
