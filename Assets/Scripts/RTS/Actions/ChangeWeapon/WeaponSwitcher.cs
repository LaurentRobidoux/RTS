
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace RTS.Actions.ChangeWeapon
{
    [CreateAssetMenu(menuName = "ActionGrid/WeaponSwitcher")]
    public class WeaponSwitcher : ActionGridElement
    {
     
        //public MonoBehaviour tp;
        public override void Execute(GameObject source)
        {
           source.GetComponents<States.Attack.AttackController>().ToList().ForEach(t => t.Toggle());
        }
    }
}
