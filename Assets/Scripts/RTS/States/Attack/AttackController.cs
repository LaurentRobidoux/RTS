using RTS.Units;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Variables;
using UnityEditor.Animations;

namespace RTS.States.Attack
{
    public class AttackController : SubStateController,IAttackCallback
    {

        public RuntimeAnimatorController AnimationController;
        public GameObject Target;
        public IAttack AttackComp;
        public float AttackRange;
        public float AttackRate = 2;
        private float timeElapseSinceLastAttack;
        public IntReference AttackPower;
        public List<GameObject> weapons;
        private void OnEnable()
        {
            AttackComp = GetComponentInChildren<AttackAnimator>();
            GetComponentInChildren<Animator>().runtimeAnimatorController = AnimationController;
            weapons.ForEach(t => t.SetActive(true));
            ObserverCollection.Call(StateEventLibrary.SUBSTATE_ENABLED);
        }
        private void OnDisable()
        {
            weapons.ForEach(t => t.SetActive(false));
            
           
        }
        private void Update()
        {
            timeElapseSinceLastAttack += Time.deltaTime;
            //print(AttackPower.Value);
        }
        public void Attack(Target target)
        {
            Target = target;
            if (timeElapseSinceLastAttack>AttackRate)
            {
                AttackComp.Attack(this);    
          //  GetComponent<UnitComponent>().Animator.SetTrigger("Attack");
                timeElapseSinceLastAttack = 0;
               
            }
            
        }
        public override bool HoverTarget(Target target)
        {
            if (target.GameObject.GetComponent<UnitComponent>()!=null)
            {
                return target.GameObject.GetComponent<UnitComponent>().PlayerIndex != PlayerIndex;
            }
            return false;
        }
        public override bool RightClickAction(Target target)
        {
            if (target.GameObject==null)
            {
                return false;
            }
            if (target.GameObject.GetComponent<UnitComponent>() != null && target.GameObject.GetComponent<DestructableComponent>()!=null)
            {
                return target.GameObject.GetComponent<UnitComponent>().PlayerIndex != PlayerIndex;
            }
            return false;
        }

        public virtual void AttackCallback()
        {
            Target.GetComponent<DestructableComponent>().ReceiveAttack(AttackPower);
            Target = null;
           
        }
        public void Toggle()
        {
            enabled = !enabled;
        }
    }
}
