using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace RTS.States.Attack
{
    public interface IAttack
    {
        void Attack(IAttackCallback callback);
    }
    public interface IAttackCallback
    {
      void AttackCallback();
}

    public class AttackAnimator : MonoBehaviour, IAttack
    {
        public IAttackCallback AttackComp;
        public Animator Animator;
 
        public void AttackCallback()
        {
          //  transform.parent.GetComponents<IAttack>().FirstOrDefault()..AttackCallback();
            AttackComp.AttackCallback();
        }

        public void Attack(IAttackCallback attacker)
        {
            AttackComp = attacker;
            Animator.SetTrigger("Attack");
        }
    }
}
