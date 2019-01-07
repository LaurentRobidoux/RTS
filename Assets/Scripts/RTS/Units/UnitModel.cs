using RTS.Actions.Training;
using RTS.Tech;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Variables;
using Utils;
namespace RTS.Units
{
    [CreateAssetMenu]
    public class UnitModel : ScriptableObject , IApplyTech
    {
        public Texture2D _thumbnail;
        public GameObject Prefab;
        public DictoList<int, Technology> TechDicto=new DictoList<int, Technology>();
        [SerializeField]
        public VariableCollection Variables;

        public Texture2D Thumbnail
        {
            get
            {
                return _thumbnail;
            }

     
        }
       
        //public 
        public void ApplyTech(int playerIndex,StatIncreaseTech tech)
        {
            if (TechDicto.AddToList(playerIndex,tech,true))
            {
                tech.Execute(playerIndex, this);
            }

        }

        public t FindVariable<t>(VariableTag tag) where t : RtsVariable
        {
            return Variables.FindByTag<t>(tag);
        }
    }
}
