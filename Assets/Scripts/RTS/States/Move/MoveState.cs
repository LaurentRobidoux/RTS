using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace RTS.States.Move
{
    [CreateAssetMenu]
    public class MoveState : State
    {
        public Target Target { get; set; }
        public MoveController MoveController { get; set; }
        public override void Init(GameObject gameobject, params Target[] target)
        {
            base.Init(gameobject, target);
            Target = target[0];
            MoveController = gameobject.GetComponent<MoveController>();
        }
        public override void UpdateState()
        {
            Debug.Log("Move update State");
            MoveController.Move(Target);  
        }
        public override void OnSubStateEvent(SubStateController sub, string msg)
        {
            if (StateEventLibrary.DESTINATION_REACHED==msg)
            {
                Debug.Log("nononon");
                RemoveSelf();
            }
        }
    }
}
