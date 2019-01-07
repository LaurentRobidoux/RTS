using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace RTS.States
{
    public abstract class State : ScriptableObject
    {
        public abstract void UpdateState();
        public GameObject GameObject { get; set; }
        public virtual void Init(GameObject gameobject, params Target[] target)
        {
            GameObject = gameobject;
        }
        public virtual void OnSubStateEvent(SubStateController sub, string msg)
        {
            
        }
        public void RemoveSelf()
        {
            GameObject.GetComponent<StateController>().RemoveState(this);
        }
    }
}
