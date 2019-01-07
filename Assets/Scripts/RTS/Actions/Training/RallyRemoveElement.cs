using RTS.Actions;
using RTS.Actions.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace RTS.Actions.Training
{
    [CreateAssetMenu(menuName ="ActionGrid/RemoveRallyPoint")]
    public class RallyRemoveElement : ActionGridElement
    {
        public override void Execute(GameObject source)
        {
            source.GetComponent<TrainComponent>().RemoveRallyPoint();
        }
    }
}
