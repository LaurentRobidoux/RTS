using RTS.States.Move;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace RTS.States.Gather
{
    [CreateAssetMenu]
    public class GatherState : State
    {
        public MoveController MoveController { get; set; }
        public GatherController GatherController { get; set; }
        public Target Target { get; set; }
        public DropOffComponent DropOff { get; set; }
        public override void Init(GameObject gameobject, params Target[] target)
        {
            base.Init(gameobject, target);
            Target = target[0];
            MoveController = gameobject.GetComponent<MoveController>();
            GatherController = gameobject.GetComponent<GatherController>();
            DropOff = FindClosest(gameobject.transform.parent);
        }
        public override void UpdateState()
        {
            if (GatherController.quantity >= 20)
            {
                MoveController.Move(DropOff.gameObject);
            }
            else
            {
                MoveController.Move(Target);
                if (!MoveController.isMoving)
                {
                    GatherController.Gather(Target);
                }
            }
          
           
        }
        public DropOffComponent FindClosest(Transform parent)
        {
            var list=parent.GetComponentsInChildren<DropOffComponent>();

            return list.OrderBy(t => t.transform.position.sqrMagnitude - GameObject.transform.position.sqrMagnitude).FirstOrDefault();
        }
    }
}
