using RTS.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using Variables;
namespace RTS.States.Attack
{
    public class DestructableComponent : RtsComponent
    {
        public int HealthLost=0;
        public IntReference MaxHealth;
        public UnityEvent OnDamageTaken;
        public override void Start()
        {
            base.Start();
            OnDamageTaken = new UnityEvent();
        }
        public int CurrentHp
        {
            get
            {
                return MaxHealth - HealthLost;
            }
        }
        public void Damage(int dmg)
        {
            HealthLost += dmg;
            OnDamageTaken.Invoke();
            if (IsDead())
            {
                UnitComponent.Animator.SetBool("Dead", true);
            }
        }
        public void ReceiveAttack(int dmg)
        {
            Damage(dmg);
        }
        public bool IsDead()
        {
            return HealthLost >= MaxHealth;
        }
    }
}
