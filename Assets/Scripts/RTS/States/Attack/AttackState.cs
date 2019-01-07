using RTS.States.Attack;
using RTS.States.Move;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace RTS.States.Attack
{
    [CreateAssetMenu]
    public class AttackState : State
    {
        public Target Target { get; set; }
        public MoveController MoveController { get; set; }
       public AttackController AttackController { get; set; }
        public override void Init(GameObject gameobject, params Target[] target)
        {
            base.Init(gameobject, target);
            Target = target[0];
            MoveController = gameobject.GetComponent<MoveController>();
            AttackController = gameobject.GetEnabledComponent<AttackController>();
        }
        public override void UpdateState()
        {
            Debug.Log("Attack update State");
            MoveController.Move(Target,AttackController.AttackRange);
            if (!MoveController.isMoving)
            {
                GameObject.transform.LookAt(Target);
                AttackController.Attack(Target);
            }
            if (Target.GameObject.GetComponent<DestructableComponent>().IsDead())
            {
                RemoveSelf();
            }
        }
        public override void OnSubStateEvent(SubStateController sub, string msg)
        {
            if (msg==StateEventLibrary.SUBSTATE_ENABLED)
            {
                AttackController = (AttackController)sub;
            }
        }
    }
}
