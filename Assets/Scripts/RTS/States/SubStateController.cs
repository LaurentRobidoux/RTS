using Observers;
using RTS.Commands;
using RTS.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace RTS.States
{
    public class SubStateController  : RtsComponent,IObservable
    {
        
        public State State;
        public ActionInfo Info;
        public void Awake()
        {
            ObserverCollection = new ObserverCollection(this);
        }
        public virtual State CreateState(params Target[] target)
        {
            var s= (State)ScriptableObject.CreateInstance(State.GetType());
            s.Init(this.gameObject, target);
            return s;
        }
        private ObserverCollection _observerCollection;

        public ObserverCollection ObserverCollection
        {
            get
            {
                return _observerCollection;
            }

            set
            {
                _observerCollection = value;
            }
        }
        public virtual bool HoverTarget(Target target)
        {
            return false;
        }
        public virtual bool RightClickAction(Target target)
        {
            return false;
        }
    }
}
