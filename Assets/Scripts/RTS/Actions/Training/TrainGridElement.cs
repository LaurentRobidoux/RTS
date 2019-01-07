using RTS.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace RTS.Actions.Training
{
    [CreateAssetMenu]
    public class TrainGridElement : ActionGridElement
    {
        public TrainModule UnitToTrain;

        public override void Execute(GameObject source)
        {
            source.GetComponent<TrainComponent>().Train(UnitToTrain);
        }
    }
}
