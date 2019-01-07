using RTS.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Variables;
using UnityEngine;
namespace RTS.Tech
{
    [CreateAssetMenu(menuName ="Tech/Stat")]
    public class StatIncreaseTech : Technology
    {
       [SerializeField]
        public List<IApplyTechContainer> Targets;
        public VariableTag Tag;
        public int increase;
        public override void ApplyTech(int playerIndex)
        {
            for (int index = 0; index < Targets.Count; index++)
            {
                Targets[index].Result.ApplyTech(playerIndex, this);
            }
               // Target.Result.ApplyTech(playerIndex, this);
            
            
            
        }
        public void Execute(int playerIndex,UnitModel model)
        {
            var v = model.FindVariable<IntVariable>(Tag);
            Debug.Log(v);
          v.playerMod.Dicto[playerIndex] = increase;
        }
    }
}
