using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Variables
{
    [Serializable]
    [CreateAssetMenu(fileName = "FloatVariable", menuName = "RtsVariable/Float")]
    public class FloatVariable : RtsVariable<float>
    {
        public override float GetValue(int playerIndex)
        {
          return  playerMod[playerIndex] + Value;
        }
    }
}
