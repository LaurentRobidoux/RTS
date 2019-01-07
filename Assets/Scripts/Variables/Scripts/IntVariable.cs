using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Variables
{
    [Serializable]
    [CreateAssetMenu(fileName = "IntVariable", menuName = "RtsVariable/Int")]
    public class IntVariable : RtsVariable<int>
    {
        public override int GetValue(int playerIndex)
        {
            return playerMod[playerIndex] + Value;
        }
    }
}
