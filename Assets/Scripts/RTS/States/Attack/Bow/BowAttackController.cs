using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace RTS.States.Attack.Bow
{
    public class BowAttackController : AttackController
    {
        public Projectile Arrow;
        public float force = 1;
        public override void AttackCallback()
        {
            var lookPos = Target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            var arrowclone=GameObject.Instantiate(Arrow);
            arrowclone.Owner = this;
            arrowclone.Target = Target;
            arrowclone.transform.position = transform.position;
            arrowclone.transform.Translate(0, 1, 0);
            // arrowclone.transform.LookAt(Target.transform.position);
            arrowclone.transform.rotation = rotation;
            arrowclone.transform.right = -arrowclone.transform.forward;
            arrowclone.GetComponent<Rigidbody>().velocity = -arrowclone.transform.right*force;
        }
    }
}
