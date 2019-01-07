using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace RTS.Units.Colors
{
    [ExecuteInEditMode]
    public  class ColorComponent : RtsComponent
    {
        [SerializeField]
        public ColorDicto Colors;
        public void Recolor()
        {
           var list= GetComponentsInChildren<SkinnedMeshRenderer>(true);
            foreach (var item in list)
            {
                item.material = Colors[PlayerIndex];
            }
        }
        private void OnTransformParentChanged()
        {
            print("hello");
            Recolor();
        }
        private void OnEnable()
        {
            Recolor();
        }
    }
}
