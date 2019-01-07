using RTS.Tech;
using RTS.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace RTS.Actions.Training
{
    //[CreateAssetMenu(menuName ="Training/Training")]
    public abstract class TrainModule : ScriptableObject
    {
        public int Time;
        public Texture2D Thumbnail;

        /// <summary>
        /// called when the timer is complete on whatever is being trained or researched
        /// </summary>
        /// <param name="building">the bulding that completed the training</param>
        public abstract void Train(TrainComponent building);
    }
}
