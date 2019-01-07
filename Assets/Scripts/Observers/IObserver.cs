using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Observers
{
    public interface IObserver
    {
         void OnObservableCall(object called,string msg);
    }
}
