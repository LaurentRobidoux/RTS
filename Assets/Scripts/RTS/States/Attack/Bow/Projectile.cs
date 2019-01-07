using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace RTS.States.Attack.Bow
{
    public class Projectile : MonoBehaviour
    {
        public GameObject Target;
        public AttackController Owner;
        public void Start()
        {
            Destroy(this.gameObject, 4);
         
        }
     
        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject!=Target)
            {

                return;
            }
          var des=  collision.gameObject.GetComponent<DestructableComponent>();
            if (des!=null)
            {
                des.ReceiveAttack(Owner.AttackPower);
                Destroy(this.gameObject);
            }
           
            //.ReceiveAttack(AttackPower);
           
        }
    }
}
