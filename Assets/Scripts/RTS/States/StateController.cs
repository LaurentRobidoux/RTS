using Observers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace RTS.States
{
    public class StateController : MonoBehaviour,IObserver
    {

        public List<State> States= new List<State>();
        public State ActiveState
        {
            get { return States.FirstOrDefault(); }
        }
        public void Start()
        {
            foreach (var item in GetComponents<SubStateController>())
            {
                item.ObserverCollection.Register(this);
            }
           
        }
        public void ChangeState(State state)
        {
            States.Clear();
            States.Add(state);
        }


        public void RemoveState(State state)
        {
            States.Remove(state);
        }
        private void LateUpdate()
        {
            if (ActiveState!=null)
            {
                ActiveState.UpdateState();
            }
        }
        public void AddState(State state)
        {
            States.Add(state);
        }

        public void OnObservableCall(object caller, string msg)
        {
            if (ActiveState!=null)
            {
                ActiveState.OnSubStateEvent((SubStateController)caller, msg);
            }
           
        }
    }
}
