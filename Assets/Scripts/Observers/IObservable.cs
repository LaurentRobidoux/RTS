using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Observers
{
    public interface IObservable
    {
        ObserverCollection ObserverCollection { get; set; }
    }
}
