using RTS.Tech;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Variables;

namespace RTS.Units
{
    [CreateAssetMenu(menuName = "RuntimeSet/Tag")]
    public class TagListSet : ScriptableObject, IApplyTech
    {
        public List<UnitModel> Models;
        public void ApplyTech(int playerIndex,StatIncreaseTech tech)
        {
            for (int index = 0; index < Models.Count; index++)
            {
                Models[index].ApplyTech(playerIndex,tech);
            }
        }
    }
}
