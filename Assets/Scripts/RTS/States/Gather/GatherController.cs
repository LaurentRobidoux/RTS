using RTS.States.Attack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTS.States.Gather
{
    public class GatherController : SubStateController, IAttackCallback
    {
        public int quantity = 0;
        public IAttack AttackComp;
        Target Target;
        private void OnEnable()
        {
            AttackComp = GetComponentInChildren<AttackAnimator>();
        }
        public override bool HoverTarget(Target target)
        {
            if (target.GameObject == null)
            {
                return false;
            }
            if (target.GameObject.GetComponent<ResourceComponent>() != null)
            {
                return true;
            }
            return false;
        }
        public void Gather(Target target)
        {
            //animate
            Target = target;
          AttackComp.Attack(this);
        }
        public override bool RightClickAction(Target target)
        {
            if (target.GameObject == null)
            {
                return false;
            }
            if (target.GameObject.GetComponent<ResourceComponent>()!=null)
            {
                return true;
            }
            return false;
        }

        public void AttackCallback()
        {
            quantity++;
            Target.GameObject.GetComponent<ResourceComponent>().Shake();
        }
    }
}
