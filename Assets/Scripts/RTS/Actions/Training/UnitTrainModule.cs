using RTS.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace RTS.Actions.Training
{
    [CreateAssetMenu(menuName = "Training/Unit")]
    public class UnitTrainModule : TrainModule
    {
        public UnitModel Unit;
        public override void Train(TrainComponent building)
        {
            building.SpawnUnit(Unit.Prefab);
        }
    }
}
