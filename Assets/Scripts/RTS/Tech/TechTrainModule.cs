using RTS.Actions.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace RTS.Tech
{
    [CreateAssetMenu(menuName = "Training/Tech")]
    public class TechTrainModule : TrainModule
    {
        public Technology Tech;
        public override void Train(TrainComponent building)
        {
            Tech.ApplyTech(building.PlayerIndex);
        }
    }
}
