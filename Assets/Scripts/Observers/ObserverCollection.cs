using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Observers
{
    public class ObserverCollection
    {
        public ObserverCollection(IObservable pObservable)
        {
            observers = new List<IObserver>();
            Observable = pObservable;
        }
        IObservable Observable { get; set; }
        public List<IObserver> observers { get; set; }
        public void Call(string msg)
        {
            for (int index = 0; index < observers.Count; index++)
            {
                observers[index].OnObservableCall(Observable,msg);
            }
        }
        public void Register(IObserver observer)
        {
            observers.Add(observer);
        }
        public void UnRegister(IObserver observer)
        {
            observers.Remove(observer);
        }
    }
}
